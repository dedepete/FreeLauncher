using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using CommandLine;

namespace FreeLauncher
{
    public static class Variables
    {
        private static readonly ResourceManager strings;

        public static Arguments ProgramArguments = new Arguments();

        //public static Localization ProgramLocalization = new Localization();

        public static Dictionary<string, string> LocalizationsList = new Dictionary<string, string>
        {
            { "ru-RU", "Русский" },
            { "en-US", "English" },
            { "uk-UA", "Українська" }
        };

        public static string McDirectory = ProgramArguments.WorkingDirectory ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft\\");
        public static string McLauncher = Path.Combine(McDirectory, "freelauncher\\");
        public static string McVersions = Path.Combine(McDirectory, "versions\\");
        public static string McLibs = Path.Combine(McDirectory, "libraries\\");

        public static string LastSnapshotVersion = "15w33c";
        public static string LastReleaseVersion = "1.8.8";

        public static string Libraries = string.Empty;

        static Variables()
        {
            strings = new ResourceManager("FreeLauncher.Translations.Localization", Assembly.GetExecutingAssembly());
        }

        public static string GetString(string name)
        {
            return strings.GetString(name);
        }

        public static void SetLocalization(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }
    }

    public class Arguments
    {
        [Option('d', "working-directory")]
        public string WorkingDirectory { get; set; }
        [Option("not-a-standalone")]
        public bool NotAStandalone { get; set; }
    }
}
