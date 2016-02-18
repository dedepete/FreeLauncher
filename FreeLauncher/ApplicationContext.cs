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
        private readonly string _translationsDirectory;

        public Arguments ProgramArguments { get; private set; }

        public Localization ProgramLocalization { get; private set; }
        public Dictionary<string, Localization> LocalizationsList { get; private set; }

        public string MinecraftDirectory { get; private set; }
        public string LauncherDirectory { get; private set; }
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
            MinecraftDirectory = ProgramArguments.WorkingDirectory ??
                                               Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                   ".minecraft\\");
            LauncherDirectory = Path.Combine(MinecraftDirectory, "freelauncher\\");
            McVersions = Path.Combine(MinecraftDirectory, "versions\\");
            McLibs = Path.Combine(MinecraftDirectory, "libraries\\");

            _translationsDirectory = Path.Combine(Application.StartupPath + "\\freelauncher-langs\\");
            Configuration = Configuration.LoadFromFile(LauncherDirectory + "\\configuration.json");
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
