using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Security.Principal;
using System.Management;
using System.IO;

using System.Diagnostics;

namespace RomulatorFrontend
{
    public static class Vars
    {
        public static string ApplicationRootPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public static string EmulatorTemplateFile
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmulatorInfo.dat");
            }
        }

        public static  string ApplicationSettingsFile
        {
            get
            {
                return System.IO.Path.Combine(
                  ApplicationRootPath,
                   "RomFlow", "settings.dat");
            }
        }

        public static string StatsDatabase
        {
            get
            {
                return System.IO.Path.Combine(
                   ApplicationRootPath,
                   "RomFlow", "stats.sqlite");
            }
        }


        public static string EmulatorRootPath
        {
            get
            {
                return System.IO.Path.Combine(
                    ApplicationRootPath,
                    "RomFlow", "Emulators");
            }
        }

        public static string RomRootPath
        {
            get
            {
                return System.IO.Path.Combine(
                     Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                     "RomFlow", "Roms");
            }
        }

        public static string ArtworkRootPath
        {
            get
            {
                return System.IO.Path.Combine(
                     Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                     "RomFlow", "Artwork");
            }
        }

        public static string TempFolderPath
        {
            get { return System.IO.Path.GetTempPath(); }
        }

        public static string ThemePath
        {
            get
            {
                return System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "RomFlow", "Themes");
            }
        }

        public static string DefaultThemePath
        {
            get
            {
                return System.IO.Path.GetFullPath(Path.Combine(
                   ApplicationRootPath, "DefaultThemes"));
            }
        }

        public static string SevenZipPath
        {
            get
            {
                return Path.Combine(
                      ApplicationRootPath, "7za.exe");
            }
        }

        public static string UnRarPath
        {
            get
            {
                return Path.Combine(
                      ApplicationRootPath, "UnRAR.exe");
            }
        }

        public static string ExecutionPath
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().Location; }
        }

        public static string DefaultShellPath
        {
            get { return System.IO.Path.Combine(Environment.GetEnvironmentVariable("WINDIR"), "explorer.exe"); }
        }



        public static bool IsAdministrator
        {
            get
            {
                WindowsIdentity cur = WindowsIdentity.GetCurrent();
                foreach (IdentityReference role in cur.Groups)
                {
                    if (role.IsValidTargetType(typeof(SecurityIdentifier)))
                    {
                        SecurityIdentifier sid = (SecurityIdentifier)role.Translate(typeof(SecurityIdentifier));
                        if (sid.IsWellKnown(WellKnownSidType.AccountAdministratorSid) || sid.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid))
                        {
                            return true;
                        }

                    }
                }

                return false;
            }
        }



        public static string ShellRegistryValue
        {
            get
            {
                var regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                if (regKey != null && regKey.GetValue("shell") != null)
                {
                    return regKey.GetValue("Shell").ToString();
                }
                return "";
            }
        }
    }
}
