using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RomulatorFrontend.Model
{
    [DataContract]
    public class ConfigurationEmulatorCollection
    {
        [DataMember]
        public List<ConfigurationEmulator> EmulatorConfigurations { get; set; }

        public ConfigurationEmulatorCollection()
        {
            EmulatorConfigurations = new List<ConfigurationEmulator>();
        }
    }
}
