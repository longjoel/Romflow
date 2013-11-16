using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RomulatorFrontend.View
{
    public partial class ConfigurationEmulator : UserControl
    {

        private Model.ConfigurationEmulator _emulator;

        public ConfigurationEmulator(Model.ConfigurationEmulator emulator)
        {
            InitializeComponent();

            _emulator = emulator;

            if (_emulator != null)
                LoadSettings();

        }

        private void SetPathEmulatorButton_Click(object sender, EventArgs e)
        {
            var openemupath = this.EmulatorPathTextBox.Text;

            if (openemupath == string.Empty || !System.IO.Directory.Exists(openemupath))
                openemupath = Vars.EmulatorRootPath;


            var fd = new OpenFileDialog()
            {
                Filter = "Executable files (*.exe)|*.exe",
                Title = "Open Emulator",
                InitialDirectory = openemupath,
                AutoUpgradeEnabled = true,
               
            };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.EmulatorPathTextBox.Text = fd.FileName;
            }

        }

        private void LaunchEmulatorButton_Click(object sender, EventArgs e)
        {
            if (this.EmulatorPathTextBox.Text != "")
            {
                try
                {
                    System.Diagnostics.Process.Start(this.EmulatorPathTextBox.Text);
                }
                catch { }
            }
           
        }

        private void SetRomPathButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog()
            {
             
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.PathToRomsTextBox.Text = fbd.SelectedPath;
            }
        }

        private void ExploreRomsButton_Click(object sender, EventArgs e)
        {
            if (this.PathToRomsTextBox.Text != "")
            {
                try
                {
                    System.Diagnostics.Process.Start(this.PathToRomsTextBox.Text);
                }
                catch { }
            }
            
        }

        private void ConfigurationEmulator_Load(object sender, EventArgs e)
        {
            FindForm().FormClosed += (o, ex) => { SaveSettings(); };

        }

        private void LoadSettings()
        {
            this.EmulatorNameTextBox.Text = _emulator.EmulatorName;
            this.EmulatorPathTextBox.Text = _emulator.PathToEmulator;
            this.CommandLineParametersTextBox.Text = _emulator.CommandLineParameters;
            this.PathToRomsTextBox.Text = _emulator.PathToRoms;
            this.FilterForRomsTextBox.Text = _emulator.RomExtensionFilter;

            
            this.QuickSaveTextBox.Text = _emulator.QuickSaveCombination;
            this.QuickLoadTextBox.Text = _emulator.QuickLoadCombination;

            this.PathToArtworkTextBox.Text = _emulator.PathToArtwork;

            this.LightboxCheckBox.Checked = _emulator.Lightbox;
            
        }

        private void SaveSettings()
        {
            _emulator.EmulatorName = this.EmulatorNameTextBox.Text;
            _emulator.PathToEmulator = this.EmulatorPathTextBox.Text;
            _emulator.CommandLineParameters = this.CommandLineParametersTextBox.Text;
            _emulator.PathToRoms = this.PathToRomsTextBox.Text;
            _emulator.RomExtensionFilter = this.FilterForRomsTextBox.Text;

            _emulator.PathToArtwork = this.PathToArtworkTextBox.Text;
           
            _emulator.QuickSaveCombination = this.QuickSaveTextBox.Text;
            _emulator.QuickLoadCombination = this.QuickLoadTextBox.Text;

            _emulator.Lightbox = this.LightboxCheckBox.Checked;
           

        }

    

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
             System.Diagnostics.Process.Start("http://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.aspx");
        }

        private void OpenPathToArtworkButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog()
            {

            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.PathToArtworkTextBox.Text = fbd.SelectedPath;
            }
        }

        private void ExplorePathToArtworkButton_Click(object sender, EventArgs e)
        {
            if (this.PathToArtworkTextBox.Text != "")
            {
                try
                {
                    System.Diagnostics.Process.Start(this.PathToArtworkTextBox.Text);
                }
                catch { }
            }
            
        }
    }
}
