using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using CommandLine;
using Newtonsoft.Json;

namespace FreeLauncher
{
    public static class Variables
    {
        private static readonly ResourceManager resources;

        public static Arguments ProgramArguments = new Arguments();

        public static Dictionary<string, string> LocalizationsList { get; private set; }

        public static string McDirectory { get; private set; }

        public static string McLauncher { get; private set; }

        public static string McVersions { get; private set; }

        public static string McLibs { get; private set; }

        public static Configuration Configuration { get; private set; }

        public static string LastSnapshotVersion = "15w33c";

        public static string LastReleaseVersion = "1.8.8";

        public static string Libraries = string.Empty;

        static Variables()
        {
            resources = new ResourceManager("FreeLauncher.Translations.Localization", Assembly.GetExecutingAssembly());
            LocalizationsList = new Dictionary<string, string>
            {
                { "ru-RU", "Русский" },
                { "en-US", "English" },
                { "uk-UA", "Українська" }
            };
        }

        // TODO: Required non-static constructor
        public static void Init(string[] args)
        {
            Parser.Default.ParseArguments(args, ProgramArguments);
            McDirectory = ProgramArguments.WorkingDirectory ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft\\");
            McLauncher = Path.Combine(McDirectory, "freelauncher\\");
            McVersions = Path.Combine(McDirectory, "versions\\");
            McLibs = Path.Combine(McDirectory, "libraries\\");
            Configuration = GetConfiguration();
            SetLocalization(Configuration.SelectedLanguage);
        }

        public static string GetString(string name)
        {
            return resources.GetString(name);
        }

        public static void SetLocalization(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        public static void SaveConfiguration()
        {
            File.WriteAllText(McLauncher + "\\configuration.json", JsonConvert.SerializeObject(Configuration, Formatting.Indented));
        }

        private static Configuration GetConfiguration()
        {
            var configurationFile = McLauncher + "\\configuration.json";
            if (File.Exists(configurationFile))
                return JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(configurationFile));

            return new Configuration();
        }
    }
}
