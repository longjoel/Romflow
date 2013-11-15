using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RomulatorFrontend.Model
{
    [DataContract]
    public class ConfigurationEmulator
    {
        [DataMember]
        public string EmulatorName { get; set; }
        
        [DataMember]
        public string PathToEmulator { get; set; }

        [DataMember]
        public string PathToArtwork { get; set; }

        [DataMember]
        public string CommandLineParameters { get; set; }
        
        [DataMember]
        public string PathToRoms { get; set; }
        
        [DataMember]
        public string RomExtensionFilter { get; set; }

        [DataMember]
        public string QuitKeyCombination { get; set; }

        [DataMember]
        public string QuickSaveCombination { get; set; }

        [DataMember]
        public string QuickLoadCombination { get; set; }

        [DataMember]
        public bool IsAutoLoadAutoSave { get; set; }


        [DataMember]
        public bool Lightbox{ get; set; }

        public ConfigurationEmulator()
        {
            Lightbox = false;
            IsAutoLoadAutoSave = false;
        }
    }
}
