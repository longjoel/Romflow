using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Collections;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

using System.Text;

namespace RainTheme
{
    [DataContract]
    class EmulatorJSON
    {
        [DataMember]
        public string Emulator { get; set; }
       
        [DataMember]
        public List<string> Roms { get; set; }
        public EmulatorJSON() { Emulator = ""; Roms = new List<string>(); }

        public static EmulatorJSON[] DeserializeToEmulator(string jsonString)
        {
            var sr = new StringReader(jsonString);
           
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
            {
                DataContractJsonSerializer serializer =
                        new DataContractJsonSerializer(typeof(EmulatorJSON[]));

                return (EmulatorJSON[])serializer.ReadObject(ms);
            }
        }
    }
}
