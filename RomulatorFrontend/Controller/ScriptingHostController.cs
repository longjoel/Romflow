using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Runtime;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.IO;

namespace RomulatorFrontend.Controller
{


    [ComVisible(true)]
    public class ScriptingHostController
    {
        private Model.ConfigurationRoot _configurationRoot;
        private WebBrowser _target;
        private View.MainWindow _mainWindow;

        public ScriptingHostController(Model.ConfigurationRoot root, WebBrowser target, View.MainWindow mainWindow)
        {
            _configurationRoot = root;
            _target = target;
            _mainWindow = mainWindow;

            _target.ObjectForScripting = this;

        }

        public string GetEmulators()
        {
            var emulators = new List<string>();

            foreach (var e in _configurationRoot.Emulators.EmulatorConfigurations)
            {
                emulators.Add(e.EmulatorName.Replace("'", "").Replace("\"", ""));
            }

            return string.Join("|", emulators);
        }

        public string GetRoms(string emulator)
        {
            var roms = new List<string>();

            var rx = (from r in _configurationRoot.Emulators.EmulatorConfigurations where r.EmulatorName == emulator select r).FirstOrDefault();

            if (rx == null)
            {
                roms.Add("Invalid emulator selection.");
            }
            else
            {
                rx.RomExtensionFilter.Trim().Split('|').ToList().ForEach(rxf =>
            {

                var q = System.IO.Directory.GetFiles(rx.PathToRoms, rxf.Trim(), SearchOption.AllDirectories).ToList();
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

                    roms.Add(System.IO.Path.GetFileNameWithoutExtension(qx).Replace("'", "").Replace("\"", ""));
                }
            });
            }


            return string.Join("|", roms);
        }

        public string GetArtworkURI(string emulator, string rom)
        {
            var rx = (from r in _configurationRoot.Emulators.EmulatorConfigurations where r.EmulatorName == emulator select r).FirstOrDefault();

            if (rx == null)
                return "";

            var files = Directory.GetFiles(rx.PathToArtwork);
            string result = "";
            files
                .ToList()
                .ForEach(fx =>
                {
                    if (fx.ToLower().Contains(rom.ToLower())
                        || rom.ToLower().Contains(fx))
                        result = fx;
                });

            return result;
        }

        public void Execute(string emulator, string rom)
        {

            _mainWindow.SpawnEmulator(emulator, rom);
        }

        public int EnumerateGamepads()
        {
            return _mainWindow.GamePads.Count();
        }

        public string GetGamepadState(int gamepadIndex)
        {
            return _mainWindow.GamePads[gamepadIndex].ToString();
        }

        [DataContract]
        public class RomflowEmulator
        {
            [DataMember]
            public string Emulator { get; set; }

            [DataMember]
            public List<string> Roms { get; set; }
            public RomflowEmulator() { Emulator = ""; Roms = new List<string>(); }
        }

        public string GetGameDom()
        {
            var d = new List<RomflowEmulator>();
            foreach (var e in GetEmulators().Split('|'))
            {
                d.Add(new RomflowEmulator() { Emulator = e, Roms = GetRoms(e).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList() });
            }

            string myString;  // outside using

            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<RomflowEmulator>));
                ser.WriteObject(stream, d);
                myString = Encoding.UTF8.GetString(stream.ToArray());
            }

            return myString;
        }

        public string GetXMLGameDom()
        {
            var d = new List<RomflowEmulator>();
            foreach (var e in GetEmulators().Split('|'))
            {
                d.Add(new RomflowEmulator() { Emulator = e, Roms = GetRoms(e).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList() });
            }

            string myString; 

            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<RomflowEmulator>));
                ser.Serialize(stream, d);
                myString = Encoding.UTF8.GetString(stream.ToArray());
            }

            return myString;
        }

        public void SetRating(string emulator, string rom, int rating)
        {
            PlayStats.SetRating(emulator, rom, rating);
        }

        public int GetRating(string emulator, string rom)
        {
            return PlayStats.GetRating(emulator, rom);
        }

        public int GetPlayCount(string emulator, string rom)
        {
            return PlayStats.GetPlayCount(emulator, rom);
        }



        public string GetNetworkSharePath()
        {
            return _configurationRoot.Environment.SharePath;
        }

     

        public void RestartWindows()
        {
            System.Diagnostics.Process.Start("shutdown", "/r /f /t 0");
        }

        public void ShutdownWindows()
        {
            System.Diagnostics.Process.Start("shutdown", "/s /f /t 0");
        }
    }
}
