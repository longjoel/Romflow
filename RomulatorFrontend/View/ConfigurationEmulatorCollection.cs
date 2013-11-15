using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RomulatorFrontend.View
{
    public partial class ConfigurationEmulatorCollection : Form
    {
        Model.ConfigurationRoot _root;

        List<List<string>> _emuConfigs;

        public ConfigurationEmulatorCollection(Model.ConfigurationRoot root)
        {
            _root = root;

            _emuConfigs = new List<List<string>>();



            var lines = System.IO.File.ReadAllLines(Vars.EmulatorTemplateFile);
            foreach (var l in lines)
            {
                var cfg = l.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                _emuConfigs.Add(cfg);

            }

            InitializeComponent();

            if (_root != null)
            {
                LoadControl();
            }



        }

        private void LoadControl()
        {
            if (_root.Emulators == null)
            {
                _root.Emulators = new Model.ConfigurationEmulatorCollection();
            }

            foreach (var e in _root.Emulators.EmulatorConfigurations)
            {
                var tp = new TabPage(e.EmulatorName);
                tp.Controls.Add(new ConfigurationEmulator(e) { Dock = DockStyle.Fill });
                EmulatorCollectionTabControl.TabPages.Add(tp);
            }

            foreach (var i in _emuConfigs)
            {
                this.EmulatorListingComboBox.Items.Add(i[0]);
            }

        }

        private void SaveControl()
        {
        }

        public ConfigurationEmulatorCollection()
            : this(null)
        {
        }

        private void AddEmulatorButton_Click(object sender, EventArgs e)
        {
            var emu = new Model.ConfigurationEmulator();
            _root.Emulators.EmulatorConfigurations.Add(emu);

            var tp = new TabPage("Untitled Emulator");
            tp.Controls.Add(new ConfigurationEmulator(emu) { Dock = DockStyle.Fill });
            EmulatorCollectionTabControl.TabPages.Add(tp);

        }

        private void RemoveEmulatorButton_Click(object sender, EventArgs e)
        {
            var si = EmulatorCollectionTabControl.SelectedIndex;
            _root.Emulators.EmulatorConfigurations.RemoveAt(si);


            EmulatorCollectionTabControl.TabPages.RemoveAt(si);
        }

        private static string CleanFileName(string fileName)
        {
            return System.IO.Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        private void DownloadEmulatorButton_Click(object sender, EventArgs e)
        {
            if (this.EmulatorListingComboBox.SelectedIndex != -1)
            {

                var emuPath = System.IO.Path.Combine(
                     Vars.EmulatorRootPath, EmulatorListingComboBox.Text);

                var romPath = System.IO.Path.Combine(
                    Vars.RomRootPath, EmulatorListingComboBox.Text);

                var artPath = System.IO.Path.Combine(
                    Vars.RomRootPath, EmulatorListingComboBox.Text);

                var downloadURI = _emuConfigs[EmulatorListingComboBox.SelectedIndex][1];

                var drx = System.IO.Path.GetFileName(downloadURI);

                var tempEmuPath = CleanFileName(System.IO.Path.Combine(Vars.TempFolderPath, drx));

                

                this.EmulatorCollectionTabControl.Enabled = false;
                this.AddEmulatorButton.Enabled = false;
                this.RemoveEmulatorButton.Enabled = false;
                this.DownloadEmulatorButton.Enabled = false;
                this.EmulatorListingComboBox.Enabled = false;
                DownloadProgressBar.Value = 0;

                var romWorker = new BackgroundWorker();
                romWorker.WorkerReportsProgress = true;
                romWorker.ProgressChanged += (o, ex) => { DownloadProgressBar.Value = ex.ProgressPercentage; };
                romWorker.RunWorkerCompleted += (o, ex) =>
                {
                    if (DownloadProgressBar.Value == 100)
                    {
                        // create the info
                        var emu = new Model.ConfigurationEmulator();
                        var ecf = _emuConfigs[EmulatorListingComboBox.SelectedIndex];
                        emu.EmulatorName = ecf[0];
                        emu.CommandLineParameters = ecf[2];
                        emu.PathToEmulator = System.IO.Path.Combine(emuPath, ecf[4].Trim());
                        emu.PathToRoms = romPath;
                        emu.PathToArtwork = artPath;
                        emu.Lightbox = true;
                        emu.RomExtensionFilter = ecf[3];

                        _root.Emulators.EmulatorConfigurations.Add(emu);

                        var tp = new TabPage(ecf[0]);
                        tp.Controls.Add(new ConfigurationEmulator(emu) { Dock = DockStyle.Fill });
                        EmulatorCollectionTabControl.TabPages.Add(tp);


                    }

                    DownloadProgressBar.Value = 0;
                    this.EmulatorCollectionTabControl.Enabled = true;
                    this.AddEmulatorButton.Enabled = true;
                    this.RemoveEmulatorButton.Enabled = true;
                    this.DownloadEmulatorButton.Enabled = true;
                    this.EmulatorListingComboBox.Enabled = true;
                };
                romWorker.DoWork += (o, ex) =>
                {

                    if (!System.IO.Directory.Exists(emuPath))
                        System.IO.Directory.CreateDirectory(emuPath);

                    if (!System.IO.Directory.Exists(romPath))
                        System.IO.Directory.CreateDirectory(romPath);

                    if (!System.IO.Directory.Exists(artPath))
                        System.IO.Directory.CreateDirectory(artPath);

                    romWorker.ReportProgress(10);


                    var w = new System.Net.WebClient();
                    try
                    {
                       
                       
                        w.DownloadFile(
                            downloadURI
                            , tempEmuPath);

                        romWorker.ReportProgress(20);

                        
                        Decompress(tempEmuPath, emuPath);

                        romWorker.ReportProgress(100);
                    }

                    catch (Exception exc)
                    {
                        MessageBox.Show(string.Join(Environment.NewLine, "Unable to download emulator. Please make sure you are connected to the internet",
                            "Exception details:", exc.Message));
                    }


                };
                romWorker.RunWorkerAsync();


            }
        }

        protected override void OnClosed(EventArgs e)
        {
            SaveControl();
            base.OnClosed(e);
        }

        private static void Decompress(string inputFile, string outputDir)
        {
            if (System.IO.Path.GetExtension(inputFile) == ".rar")
            {
                var extractString = string.Format("x \"{0}\" \"{1}\" * -r -o", inputFile, outputDir);
                System.Diagnostics.Process.Start(System.IO.Path.Combine(Vars.UnRarPath), extractString);
            }
            else
            {
                var extractString = string.Format("x  \"{0}\" -o\"{1}\" * -r -y", inputFile, outputDir);
                System.Diagnostics.Process.Start(System.IO.Path.Combine(Vars.SevenZipPath), extractString);
            }
        }
    }
}
