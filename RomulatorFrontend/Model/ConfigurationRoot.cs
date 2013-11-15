using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
namespace RomulatorFrontend.Model
{
    [DataContract]
    public class ConfigurationRoot
    {
        [DataMember]
        public ConfigurationGamePadCollection Gamepads { get; set; }

        [DataMember]
        public ConfigurationEnvironment Environment { get; set; }


        [DataMember]
        public ConfigurationEmulatorCollection Emulators { get; set; }

       

        public ConfigurationRoot()
        {
            Gamepads = new ConfigurationGamePadCollection();
            Environment = new ConfigurationEnvironment();
            Emulators = new ConfigurationEmulatorCollection();

            
        }
    }
}
