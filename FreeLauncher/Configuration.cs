using System.IO;
using Newtonsoft.Json;

namespace FreeLauncher
{
    public class Configuration
    {
        private static string _configurationFile;

        public bool EnableGameLogging = true;
        public bool ShowGamePrefix = true;
        public bool CloseTabAfterSuccessfulExitCode = false;
        public string SelectedLanguage = "ru-RU";

        protected Configuration() { }

        public static Configuration LoadFromFile(string filePath)
        {
            _configurationFile = filePath;
            if (File.Exists(filePath))
                return JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(filePath));

            return new Configuration();
        }

        public void Save()
        {
            File.WriteAllText(_configurationFile, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
