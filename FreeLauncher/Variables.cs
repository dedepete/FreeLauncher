using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FreeLauncher
{
    public static class Variables
    {
        private static string configurationFile;

        public static Arguments ProgramArguments { get; private set; }

        public static Localization ProgramLocalization { get; private set; }
        public static Dictionary<string, Localization> LocalizationsList { get; private set; }

        public static string McDirectory { get; private set; }
        public static string McLauncher { get; private set; }
        public static string McVersions { get; private set; }
        public static string McLibs { get; private set; }

        public static string Libraries { get; set; }

        public static Configuration Configuration { get; private set; }

        static Variables()
        {
            Libraries = string.Empty;
            ProgramArguments = new Arguments();
            ProgramLocalization = new Localization();
            LocalizationsList = new Dictionary<string, Localization>();
        }

        public static void Init(string[] args)
        {
            Parser.Default.ParseArguments(args, ProgramArguments);
            McDirectory = ProgramArguments.WorkingDirectory ??
                                               Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                   ".minecraft\\");
            McLauncher = Path.Combine(McDirectory, "freelauncher\\");
            McVersions = Path.Combine(McDirectory, "versions\\");
            McLibs = Path.Combine(McDirectory, "libraries\\");

            configurationFile = McLauncher + "\\configuration.json";
            Configuration = GetConfiguration();
            LoadLocalization();
        }

        public static void SetLocalization(string localizationName)
        {
            if (string.IsNullOrEmpty(localizationName))
                ProgramLocalization = new Localization();
            else {
                ProgramLocalization = LocalizationsList[localizationName];
            }
        }

        public static void SaveConfiguration()
        {
            File.WriteAllText(configurationFile, JsonConvert.SerializeObject(Configuration, Formatting.Indented));
        }

        private static Configuration GetConfiguration()
        {
            if (File.Exists(configurationFile))
                return JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(configurationFile));

            return new Configuration();
        }

        private static void LoadLocalization()
        {
            var langsDirectory = new DirectoryInfo(Path.Combine(Application.StartupPath + "\\freelauncher-langs\\"));
            if (langsDirectory.Exists)
                foreach (var local in langsDirectory
                            .GetFiles()
                            .Where(file => file.Name.Contains("lang"))
                            .Select(file => JObject.Parse(File.ReadAllText(file.FullName)))
                            .Select(jo => JsonConvert.DeserializeObject<Localization>(jo.ToString()))) {
                    LocalizationsList.Add(local.LanguageTag, local);
                    if (local.LanguageTag == Configuration.SelectedLanguage) {
                        ProgramLocalization = local;
                    }
                }
        }
    }
}
