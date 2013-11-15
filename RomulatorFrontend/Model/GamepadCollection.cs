using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace RomulatorFrontend.Model
{
      
    public class GamepadCollection
    {
    [DllImport("winmm.dll")]
        static extern short joyGetNumDevs();

        static int GetGamepadCount()
        {
            // determine number of joysticks installed in Windows 95

            JOYINFOEX info = new JOYINFOEX();      // extended information

            info.dwFlags = 128; // buttons!
            info.dwSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(JOYINFOEX));


            Int32 dwResult;   // examine return values

            // Loop through all possible joystick IDs until we get the error
            // JOYERR_PARMS. Count the number of times we get JOYERR_NOERROR
            // indicating an installed joystick driver with a joystick currently
            // attached to the port.
            for (int i = 0; i < joyGetNumDevs(); i++)
            {
                dwResult = Gamepad.joyGetPosEx(i, ref info);
                if (dwResult == (int)JoyError.JOYERR_UNPLUGGED || dwResult == (int)JoyError.JOYERR_PARMS)
                    return i;

            }
            return -1;

        } // JoysticksConnected

        private List<Gamepad> gamePads;
        private int gpCount;

        internal GamepadCollection()
        {

            RefreshGamePadEnumeration();
        }

        public void RefreshGamePadEnumeration()
        {
            gamePads = new List<Gamepad>();
            gpCount = (int)GetGamepadCount();

            for (int i = 0; i < gpCount; i++)
            {
                gamePads.Add(new Gamepad(i));
            }
        }

        public int Count()
        {
            return gpCount;
        }

        public Gamepad this[int i]
        {
            get
            {
                return gamePads[i];
            }
        }

    }
}
