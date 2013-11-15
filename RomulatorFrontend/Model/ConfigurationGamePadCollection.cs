using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RomulatorFrontend.Model
{
    [DataContract]
    public class ConfigurationGamePadCollection
    {
        [DataMember]
        public List<ConfigurationGamePad> GamePadInformation { get; set; }

        public ConfigurationGamePadCollection()
        {
            GamePadInformation = new List<ConfigurationGamePad>();
        }
    }
}
