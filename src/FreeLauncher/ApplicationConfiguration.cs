namespace FreeLauncher
{
    public class ApplicationConfiguration
    {
        public bool CheckLauncherUpdates { get; set; } = true;
        public bool SkipAssetsDownload { get; set; }
        public bool EnableGameLogging { get; set; }
        public bool CloseTabAfterSuccessfulExitCode { get; set; } = true;
        public string SelectedLanguage { get; set; } = "ru_RU";
    }
}
