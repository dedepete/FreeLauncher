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
    public class ApplicationContext
    {
        private readonly string _configurationFile;

        private readonly string _translationsDirectory;

        public Arguments ProgramArguments { get; private set; }

        public Localization ProgramLocalization { get; private set; }
        public Dictionary<string, Localization> LocalizationsList { get; private set; }

        public string McDirectory { get; private set; }
        public string McLauncher { get; private set; }
        public string McVersions { get; private set; }
        public string McLibs { get; private set; }

        public string Libraries { get; set; }

        public Configuration Configuration { get; private set; }

        public ApplicationContext(string[] args)
        {
            Libraries = string.Empty;
            ProgramArguments = new Arguments();
            ProgramLocalization = Localization.DefaultLocalization;
            LocalizationsList = new Dictionary<string, Localization>();

            Parser.Default.ParseArguments(args, ProgramArguments);
            McDirectory = ProgramArguments.WorkingDirectory ??
                                               Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                   ".minecraft\\");
            McLauncher = Path.Combine(McDirectory, "freelauncher\\");
            McVersions = Path.Combine(McDirectory, "versions\\");
            McLibs = Path.Combine(McDirectory, "libraries\\");

            _configurationFile = McLauncher + "\\configuration.json";
            _translationsDirectory = Path.Combine(Application.StartupPath + "\\freelauncher-langs\\");
            Configuration = GetConfiguration();
            LoadLocalizations();
        }

        public void SetLocalization(string localizationName)
        {
            if (string.IsNullOrEmpty(localizationName))
                ProgramLocalization = Localization.DefaultLocalization;
            else {
                ProgramLocalization = LocalizationsList[localizationName];
            }
        }

        public void SaveConfiguration()
        {
            File.WriteAllText(_configurationFile, JsonConvert.SerializeObject(Configuration, Formatting.Indented));
        }

        private Configuration GetConfiguration()
        {
            if (File.Exists(_configurationFile))
                return JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(_configurationFile));

            return new Configuration();
        }

        private void LoadLocalizations()
        {
            var langsDirectory = new DirectoryInfo(_translationsDirectory);
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
