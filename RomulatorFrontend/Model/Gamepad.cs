using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace RomulatorFrontend.Model
{

    public enum DPadEnum : ushort
    {
        None = ushort.MaxValue,
        Up = 0,
        Down = 18000,
        Left = 27000,
        Right = 9000,
        UpLeft = 31500,
        UpRight = 4500,
        DownLeft = 22500,
        DownRight = 13500

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Joycaps
    {
        /// <summary>
        ///     Manufacturer identifier. Manufacturer identifiers are defined in Manufacturer and Product Identifiers.
        /// </summary>
        //[CLSCompliant(false)]
        public ushort WMid;
        /// <summary>
        ///     Product identifier. Product identifiers are defined in Manufacturer and Product Identifiers.
        /// </summary>
        //[CLSCompliant(false)]
        public ushort WPid;
        /// <summary>
        ///     Null-terminated string containing the joystick product name.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public String SzPname;
        /// <summary>
        ///     Minimum X-coordinate.
        /// </summary>
        public Int32 WXmin;
        /// <summary>
        ///     Maximum X-coordinate.
        /// </summary>
        public Int32 WXmax;
        /// <summary>
        /// Minimum Y-coordinate.
        /// </summary>
        public Int32 WYmin;
        /// <summary>
        ///     Maximum Y-coordinate.
        /// </summary>
        public Int32 WYmax;
        /// <summary>
        ///     Minimum Z-coordinate.
        /// </summary>
        public Int32 WZmin;
        /// <summary>
        ///     Maximum Z-coordinate.
        /// </summary>
        public Int32 WZmax;
        /// <summary>
        ///     Number of joystick buttons.
        /// </summary>
        public Int32 WNumButtons;
        /// <summary>
        ///     Smallest polling frequency supported when captured by the  function.
        /// </summary>
        public Int32 WPeriodMin;

        public Int32 WPeriodMax;
        /// <summary>
        ///     Minimum rudder value. The rudder is a fourth axis of movement.
        /// </summary>
        public Int32 WRmin;
        /// <summary>
        ///     Maximum rudder value. The rudder is a fourth axis of movement.
        /// </summary>
        public Int32 WRmax;
        /// <summary>
        ///     Minimum u-coordinate (fifth axis) values.
        /// </summary>
        public Int32 WUmin;
        /// <summary>
        ///     Maximum u-coordinate (fifth axis) values.
        /// </summary>
        public Int32 WUmax;
        /// <summary>
        ///     Minimum v-coordinate (sixth axis) values.
        /// </summary>
        public Int32 WVmin;
        /// <summary>
        ///     Maximum v-coordinate (sixth axis) values.
        /// </summary>
        public Int32 WVmax;
        /// <summary>
        ///     Joystick capabilities The following flags define individual capabilities that a joystick might have:
        /// </summary>

        public Int32 WCaps;
        /// <summary>
        ///     Maximum number of axes supported by the joystick.
        /// </summary>
        public Int32 WMaxAxes;
        /// <summary>
        ///     Number of axes currently in use by the joystick.
        /// </summary>
        public Int32 WNumAxes;
        /// <summary>
        ///     Maximum number of buttons supported by the joystick.
        /// </summary>
        public Int32 WMaxButtons;
        /// <summary>
        ///     Null-terminated string containing the registry key for the joystick.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public String SzRegKey;
        /// <summary>
        ///     Null-terminated string identifying the joystick driver OEM.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public String SzOemvxD;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct JOYINFOEX
    {
        public int dwSize;
        public int dwFlags;
        public int dwXpos;
        public int dwYpos;
        public int dwZpos;
        public int dwRpos;
        public int dwUpos;
        public int dwVpos;
        public int dwButtons;
        public int dwButtonNumber;
        public int dwPOV;
        public int dwReserved1;
        public int dwReserved2;
    }

    enum JoyError : int
    {
        JOYERR_BASE = 160,
        JOYERR_PARMS = (JOYERR_BASE + 5),
        JOYERR_UNPLUGGED = (JOYERR_BASE + 7),
        MMSYSERR_BASE = 0,
        MMSYSERR_BADDEVICEID = (MMSYSERR_BASE + 2),
        MMSYSERR_INVALPARAM = (MMSYSERR_BASE + 11)
    }
    public class Gamepad
    {
        [DllImport("winmm.dll")]
        internal static extern int joyGetPosEx(int uJoyID, ref JOYINFOEX pji);

        [DllImport("winmm.dll")]
        internal static extern Int32 joyGetDevCaps(int uJoyID, ref Joycaps pjc, Int32 cbjc);

        int padId;

        Joycaps caps;

        internal Gamepad(int joyId)
        {
            padId = joyId;

            caps = new Joycaps();

            joyGetDevCaps(joyId, ref caps, System.Runtime.InteropServices.Marshal.SizeOf(typeof(Joycaps)));


        }

        public DPadEnum DirectionalPad
        {
            get
            {
                if ((caps.WCaps & 16) == 16)
                {
                    JOYINFOEX state = new JOYINFOEX();
                    state.dwFlags = 64; // POV
                    state.dwSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(JOYINFOEX));
                    joyGetPosEx(padId, ref state);
                    return (DPadEnum)state.dwPOV;
                }
                else
                {
                    JOYINFOEX state = new JOYINFOEX();
                    state.dwFlags = 3; // POV
                    state.dwSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(JOYINFOEX));
                    joyGetPosEx(padId, ref state);

                    if (state.dwXpos == caps.WXmin)
                    {
                        return DPadEnum.Left;

                    }
                    else
                        if (state.dwXpos == caps.WXmax)
                        {
                            return DPadEnum.Right;

                        }
                        else
                            if (state.dwXpos == caps.WXmin)
                            {
                                return DPadEnum.Left;

                            }
                            else
                                if (state.dwYpos == caps.WYmin)
                                {
                                    return DPadEnum.Up;

                                }
                                else
                                    if (state.dwYpos == caps.WYmax)
                                    {
                                        return DPadEnum.Down;

                                    }



                    return DPadEnum.None;
                }


            }
        }

        public bool[] Buttons
        {
            get
            {
                JOYINFOEX state = new JOYINFOEX();
                state.dwFlags = 128; // buttons!
                state.dwSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(JOYINFOEX));
                joyGetPosEx(padId, ref state);

                var bList = new bool[16];

                for (int i = 0; i < 16; i++)
                {
                    var mask = (int)Math.Pow(2, i);

                    if ((state.dwButtons & mask) == mask)
                        bList[i] = true;
                    else
                        bList[i] = false;
                }

                return bList;
            }
        }

        public override string ToString()
        {

            var pressedButtons = new List<int>();
            for (int i = 0; i < Buttons.Count(); i++)
            {
                if (Buttons[i]) pressedButtons.Add(i);
            }
            if (this.DirectionalPad != DPadEnum.None && pressedButtons.Count != 0)
            {
                return this.DirectionalPad.ToString() + "+" + string.Join("+", pressedButtons);
            }
            else if (pressedButtons.Count == 0)
            {
                return this.DirectionalPad.ToString();
            }
            else
            {
                return string.Join("+", pressedButtons);
            }
        }

    }
}
