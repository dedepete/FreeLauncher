namespace FreeLauncher
{
    public class Configuration
    {
        public bool SkipAssetsDownload { get; set; }
        public bool EnableGameLogging { get; set; } = true;
        public bool CloseTabAfterSuccessfulExitCode { get; set; }
        public string SelectedLanguage { get; set; } = "ru-RU";
    }
}
