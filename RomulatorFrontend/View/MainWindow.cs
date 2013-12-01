using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

using System.Management;

namespace RomulatorFrontend.View
{
    [ComVisibleAttribute(true)]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class MainWindow : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("USER32.DLL")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int ShowCursor(bool bShow);

        [DllImport("user32.dll")]
        static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        static extern bool SetMenu(IntPtr hWnd, IntPtr hMenu);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(
               IntPtr parentHwnd,
               IntPtr childAfterHwnd,
               IntPtr className,
               string windowText);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);



        //assorted constants needed
        public static int GWL_STYLE = -16;
        public static int WS_BORDER = 0x00800000; //window with border
        public static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        public static int WS_CAPTION = WS_BORDER | WS_DLGFRAME; //window with a title bar
        public static uint MF_BYPOSITION = 0x400;
        public static uint MF_REMOVE = 0x1000;

        /// <summary>
        /// The collection of controllers physically attatched to the machine when the software is started.
        /// </summary>
        public Model.GamepadCollection GamePads { get; set; }

        /// <summary>
        /// The process hosted
        /// </summary>
        Process _clientEmulatorProcess;

        /// <summary>
        /// The root configuration file. If no such file exists, one will be created.
        /// </summary>
        Model.ConfigurationRoot _configurationRoot;

        /// <summary>
        /// The scripting host acts as the interaction layer between the webcontrol and the rest of the application.
        /// </summary>
        Controller.ScriptingHostController _scriptingHost;


        /// <summary>
        /// currently running emulator.
        /// </summary>
        Model.ConfigurationEmulator _currentEmulator;

        /// <summary>
        /// 
        /// </summary>
        bool _fullscreen = false;

        /// <summary>
        /// 
        /// </summary>
        bool _isLoaded;

        DateTime _emulatorStartTime;
        DateTime _emulatorEndTime;

        List<Process> _backgroundProcesses;

        ManagementEventWatcher _usbDriveWatcher;

        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            RomulatorFrontend.Controller.PlayStats.Init();

            try
            {
                TryLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load settings. Reason: " + ex.Message);
            }

            if (!_configurationRoot.Environment.HasReadLicense)
            {
                new About().ShowDialog();
                _configurationRoot.Environment.HasReadLicense = true;
                
            }
           

            try
            {
                GamePads = new Model.GamepadCollection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create gamepad collection. Reason: " + ex.Message);
                return;
            }

            try
            {
                _scriptingHost = new Controller.ScriptingHostController(_configurationRoot, this.RootWebBrowser, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create scripting host control. Reason: " + ex.Message);
            }

            _backgroundProcesses = new List<Process>();
            _configurationRoot.Environment.StartupCommands.Where(s => s.Enabled).ToList().ForEach(s =>
            {
                var p = new Process();
                p.StartInfo = new ProcessStartInfo()

                        {
                            Arguments = s.Parameters,

                            FileName = s.CommandPath,

                            UseShellExecute = false,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden
                        };

                try
                {
                    p.Start();

                    while (p.MainWindowHandle == IntPtr.Zero)
                    {
                        p.Refresh();
                    }

                    ShowWindow(p.MainWindowHandle, 0x00);

                    _backgroundProcesses.Add(p);
                }

                catch
                {
                    MessageBox.Show("Unable to start background process " + s.CommandPath + ".");
                }
            });

            FormClosed += (o, ex) => { _backgroundProcesses.ForEach(p => { try { p.Kill(); } catch { } }); };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            if (_usbDriveWatcher != null)
            {
                _usbDriveWatcher.Stop();
            }
            try
            {
                TrySave();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save settings file. Reason: " + ex.Message);
            }
            base.OnClosed(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControllerPollingTImer_Tick(object sender, EventArgs e)
        {
            if (!_isLoaded)
                return;

            // if there is an emulator running, check the gamepad for key combos that may close the system, or what have you
            if (_clientEmulatorProcess != null)
            {
                for (int i = 0; i < (int)Math.Min(GamePads.Count(), _configurationRoot.Gamepads.GamePadInformation.Count); i++)
                {
                    var inputCombo = GamePads[i].ToString();

                    if ((_configurationRoot.Gamepads.GamePadInformation[i].QuitCombo != string.Empty
                        && inputCombo != string.Empty)
                        && _configurationRoot.Gamepads.GamePadInformation[i].QuitCombo == inputCombo)
                    {
                        if (_clientEmulatorProcess != null && _currentEmulator.IsAutoLoadAutoSave)
                        {
                            SetForegroundWindow(_clientEmulatorProcess.Handle);
                            for (int j = 0; j < 10; j++)
                            {
                                SendKeys.SendWait(_currentEmulator.QuickSaveCombination);
                                System.Threading.Thread.Sleep(100);
                            }

                            System.Threading.Thread.Sleep(1000);
                        }

                        _clientEmulatorProcess.CloseMainWindow();
                        _clientEmulatorProcess.Kill();
                        _clientEmulatorProcess = null;

                    }

                    if ((_configurationRoot.Gamepads.GamePadInformation[i].QuickSaveCombo != string.Empty
                        && inputCombo != string.Empty)
                        && _configurationRoot.Gamepads.GamePadInformation[i].QuickSaveCombo == inputCombo)
                    {
                        SetForegroundWindow(_clientEmulatorProcess.Handle);
                        for (int j = 0; j < 5; j++)
                        {
                            SendKeys.SendWait(_currentEmulator.QuickSaveCombination);
                            System.Threading.Thread.Sleep(100);
                        }

                    }

                    if ((_configurationRoot.Gamepads.GamePadInformation[i].QuickLoadCombo != string.Empty
                        && inputCombo != string.Empty)
                        && _configurationRoot.Gamepads.GamePadInformation[i].QuickLoadCombo == inputCombo)
                    {
                        SetForegroundWindow(_clientEmulatorProcess.Handle);
                        for (int j = 0; j < 5; j++)
                        {
                            SendKeys.SendWait(_currentEmulator.QuickLoadCombination);
                            System.Threading.Thread.Sleep(100);
                        }
                    }


                }
            }
            // if there is not an emulator running, poll the game pads for navigation ques
            else
            {
                for (int i = 0; i < Math.Min(GamePads.Count(), _configurationRoot.Gamepads.GamePadInformation.Count); i++)
                {
                    var gpts = GamePads[i].ToString().ToUpper();
                    var gpc = _configurationRoot.Gamepads.GamePadInformation[i];

                    if (gpts == gpc.NavigateBackButton.ToUpper())
                    {
                        RootWebBrowser.Document.InvokeScript("eval", new string[] { "RomFlowJS.HOST.NavigateBackward();" });
                    }

                    if (gpts == gpc.NavigateForwardButton.ToUpper())
                    {
                        RootWebBrowser.Document.InvokeScript("eval", new string[] { "RomFlowJS.HOST.NavigateForward();" });
                    }

                    if (gpts == gpc.NavigateUpButton.ToUpper())
                    {
                        RootWebBrowser.Document.InvokeScript("eval", new string[] { "RomFlowJS.HOST.NavigateUp();" });
                    }

                    if (gpts == gpc.NavigateDownButton.ToUpper())
                    {
                        RootWebBrowser.Document.InvokeScript("eval", new string[] { "RomFlowJS.HOST.NavigateDown();" });
                    }
                    if (gpts == gpc.NavigateLeftButton.ToUpper())
                    {
                        RootWebBrowser.Document.InvokeScript("eval", new string[] { "RomFlowJS.HOST.NavigateLeft();" });
                    }
                    if (gpts == gpc.NavigateRightButton.ToUpper())
                    {
                        RootWebBrowser.Document.InvokeScript("eval", new string[] { "RomFlowJS.HOST.NavigateRight();" });
                    }

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamepadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControllerPollingTimer.Stop();
            new ConfigurationGamePadCollection(_configurationRoot, GamePads).ShowDialog();
            ControllerPollingTimer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void TrySave()
        {
            var settingsPath = Vars.ApplicationSettingsFile;

            using (var fw = new StringWriter())
            {
                XmlSerializer ser = new XmlSerializer(typeof(Model.ConfigurationRoot));
                ser.Serialize(fw, _configurationRoot);
                System.IO.File.WriteAllText(settingsPath, fw.ToString());

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void TryLoad()
        {
            var settingsPath = Vars.ApplicationSettingsFile;

            if (File.Exists(settingsPath))
            {
                var text = System.IO.File.ReadAllText(settingsPath);

                try
                {
                    //DataContractSerializer dc = new DataContractSerializer(typeof(Model.ConfigurationRoot));
                    XmlSerializer ser = new XmlSerializer(typeof(Model.ConfigurationRoot));

                    _configurationRoot = (Model.ConfigurationRoot)ser.Deserialize(new StringReader(text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failure to load existing configuration file. Creating a new one. \n\n" + ex.Message);
                    _configurationRoot = new Model.ConfigurationRoot();
                }

            }
            else
            {
                _configurationRoot = new Model.ConfigurationRoot();
            }

            if (_configurationRoot.Environment.ScanExternalMedia)
            {
                _usbDriveWatcher = new ManagementEventWatcher();
                WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2 OR EventType = 3");
                _usbDriveWatcher.EventArrived += new EventArrivedEventHandler((o, ex) =>
                {

                    ReloadTheme();

                });
                _usbDriveWatcher.Query = query;
                _usbDriveWatcher.Start();

            }

            if (_configurationRoot.Environment.GamepadPollRate == 0)
                _configurationRoot.Environment.GamepadPollRate = 250;

            // set the initial variables
            ControllerPollingTimer.Interval = _configurationRoot.Environment.GamepadPollRate;
            FullScreen = _configurationRoot.Environment.IsFullscreenOnStart;


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="emulator"></param>
        /// <param name="rom"></param>
        public void SpawnEmulator(string emulator, string rom)
        {
            if (_clientEmulatorProcess != null)
            {
                _clientEmulatorProcess.CloseMainWindow();
                _clientEmulatorProcess.Kill();
                _clientEmulatorProcess = null;
            }
            var runningEmulator = (from r in _configurationRoot.Emulators.EmulatorConfigurations where r.EmulatorName.Replace("'", "").Replace("\"", "") == emulator.Replace("'", "").Replace("\"", "") select r).FirstOrDefault();

            if (runningEmulator == null)
            {
                return;
            }

            _currentEmulator = runningEmulator;


            var romList = new List<string>();

            runningEmulator.RomExtensionFilter.Trim().Split('|').ToList().ForEach(rxf =>
            {
                var q = System.IO.Directory.GetFiles(runningEmulator.PathToRoms, rxf.Trim(), SearchOption.AllDirectories).ToList();
                if (_configurationRoot.Environment.ScanExternalMedia)
                {
                    System.IO.DriveInfo.GetDrives().Where(d => d.DriveType != DriveType.Fixed).ToList().ForEach(d =>
                    {
                        try
                        {
                            q.AddRange(System.IO.Directory.GetFiles(d.RootDirectory.FullName, rxf.Trim(), SearchOption.AllDirectories).Where(f => f.Trim().Length > 0).ToList());
                        }
                        catch { }
                    });
                }
                foreach (var qx in q)
                {
                    romList.Add(qx);
                }
            });

            foreach (var qx in romList)
            {
                if (System.IO.Path.GetFileNameWithoutExtension(qx).ToLower().Replace("'", "").Replace("\"", "") == rom.ToLower().Replace("'", "").Replace("\"", ""))
                {
                    _clientEmulatorProcess = new Process()
                    {
                        StartInfo = new ProcessStartInfo()
                        {
                            Arguments = runningEmulator.CommandLineParameters
                            .Replace("%ROM%", "\"" + qx + "\"")
                            .Replace("%ROMPATH%", "\"" + System.IO.Path.GetDirectoryName(qx) + "\""),
                            FileName = runningEmulator.PathToEmulator,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        },
                        EnableRaisingEvents = true
                    };

                    _clientEmulatorProcess.Exited += (o, e) =>
                    {
                        _emulatorEndTime = DateTime.Now;



                        DisableLightbox();

                        Invoke(new Action(() =>
                        {

                            Controller.PlayStats.InsertPlayTime(emulator, rom, _emulatorStartTime, _emulatorEndTime);
                            _clientEmulatorProcess = null;
                        }));

                        Invoke(new Action(() =>
                        {
                            if (RootWebBrowser.Document != null)
                            {
                                RootWebBrowser.Document.InvokeScript("eval",
                                    new string[] { "RomFlowJS.HOST.OnEmulatorExit();" });
                            }
                        }));

                    };

                    // get rid of the mouse first.
                    if (_currentEmulator.Lightbox)
                    {

                        Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width, 0);
                        // ShowCursor(false);

                    }

                    _clientEmulatorProcess.Start();

                    _emulatorStartTime = DateTime.Now;

                    while (_clientEmulatorProcess.MainWindowHandle == IntPtr.Zero)
                    {

                        _clientEmulatorProcess.Refresh();

                        System.Threading.Thread.Sleep(10);
                    }

                 

                    if (_currentEmulator.Lightbox)
                    {
                        EnableLightbox();
                    }

                }
            }
        }

        private static void DisableLightbox()
        {
            ShowWindow(FindWindow("Shell_TrayWnd", ""), 1);
            ShowWindow(FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null), 1);
            //ShowCursor(true);
        }

        private void EnableLightbox()
        {
            int style = GetWindowLong(_clientEmulatorProcess.MainWindowHandle, GWL_STYLE);
            SetWindowLong(_clientEmulatorProcess.MainWindowHandle, GWL_STYLE, (0));

            ShowWindow(_clientEmulatorProcess.MainWindowHandle, 3);


            MoveWindow(_clientEmulatorProcess.MainWindowHandle,
                40,
                40,
                System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - 80,
                System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - 80,
                true);

            System.Threading.Thread.Sleep(100);

            IntPtr menuHandle = GetMenu(_clientEmulatorProcess.MainWindowHandle);

            int count = GetMenuItemCount(menuHandle);

            for (int i = 0; i < count; i++)
                RemoveMenu(menuHandle, 0, (MF_BYPOSITION | MF_REMOVE));

            SetMenu(_clientEmulatorProcess.MainWindowHandle, IntPtr.Zero);

            DrawMenuBar(_clientEmulatorProcess.MainWindowHandle);

            ShowWindow(FindWindow("Shell_TrayWnd", ""), 0);
            ShowWindow(FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null), 0);

            Invoke(new Action(() =>
            {
                SendMessage(this.Handle, 0x200, IntPtr.Zero, IntPtr.Zero);
              
            }));


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void emulatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControllerPollingTimer.Stop();
            new ConfigurationEmulatorCollection(_configurationRoot).ShowDialog();
            ReloadTheme();
            ControllerPollingTimer.Start();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            ReloadTheme();


            _isLoaded = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReloadTheme()
        {
            var themePath = "";

            if (System.IO.File.Exists(System.IO.Path
                .Combine(Vars.ThemePath,
                _configurationRoot.Environment.Theme, "Index.html")))
            {

                themePath = System.IO.Path
                .Combine(Vars.ThemePath,
                _configurationRoot.Environment.Theme, "Index.html");
            }
            else if (System.IO.File.Exists(System.IO.Path
                 .Combine(System.IO.Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DefaultThemes")),
                 _configurationRoot.Environment.Theme, "Index.html")))
            {

                themePath = System.IO.Path
                  .Combine(System.IO.Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DefaultThemes")),
                  _configurationRoot.Environment.Theme, "Index.html");

            }

            else
            {
                themePath = System.IO.Path
                  .Combine(Path.GetFullPath("DefaultThemes"),
                  "default", "Index.html");
            }

            Invoke(new Action(() =>
            {
                RootWebBrowser.Navigate(new System.Uri(themePath));
            }));

        }


        /// <summary>
        /// 
        /// </summary>
        public bool FullScreen
        {
            get { return _fullscreen; }
            set
            {
                _fullscreen = value;

                if (_fullscreen)
                {
                    ShowWindow(FindWindow("Shell_TrayWnd", ""), 0);
                    ShowWindow(FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null), 0);

                    this.PrimaryMainMenuStrip.Visible = false;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;


                }
                else
                {

                    ShowWindow(FindWindow("Shell_TrayWnd", ""), 1);
                    ShowWindow(FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null), 1);

                    this.PrimaryMainMenuStrip.Visible = true;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                }

            }
        }

        // handle full screen not fullscreen
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F4)
            {
                this.FullScreen = !this.FullScreen;
                return true;
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void systemConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControllerPollingTimer.Stop();
            new ConfigurationEnvironmentForm(_configurationRoot.Environment).ShowDialog();
            ReloadTheme();
            ControllerPollingTimer.Start();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();

        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowWindow(FindWindow("Shell_TrayWnd", ""), 1);
            ShowWindow(FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null), 1);
        }

    }
}
