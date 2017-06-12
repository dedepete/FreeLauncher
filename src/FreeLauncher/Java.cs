using System;
using Microsoft.Win32;

namespace FreeLauncher
{
    internal static class Java
    {
        public static string JavaExecutable
            => GetJavaInstallationPath() == null ? null : string.Format("{0}\\bin\\java.exe", GetJavaInstallationPath());

        public static string JavaInstallationPath => GetJavaInstallationPath();

        private static bool _isNotWow6432Installation;

        public static string JavaBitInstallation
        {
            get {
                if (JavaExecutable == null) {
                    return "null";
                }
                if ((_isNotWow6432Installation && !Environment.Is64BitOperatingSystem) ||
                    (!_isNotWow6432Installation && Environment.Is64BitOperatingSystem)) {
                    return "32";
                }
                if (_isNotWow6432Installation && Environment.Is64BitOperatingSystem) {
                    return "64";
                }
                return "null";
            }
        }

        private static string GetJavaInstallationPath()
        {
            _isNotWow6432Installation = true;
            string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment";
            while (true) {
                using (RegistryKey baseKey =
                    RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey)) {
                    if (baseKey == null) {
                        if (javaKey == "SOFTWARE\\Wow6432Node\\JavaSoft\\Java Runtime Environment") {
                            break;
                        }
                        _isNotWow6432Installation = false;
                        javaKey = "SOFTWARE\\Wow6432Node\\JavaSoft\\Java Runtime Environment";
                        continue;
                    }
                    string currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                    using (RegistryKey homeKey = baseKey.OpenSubKey(currentVersion))
                        if (homeKey != null) {
                            return homeKey.GetValue("JavaHome").ToString();
                        }
                }
                break;
            }
            return null;
        }
    }
}