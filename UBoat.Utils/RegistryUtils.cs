using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace UBoat.Utils
{
    public static class RegistryUtils
    {
        public static void AddWindowsStartupItem(string name, string path)
        {
            RegistryKey rkStartup = zGetWindowsStartupKey();
            rkStartup.SetValue(name, path);
        }

        public static void RemoveWindowsStartupItem(string name)
        {
            RegistryKey rkStartup = zGetWindowsStartupKey();
            rkStartup.DeleteValue(name, false);
        }

        public static string GetWindowsStartupItem(string name)
        {
            RegistryKey rkStartup = zGetWindowsStartupKey();
            object value = rkStartup.GetValue(name);
            return value != null ? value.ToString() : null;
        }

        public static IEBrowserMode? GetApplicationIEBrowserMode()
        {
            RegistryKey rkIEMode = zGetApplicationIEBrowserModeKey();
            if (rkIEMode != null)
            {
                string exeName = zGetApplicationName();
                object value = rkIEMode.GetValue(exeName);
                if (value != null)
                {
                    return (IEBrowserMode)value;
                }
            }
            return null;
        }

        public static IEBrowserMode? GetInstalledIEBrowserVersion()
        {
            try
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "mshtml.dll"));
                if (versionInfo != null)
                {
                    switch (versionInfo.FileMajorPart)
                    {
                        case 11:
                            return IEBrowserMode.IE11;
                        case 10:
                            return IEBrowserMode.IE10;
                        case 9:
                            return IEBrowserMode.IE9;
                        case 8:
                            return IEBrowserMode.IE8;
                        case 7:
                            return IEBrowserMode.IE7;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SetApplicationIEBrowserMode(IEBrowserMode mode)
        {
            RegistryKey rkIEMode = zGetApplicationIEBrowserModeKey();
            if (rkIEMode != null)
            {
                string exeName = zGetApplicationName();
                rkIEMode.SetValue(exeName, (int)mode, RegistryValueKind.DWord);
            }
        }
        public static void RemoveApplicationIEBrowserMode()
        {
            RegistryKey rkIEMode = zGetApplicationIEBrowserModeKey();
            if (rkIEMode != null)
            {
                string exeName = zGetApplicationName();
                rkIEMode.DeleteValue(exeName, false);
            }
        }

        private static RegistryKey zGetWindowsStartupKey()
        {
            return Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }

        private static RegistryKey zGetApplicationIEBrowserModeKey()
        {
            return Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
        }

        private static string zGetApplicationName()
        {
            string exePath;
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 0)
            {
                exePath = commandLineArgs[0];
            }
            else
            {
                exePath = Assembly.GetEntryAssembly().Location;
            }
            return Path.GetFileName(exePath);
        }
    }

    public enum IEBrowserMode
    {
        ForceIE11 = 11001,
        IE11 = 11000,
        ForceIE10 = 10001,
        IE10 = 10000,
        ForceIE9 = 9999,
        IE9 = 9000,
        ForceIE8 = 8888,
        IE8 = 8000,
        IE7 = 7000
    }
}
