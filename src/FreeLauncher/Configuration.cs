using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FreeLauncher
{
    public class Configuration
    {
        private readonly string _configurationFile;

        public ApplicationArguments Arguments { get; private set; }

        public Localization Localization { get; private set; }
        public Dictionary<string, Localization> LocalizationsList { get; private set; }

        public string McDirectory { get; private set; }
        public string McLauncher { get; private set; }
        public string McVersions { get; private set; }
        public string McLibs { get; private set; }

        public ApplicationConfiguration ApplicationConfiguration { get; private set; }

        public Configuration(string[] args)
        {
            Arguments = new ApplicationArguments();
            Localization = new Localization();
            LocalizationsList = new Dictionary<string, Localization>();
            Parser.Default.ParseArguments(args, Arguments);
            McDirectory = Arguments.WorkingDirectory ??
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    ".minecraft");
            McLauncher = Path.Combine(McDirectory, "freelauncher");
            McVersions = Path.Combine(McDirectory, "versions");
            McLibs = Path.Combine(McDirectory, "libraries");

            _configurationFile = McLauncher + @"\configuration.json";
            ApplicationConfiguration = GetConfiguration();
            LoadLocalization();
        }

        public void SetLocalization(string localizationName)
        {
            Localization = string.IsNullOrEmpty(localizationName) ? new Localization() : LocalizationsList[localizationName];
        }

        public void SaveConfiguration()
        {
            File.WriteAllText(_configurationFile, JsonConvert.SerializeObject(ApplicationConfiguration, Formatting.Indented));
        }

        private ApplicationConfiguration GetConfiguration()
        {
            return File.Exists(_configurationFile)
                ? JsonConvert.DeserializeObject<ApplicationConfiguration>(File.ReadAllText(_configurationFile))
                : new ApplicationConfiguration {
                    SelectedLanguage =
                        CultureInfo.InstalledUICulture.TwoLetterISOLanguageName == "ru" ? "ru-RU" : "en-UK"
                };
        }

        private void LoadLocalization()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string s = new StreamReader(assembly.GetManifestResourceStream("FreeLauncher.Translations.en_UK.lang.json")).ReadToEnd();
            LocalizationsList.Add(JObject.Parse(s)["LanguageTag"].ToString(), JsonConvert.DeserializeObject<Localization>(s));
            if (ApplicationConfiguration.SelectedLanguage == "en-UK") {
                Localization = LocalizationsList["en-UK"];
            }
            var langsDirectory = new DirectoryInfo(Path.Combine(Application.StartupPath + @"\freelauncher-langs\"));
            if (!langsDirectory.Exists) {
                return;
            }
            foreach (var local in langsDirectory
                .GetFiles("*.json", SearchOption.AllDirectories)
                .Where(file => file.Name.Contains("lang"))
                .Select(file => JObject.Parse(File.ReadAllText(file.FullName)))
                .Select(jo => JsonConvert.DeserializeObject<Localization>(jo.ToString()))) {
                if (LocalizationsList.ContainsKey(local.LanguageTag)) {
                    continue;
                }
                LocalizationsList.Add(local.LanguageTag, local);
                if (local.LanguageTag == ApplicationConfiguration.SelectedLanguage) {
                    Localization = local;
                }
            }
        }
    }
}
