namespace FreeLauncher
{
    public class ApplicationConfiguration
    {
        public bool SkipAssetsDownload { get; set; }
        public bool EnableGameLogging { get; set; }
        public bool CloseTabAfterSuccessfulExitCode { get; set; }
        public string SelectedLanguage { get; set; } = "ru-RU";
    }
}
