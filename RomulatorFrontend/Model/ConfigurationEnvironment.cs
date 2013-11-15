using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace RomulatorFrontend.Model
{
    [DataContract]
    public class ConfigurationEnvironment
    {
        [DataMember]
        public int GamepadPollRate { get; set; }

        [DataMember]
        public bool IsFullscreenOnStart { get; set; }

      
        [DataMember]
        public string Theme { get; set; }

        [DataMember]
        public string SharePath { get; set; }

        [DataMember]
        public bool ScanExternalMedia { get; set; }

        [DataMember]
        public List<ConfigurationEnvironmentStartupCommand> StartupCommands { get; set; }

        [DataMember]
        public bool HasReadLicense { get; set; }

        public ConfigurationEnvironment()
        {
            StartupCommands = new List<ConfigurationEnvironmentStartupCommand>();
            GamepadPollRate = 250;
            IsFullscreenOnStart = false;
            SharePath = "";
            Theme = "Menu";
            ScanExternalMedia = false;
            HasReadLicense = false;
           
        }
    }
}
