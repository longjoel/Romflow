using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
namespace RomulatorFrontend.Model
{
    [DataContract]
    public class ConfigurationEnvironmentStartupCommand
    {
        [DataMember]
        public string CommandPath { get; set; }

        [DataMember]
        public string Parameters { get; set; }

        [DataMember]
        public bool Enabled { get; set; }

        public ConfigurationEnvironmentStartupCommand()
        {
            CommandPath = "";
            Parameters = "";
            Enabled = false;
        }
    }
}
