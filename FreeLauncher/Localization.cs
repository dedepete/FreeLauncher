using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace FreeLauncher
{
    public class Localization
    {
        private static Localization _defaultLocalization;

        public static Localization DefaultLocalization
        {
            get {
                if (_defaultLocalization == null) {
                    var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("FreeLauncher.Translations.lang.ru_RU.json");
                    using (var sr = new StreamReader(stream)) {
                        var content = sr.ReadToEnd();
                        _defaultLocalization = JsonConvert.DeserializeObject<Localization>(content);
                    }
                }

                return _defaultLocalization;
            }
        }

        protected Localization() { }

        public string Name { get; set; }
        public string LanguageTag { get; set; }
        public string Authors { get; set; }

        #region LauncherForm

        #region Tabs

        public string NewsTabText { get; set; }
        public string ConsoleTabText { get; set; }
        public string ManageVersionsTabText { get; set; }
        public string AboutTabText { get; set; }
        public string LicensesTabText { get; set; }
        public string SettingsTabText { get; set; }

        #endregion

        #region Main Controls

        public string LaunchButtonText { get; set; }
        public string AddProfileButtonText { get; set; }
        public string EditProfileButtonText { get; set; }

        #endregion

        #region About Tab

        public string DevInfo { get; set; }
        public string GratitudesText { get; set; }
        public string GratitudesDescription { get; set; }
        public string PartnersText { get; set; }
        public string MCofflineDescription { get; set; }
        public string CopyrightInfo { get; set; }

        #endregion

        #region Settings Tab

        public string EnableMinecraftUpdateAlertsText { get; set; }
        public string EnableMinecraftLoggingText { get; set; }
        public string UseGamePrefixText { get; set; }
        public string CloseGameOutputText { get; set; }

        #endregion

        public string Launch { get; set; }
        public string OpenLocation { get; set; }
        public string DeleteVersion { get; set; }
        public string DeleteConfirmationTitle { get; set; }
        public string DeleteConfirmationText { get; set; }
        public string ReadyToLaunch { get; set; }
        public string ReadyToDownload { get; set; }
        public string EditingProfileTitle { get; set; }
        public string ProfileAlreadyExistsErrorText { get; set; }
        public string ProfileDeleteConfirmationText { get; set; }
        public string AddingProfileTitle { get; set; }
        public string CheckingVersionAvailability { get; set; }
        public string CheckingLibraries { get; set; }
        public string GameOutput { get; set; }
        public string KillProcess { get; set; }
        public string Independent { get; set; }

        #endregion

        #region ProfileForm

        #region Main Settings

        public string ProfileName { get; set; }
        public string WorkingDirectory { get; set; }
        public string WindowResolution { get; set; }
        public string ActionAfterLaunch { get; set; }
        public string Autoconnect { get; set; }

        #endregion

        #region Version Selection

        public string Snapshots { get; set; }
        public string Beta { get; set; }
        public string Alpha { get; set; }
        public string Other { get; set; }
        public string UseLatestVersion { get; set; }

        #endregion

        #region Java Options

        public string JavaExecutable { get; set; }
        public string JavaFlags { get; set; }

        #endregion

        public string OpenDirectory { get; set; }

        public string JavaDetectionFailed { get; set; }

        #endregion

        #region UsersForm

        public string AddNewUserBox { get; set; }
        public string Nickname { get; set; }
        public string LicenseQuestion { get; set; }
        public string Password { get; set; }
        public string AddNewUserButton { get; set; }
        public string RemoveSelectedUser { get; set; }
        public string IncorrectLoginOrPassword { get; set; }
        public string PleaseWait { get; set; }

        #endregion

        public string Error { get; set; }
        public string Cancel { get; set; }
        public string Close { get; set; }
        public string Save { get; set; }
    }
}
