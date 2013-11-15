using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Security.Principal;
using System.Management;
using System.IO;

using System.Diagnostics;

namespace RomulatorFrontend.View
{
    public partial class ConfigurationEnvironmentForm : Form
    {
        Model.ConfigurationEnvironment _environment;

        public ConfigurationEnvironmentForm(Model.ConfigurationEnvironment environment)
        {
            InitializeComponent();
            _environment = environment;
        }

        public ConfigurationEnvironmentForm() : this(null) { }

        public void SaveSettings()
        {
            if (_environment != null)
            {
                _environment.GamepadPollRate = (int)this.GamepadPollRateNumericUpDown.Value;
                _environment.IsFullscreenOnStart = this.FullScreenStartupCheckBox.Checked;
                _environment.Theme = this.ThemeComboBox.Text;


                _environment.StartupCommands.Clear();
                RunOnLoadDataGridView.EndEdit();

                foreach (DataGridViewRow r in RunOnLoadDataGridView.Rows)
                {

                    var rx = new Model.ConfigurationEnvironmentStartupCommand();
                    rx.CommandPath = (string)((r.Cells["CommandPathTextBox"] as DataGridViewTextBoxCell).Value ?? "");
                    rx.Parameters = (string)((r.Cells["CommandParametersTextBoxColumn"] as DataGridViewTextBoxCell).Value ?? "");
                    rx.Enabled = (r.Cells["CommandEnabledCheckBox"] as DataGridViewCheckBoxCell).Value != null
                        && ((bool)(r.Cells["CommandEnabledCheckBox"] as DataGridViewCheckBoxCell).Value == true);

                    if (rx.CommandPath.Trim().Length > 0)
                        _environment.StartupCommands.Add(rx);

                }

                _environment.ScanExternalMedia = ScanExternalCheckBox.Checked;

            }
        }

        private void LoadSettings()
        {

            if (_environment != null)
            {
                LoadPageLookAndFeel();
                LoadPageStartup();

                LoadPageSharing();

                this.ScanExternalCheckBox.Checked = _environment.ScanExternalMedia;
            }
        }

        private void LoadPageSharing()
        {
            NetworkSharePathTextBox.Text = _environment.SharePath;

            if (Vars.IsAdministrator)
            {
                InstallNetworkSharePathButton.Enabled = true;
            }
            else
            {
                InstallNetworkSharePathButton.Enabled = false;
            }

            if (_environment.SharePath != string.Empty)
                InstallNetworkSharePathButton.Visible = false;
            else
                InstallNetworkSharePathButton.Visible = true;
        }

        private void LoadPageStartup()
        {
            this.SystemShellComboBox.Items.Clear();
            this.SystemShellComboBox.Items.Add(Vars.ExecutionPath);
            this.SystemShellComboBox.Items.Add(Vars.DefaultShellPath);
            this.SystemShellComboBox.Text = Vars.ShellRegistryValue;

            if (Vars.IsAdministrator)
            {
                this.SystemShellComboBox.Enabled = true;
            }
            else
            {
                this.SystemShellComboBox.Enabled = false;
            }

            FullScreenStartupCheckBox.Checked = _environment.IsFullscreenOnStart;



            foreach (var r in _environment.StartupCommands)
            {
                this.RunOnLoadDataGridView.Rows.Add(r.CommandPath, r.Parameters, r.Enabled);

                //DataGridViewRow newRow = (DataGridViewRow)RunOnLoadDataGridView.Rows[0].Clone();
                //newRow.Cells["CommandPathTextBox"].Value = r.CommandPath;
                //newRow.Cells["CommandParametersTextBoxColumn"].Value = r.Parameters;
                //newRow.Cells["CommandEnabledCheckBox"].Value = r.Enabled;

                //RunOnLoadDataGridView.Rows.Add(newRow);
            }


        }

        private void LoadPageLookAndFeel()
        {
            this.GamepadPollRateNumericUpDown.Value = _environment.GamepadPollRate;

            if (!System.IO.Directory.Exists(Vars.ThemePath))
            {
                System.IO.Directory.CreateDirectory(Vars.ThemePath);
            }

            var themes = System.IO.Directory.EnumerateDirectories(
            Vars.ThemePath).ToList().Union(
            System.IO.Directory.EnumerateDirectories(Vars.DefaultThemePath)).ToList();

            themes.ForEach((t) => ThemeComboBox.Items.Add(t.Split('\\').Last()));


            this.ThemeComboBox.Text = _environment.Theme;
        }

        private void OpenThemesButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Vars.ThemePath);
        }

        private void RunAsAdministratorButton_Click(object sender, EventArgs e)
        {
            // relaunch the application with admin rights
            string fileName = Vars.ExecutionPath;
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.Verb = "runas";
            processInfo.FileName = fileName;

            try
            {
                Process.Start(processInfo);
                Application.Exit();
            }
            catch (Win32Exception)
            {
                // This will be thrown if the user cancels the prompt
            }
        }

        private void SystemShellComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
            regKey.SetValue("Shell", SystemShellComboBox.Text);
            regKey.Close();
        }

        private void ShareFolderPermission(string FolderPath, string ShareName, string Description)
        {

            // Calling Win32_Share class to create a shared folder
            ManagementClass managementClass = new ManagementClass("Win32_Share");
            // Get the parameter for the Create Method for the folder
            ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
            ManagementBaseObject outParams;
            // Assigning the values to the parameters
            inParams["Description"] = Description;
            inParams["Name"] = ShareName;
            inParams["Path"] = FolderPath;
            inParams["Type"] = 0x0;
            // Finally Invoke the Create Method to do the process
            outParams = managementClass.InvokeMethod("Create", inParams, null);
            // Validation done here to check sharing is done or not
            if ((uint)(outParams.Properties["ReturnValue"].Value) != 0)
                MessageBox.Show("Folder might be already in share or unable to share the directory");
        }


        private void InstallNetworkSharePathButton_Click(object sender, EventArgs e)
        {
            var romPath = Vars.RomRootPath;

            try
            {
                ShareFolderPermission(romPath, "ROMFLOW_ROMS", "Root Rom folder for RomFlow");

                var shares = GetNetShares.EnumNetShares(Environment.MachineName);
                this._environment.SharePath = @"\\" + Environment.MachineName + @"\" +
                    shares.Where(s =>
                        s.shi1_netname.Contains("ROMFLOW_ROMS")).First().shi1_netname;
                this.NetworkSharePathTextBox.Text = this._environment.SharePath;
                MessageBox.Show("Path added successfully.");
                InstallNetworkSharePathButton.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ConfigurationEnvironmentForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            FindForm().FormClosed += (o, ex) => { SaveSettings(); };
        }

        private void LaunchExplorerButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Vars.DefaultShellPath);
        }

        private void RestartWindowsButton_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r /f /t 0");
        }

        private void ShutdownWindowsButton_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /f /t 0");
        }

        private void ScanExternalCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}
