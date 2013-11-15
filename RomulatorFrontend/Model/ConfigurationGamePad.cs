using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RomulatorFrontend.Model
{
    [DataContract]
    public class ConfigurationGamePad
    {
        [DataMember]
        public int PadIndex { get; set; }

        [DataMember]
        public string NavigateUpButton { get; set; }
        
        [DataMember]
        public string NavigateDownButton { get; set; }
        
        [DataMember]
        public string NavigateLeftButton { get; set; }
        
        [DataMember]
        public string NavigateRightButton { get; set; }
        
        [DataMember]
        public string NavigateForwardButton { get; set; }
        
        [DataMember]
        public string NavigateBackButton { get; set; }

        [DataMember]
        public string QuitCombo { get; set; }
        
        [DataMember]
        public string QuickSaveCombo { get; set; }
        
        [DataMember]
        public string QuickLoadCombo { get; set; }

        public ConfigurationGamePad()
        {
            PadIndex = -1;
            NavigateBackButton = "";
            NavigateDownButton = "";
            NavigateForwardButton = "";
            NavigateLeftButton = "";
            NavigateRightButton = "";
            NavigateUpButton = "";
        }
    }
}
