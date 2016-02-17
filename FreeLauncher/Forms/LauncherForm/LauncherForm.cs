using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using dotMCLauncher.Core;
using dotMCLauncher.YaDra4il;
using Ionic.Zip;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using Version = dotMCLauncher.Core.Version;

namespace FreeLauncher.Forms
{
    public partial class LauncherForm : RadForm
    {
        #region Variables

        private ProfileManager _profileManager;
        private Profile _selectedProfile;
        private UserManager _userManager;
        private User _selectedUser;
        private readonly Configuration _cfg;
        private string _versionToLaunch;
        private bool _restoreVersion;

        private int StatusBarValue
        {
            get { return StatusBar.Value1; }
            set { SetStatusBarValue(value); }
        }

        private int StatusBarMaxValue
        {
            get { return StatusBar.Maximum; }
            set { SetStatusBarMaxValue(value); }
        }

        private bool StatusBarVisible
        {
            get { return StatusBar.Visible; }
            set { SetStatusBarVisibility(value); }
        }

        private bool BlockControls
        {
            set {
                LaunchButton.Enabled = !value;
                profilesDropDownBox.Enabled = !value;
                DeleteProfileButton.Enabled = !value && (_profileManager.Profiles.Count > 1);
                EditProfile.Enabled = !value;
                AddProfile.Enabled = !value;
                NicknameDropDownList.Enabled = !value;
            }
        }

        private void SetStatusBarValue(int i)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<int>(SetStatusBarValue), i);
            } else {
                StatusBar.Value1 = i;
            }
        }

        private void SetStatusBarMaxValue(int i)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<int>(SetStatusBarMaxValue), i);
            } else {
                StatusBar.Maximum = i;
            }
        }

        private void SetStatusBarVisibility(bool b)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<bool>(SetStatusBarVisibility), b);
            } else {
                StatusBar.Visible = b;
            }
        }

        #endregion

        public LauncherForm()
        {
            InitializeComponent();
            // Loading configuration
            _cfg = Variables.Configuration;
            EnableMinecraftLogging.Checked = _cfg.EnableGameLogging;
            UseGamePrefix.Checked = _cfg.ShowGamePrefix;
            CloseGameOutput.Checked = _cfg.CloseTabAfterSuccessfulExitCode;
            LoadLocalization();
            //
            Text = ProductName + " " + ProductVersion;
            AboutVersion.Text = ProductVersion;
            AppendLog($"Application: {ProductName} v.{ProductVersion}" +
                      (!Variables.ProgramArguments.NotAStandalone ? "-standalone" : string.Empty));
            AppendLog($"Application language: {Variables.ProgramLocalization.Name}({Variables.ProgramLocalization.LanguageTag})");
            AppendLog("==============");
            AppendLog("System info:");
            AppendLog($"Operating system: {Environment.OSVersion}({new ComputerInfo().OSFullName})");
            AppendLog($"Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem}");
            AppendLog($"Java path: \"{Java.JavaInstallationPath}\" ({Java.JavaBitInstallation}-bit)");
            AppendLog("==============");
            if (Variables.LocalizationsList.Count != 0) {
                foreach (KeyValuePair<string, Localization> keyvalue in Variables.LocalizationsList) {
                    LangDropDownList.Items.Add(new RadListDataItem {
                        Text = $"{keyvalue.Value.Name} ({keyvalue.Key})",
                        Tag = keyvalue.Key
                    });
                }
                foreach (RadListDataItem item in LangDropDownList.Items.Where(a => a.Tag.ToString() == _cfg.SelectedLanguage)) {
                    LangDropDownList.SelectedItem = item;
                }
            } else {
                LangDropDownList.Enabled = false;
            }
            if (!Directory.Exists(Variables.McDirectory)) {
                Directory.CreateDirectory(Variables.McDirectory);
            }
            if (!Directory.Exists(Variables.McLauncher)) {
                Directory.CreateDirectory(Variables.McLauncher);
            }
            Focus();
            if (!Variables.ProgramArguments.NotAStandalone) {
                UpdateVersions();
            }
            UpdateProfileList();
            UpdateVersionListView();
            UpdateUserList();
        }

        private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cfg.EnableGameLogging = EnableMinecraftLogging.Checked;
            _cfg.ShowGamePrefix = UseGamePrefix.Checked;
            _cfg.CloseTabAfterSuccessfulExitCode = CloseGameOutput.Checked;
        }

        private void profilesDropDownBox_SelectedIndexChanged(object sender,
            PositionChangedEventArgs e)
        {
            if (profilesDropDownBox.SelectedItem == null) {
                return;
            }
            _profileManager.LastUsedProfile = profilesDropDownBox.SelectedItem.Text;
            _selectedProfile = _profileManager.Profiles[profilesDropDownBox.SelectedItem.Text];
            string path = Path.Combine(Variables.McVersions,
                _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile) + "\\");
            string state = Variables.ProgramLocalization.ReadyToLaunch;
            if (!File.Exists(string.Format("{0}/{1}.json", path, _selectedProfile.SelectedVersion ??
                                                                 GetLatestVersion(_selectedProfile)))) {
                state = Variables.ProgramLocalization.ReadyToDownload;
            }
            SelectedVersion.Text = string.Format(state, (_selectedProfile.SelectedVersion ??
                                                         GetLatestVersion(_selectedProfile)));
        }

        private void NicknameDropDownList_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
        {
            if (NicknameDropDownList.SelectedItem == null) {
                return;
            }
            _userManager.SelectedUsername = NicknameDropDownList.SelectedItem.Text;
            _selectedUser = _userManager.Accounts[NicknameDropDownList.SelectedItem.Text];
            SaveUsers();
        }

        private void EditProfile_Click(object sender, EventArgs e)
        {
            ProfileForm pf = new ProfileForm(_selectedProfile) {
                Text = Variables.ProgramLocalization.EditingProfileTitle
            };
            pf.ShowDialog();
            if (pf.DialogResult == DialogResult.OK) {
                _profileManager.Profiles.Remove(_profileManager.LastUsedProfile);
                if (_profileManager.Profiles.ContainsKey(pf.CurrentProfile.ProfileName)) {
                    RadMessageBox.Show(Variables.ProgramLocalization.ProfileAlreadyExistsErrorText,
                        Variables.ProgramLocalization.Error,
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                    UpdateProfileList();
                    return;
                }
                _profileManager.Profiles.Add(pf.CurrentProfile.ProfileName, pf.CurrentProfile);
                _profileManager.LastUsedProfile = pf.CurrentProfile.ProfileName;
            }
            SaveProfiles();
            UpdateProfileList();
        }

        private void AddProfile_Click(object sender, EventArgs e)
        {
            Profile editedProfile = Profile.ParseProfile(_selectedProfile.ToString());
            editedProfile.ProfileName = "Copy of '" + _selectedProfile.ProfileName + "'(" +
                                        DateTime.Now.ToString("HH:mm:ss") + ")";
            ProfileForm pf = new ProfileForm(editedProfile) {Text = Variables.ProgramLocalization.AddingProfileTitle};
            pf.ShowDialog();
            if (pf.DialogResult == DialogResult.OK) {
                if (_profileManager.Profiles.ContainsKey(editedProfile.ProfileName)) {
                    RadMessageBox.Show(Variables.ProgramLocalization.ProfileAlreadyExistsErrorText,
                        Variables.ProgramLocalization.Error,
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }
                _profileManager.Profiles.Add(editedProfile.ProfileName, editedProfile);
                _profileManager.LastUsedProfile = pf.CurrentProfile.ProfileName;
            }
            SaveProfiles();
            UpdateProfileList();
        }

        private void DeleteProfileButton_Click(object sender, EventArgs e)
        {
            DialogResult dr =
                RadMessageBox.Show(
                    string.Format(Variables.ProgramLocalization.ProfileDeleteConfirmationText,
                        _profileManager.LastUsedProfile), Variables.ProgramLocalization.DeleteConfirmationTitle,
                    MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dr != DialogResult.Yes) {
                return;
            }
            _profileManager.Profiles.Remove(_profileManager.LastUsedProfile);
            _profileManager.LastUsedProfile = _profileManager.Profiles.FirstOrDefault().Key;
            SaveProfiles();
            UpdateProfileList();
        }

        private void ManageUsersButton_Click(object sender, EventArgs e)
        {
            new UsersForm().ShowDialog();
            UpdateUserList();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            BlockControls = true;
            if (string.IsNullOrWhiteSpace(NicknameDropDownList.Text)) {
                NicknameDropDownList.Text = $"Player{DateTime.Now.ToString("hhmmss")}";
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += delegate {
                CheckVersionAvailability();
                UpdateVersionListView();
            };
            bgw.RunWorkerCompleted += delegate {
                BackgroundWorker bgw1 = new BackgroundWorker();
                bgw1.DoWork += delegate { CheckLibraries(); };
                bgw1.RunWorkerCompleted += delegate {
                    BackgroundWorker bgw2 = new BackgroundWorker();
                    bgw2.DoWork += delegate { CheckGameResources(); };
                    bgw2.RunWorkerCompleted += delegate {
                        if (!_userManager.Accounts.ContainsKey(NicknameDropDownList.Text)) {
                            User user = new User {
                                Username = NicknameDropDownList.Text,
                                Type = "offline"
                            };
                            _userManager.Accounts.Add(user.Username, user);
                            _selectedUser = user;
                        } else {
                            _selectedUser = _userManager.Accounts[NicknameDropDownList.Text];
                            if (_selectedUser.Type != "offline") {
                                AuthManager am = new AuthManager {
                                    SessionToken = _selectedUser.SessionToken,
                                    Uuid = _selectedUser.Uuid
                                };
                                bool check = am.CheckSessionToken();
                                if (!check) {
                                    RadMessageBox.Show(
                                        "Session token is not valid. Please, head up to user manager and re-add your account.",
                                        Variables.ProgramLocalization.Error, MessageBoxButtons.OK,
                                        RadMessageIcon.Exclamation);
                                    User user = new User {
                                        Username = NicknameDropDownList.Text,
                                        Type = "offline"
                                    };
                                    _selectedUser = user;
                                } else {
                                    Refresh refresh = new Refresh(_selectedUser.SessionToken,
                                        _selectedUser.AccessToken);
                                    _selectedUser.UserProperties = (JArray) refresh.user["properties"];
                                    _selectedUser.SessionToken = refresh.accessToken;
                                    _userManager.Accounts[NicknameDropDownList.Text] = _selectedUser;
                                }
                            }
                        }
                        _userManager.SelectedUsername = _selectedUser.Username;
                        SaveUsers();
                        UpdateUserList();
                        Version selectedVersion = Version.ParseVersion(
                            new DirectoryInfo(Variables.McVersions + (_versionToLaunch ?? (
                                (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile))))));
                        JObject properties = new JObject {
                            new JProperty("freelauncher", new JArray("cheeki_breeki_iv_damke"))
                        };
                        if (_selectedProfile.FastConnectionSettigs != null) {
                            selectedVersion.ArgumentCollection.Add("server",
                                _selectedProfile.FastConnectionSettigs.ServerIP);
                            selectedVersion.ArgumentCollection.Add("port",
                                _selectedProfile.FastConnectionSettigs.ServerPort.ToString());
                        }
                        string javaArgumentsTemp = _selectedProfile.JavaArguments == null
                            ? string.Empty
                            : _selectedProfile.JavaArguments + " ";
                        if (_selectedProfile.WorkingDirectory != null &&
                            !Directory.Exists(_selectedProfile.WorkingDirectory)) {
                            Directory.CreateDirectory(_selectedProfile.WorkingDirectory);
                        }
                        ProcessStartInfo proc = new ProcessStartInfo {
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                            FileName = _selectedProfile.JavaExecutable ?? Java.JavaExecutable,
                            StandardErrorEncoding = Encoding.UTF8,
                            WorkingDirectory = _selectedProfile.WorkingDirectory ?? Variables.McDirectory,
                            Arguments =
                                $"{javaArgumentsTemp}-Djava.library.path={Variables.McDirectory + "natives\\"} -cp {(Variables.Libraries.Contains(' ') ? "\"" + Variables.Libraries + "\"" : Variables.Libraries)} {selectedVersion.MainClass} {selectedVersion.ArgumentCollection.ToString(new Dictionary<string, string> {{"auth_player_name", _selectedUser.Type == "offline" ? NicknameDropDownList.Text : new Username() {Uuid = _selectedUser.Uuid}.GetUsernameByUuid()}, {"version_name", _selectedProfile.ProfileName}, {"game_directory", _selectedProfile.WorkingDirectory ?? Variables.McDirectory}, {"assets_root", Variables.McDirectory + "assets\\"}, {"game_assets", Variables.McDirectory + "assets\\legacy\\"}, {"assets_index_name", selectedVersion.AssetsIndex}, {"auth_session", _selectedUser.AccessToken ?? "sample_token"}, {"auth_access_token", _selectedUser.SessionToken ?? "sample_token"}, {"auth_uuid", _selectedUser.Uuid ?? "sample_token"}, {"user_properties", _selectedUser.UserProperties?.ToString(Formatting.None) ?? properties.ToString(Formatting.None)}, {"user_type", _selectedUser.Type}})}"
                        };
                        AppendLog($"Command line: \"{proc.FileName}\" {proc.Arguments}");
                        AppendLog(string.Format("Version {0} successfuly launched.",
                            selectedVersion.VersionId));
                        new MinecraftProcess(new Process {StartInfo = proc, EnableRaisingEvents = true}, this,
                            _selectedProfile).Launch();
                        BlockControls = false;
                        UpdateVersionListView();
                        _versionToLaunch = null;
                        _restoreVersion = false;
                    };
                    bgw2.RunWorkerAsync();
                };
                bgw1.RunWorkerAsync();
            };
            bgw.RunWorkerAsync();
        }

        private void logBox_TextChanged(object sender, EventArgs e)
        {
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }

        #region newsBrowser

        private void newsBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (newsBrowser.Url != new Uri("http://mcupdate.tumblr.com/")) {
                BackWebButton.Enabled = newsBrowser.CanGoBack;
                ForwardWebButton.Enabled = newsBrowser.CanGoForward;
                webPanel.Text = newsBrowser.Url.ToString();
                webPanel.Visible = true;
            } else {
                webPanel.Visible = false;
            }
        }

        private void newsBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (newsBrowser.Url != new Uri("http://mcupdate.tumblr.com/")) {
                BackWebButton.Enabled = newsBrowser.CanGoBack;
                ForwardWebButton.Enabled = newsBrowser.CanGoForward;
                webPanel.Text = newsBrowser.Url.ToString();
                webPanel.Visible = true;
            } else {
                webPanel.Visible = false;
            }
        }

        private void backWebButton_Click(object sender, EventArgs e)
        {
            newsBrowser.GoBack();
        }

        private void forwardWebButton_Click(object sender, EventArgs e)
        {
            newsBrowser.GoForward();
        }

        #endregion

        private void versionsListView_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            versionsListView.SelectedItem = e.Item;
            Version ver =
                Version.ParseVersion(new DirectoryInfo(Path.Combine(Variables.McVersions, versionsListView.SelectedItem[0].ToString() + "\\")), false);
            RadMenuItem launchVerButton = new RadMenuItem { Text = Variables.ProgramLocalization.Launch };
            launchVerButton.Click += delegate {
                if (versionsListView.SelectedItem == null) {
                    return;
                }
                _versionToLaunch = versionsListView.SelectedItem[0].ToString();
                LaunchButton.PerformClick();
            };
            bool enableRestoreButton = false;
            switch (ver.ReleaseType) {
                case "release":
                case "snapshot":
                case "old_beta":
                case "old_alpha":
                    enableRestoreButton = true;
                    break;
            }
            RadMenuItem restoreVerButton = new RadMenuItem { Text = "Restore and launch", Enabled = enableRestoreButton };
            restoreVerButton.Click += delegate {
                _restoreVersion = true;
                _versionToLaunch = versionsListView.SelectedItem[0].ToString();
                LaunchButton.PerformClick();
            };
            RadMenuItem openVerButton = new RadMenuItem { Text = Variables.ProgramLocalization.OpenLocation };
            openVerButton.Click += delegate {
                if (versionsListView.SelectedItem == null) {
                    return;
                }
                Process.Start(Path.Combine(Variables.McVersions, versionsListView.SelectedItem[0].ToString() + "\\"));
            };
            RadMenuItem delVerButton = new RadMenuItem { Text = Variables.ProgramLocalization.DeleteVersion};
            delVerButton.Click += delegate {
                if (versionsListView.SelectedItem == null) {
                    return;
                }
                DialogResult dr =
                    RadMessageBox.Show(
                        string.Format(Variables.ProgramLocalization.DeleteConfirmationText,
                            versionsListView.SelectedItem[0].ToString()),
                        Variables.ProgramLocalization.DeleteConfirmationTitle,
                        MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr != DialogResult.Yes) {
                    return;
                }
                try {
                    Directory.Delete(
                        Path.Combine(Variables.McVersions, versionsListView.SelectedItem[0].ToString() + "\\"), true);
                    AppendLog($"Version '{versionsListView.SelectedItem[0].ToString()}' has been deleted successfuly.");
                    UpdateVersionListView();
                }
                catch (Exception ex) {
                    AppendException($"An error has occurred during version deletion: {ex.ToString()}");
                }
                string path = Path.Combine(Variables.McVersions,
                    _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile) + "\\");
                string state = Variables.ProgramLocalization.ReadyToLaunch;
                if (!File.Exists(string.Format("{0}/{1}.json", path, _selectedProfile.SelectedVersion ??
                                                                     GetLatestVersion(_selectedProfile)))) {
                    state = Variables.ProgramLocalization.ReadyToDownload;
                }
                SelectedVersion.Text = string.Format(state, (_selectedProfile.SelectedVersion ??
                                                             GetLatestVersion(_selectedProfile)));
            };
            RadContextMenu verListMenuStrip = new RadContextMenu();
            verListMenuStrip.Items.Add(launchVerButton);
            verListMenuStrip.Items.Add(new RadMenuSeparatorItem());
            verListMenuStrip.Items.Add(restoreVerButton);
            verListMenuStrip.Items.Add(new RadMenuSeparatorItem());
            verListMenuStrip.Items.Add(openVerButton);
            verListMenuStrip.Items.Add(delVerButton);
            new RadContextMenuManager().SetRadContextMenu(versionsListView, verListMenuStrip);
        }

        private void SetToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(logBox.Text);
        }

        private void urlLabel_Click(object sender, EventArgs e)
        {
            Process.Start((sender as Label).Text);
        }

        private void LangDropDownList_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
        {
            if (LangDropDownList.SelectedItem.Tag.ToString() == _cfg.SelectedLanguage) {
                return;
            }

            var selectedLocalization = LangDropDownList.SelectedItem.Tag;
            if (LangDropDownList.SelectedIndex == 0)
                Variables.SetLocalization(string.Empty);
            else
                Variables.SetLocalization(selectedLocalization.ToString());

            _cfg.SelectedLanguage = selectedLocalization.ToString();
            AppendLog($"Application language changed to {selectedLocalization}");
            LoadLocalization();
        }

        private void UpdateVersions()
        {
            AppendLog("Checking version.json...");
            string jsonVersionList = new WebClient().DownloadString(
                new Uri("https://s3.amazonaws.com/Minecraft.Download/versions/versions.json"));
            if (!Directory.Exists(Variables.McVersions)) {
                Directory.CreateDirectory(Variables.McVersions);
            }
            if (!File.Exists(Variables.McVersions + "\\versions.json")) {
                File.WriteAllText(Variables.McVersions + "\\versions.json", jsonVersionList);
                return;
            }
            JObject jb =
                JObject.Parse(jsonVersionList);
            string remoteSnapshotVersion = jb["latest"]["snapshot"].ToString(),
                remoteReleaseVersion = jb["latest"]["release"].ToString();
            AppendLog("Latest snapshot: " + remoteSnapshotVersion);
            AppendLog("Latest release: " + remoteReleaseVersion);
            JObject ver = JObject.Parse(File.ReadAllText(Variables.McVersions + "/versions.json"));
            string localSnapshotVersion = ver["latest"]["snapshot"].ToString(),
                localReleaseVersion = ver["latest"]["release"].ToString();
            AppendLog("Local versions: " + ((JArray) jb["versions"]).Count + ". Remote versions: " +
                      ((JArray) ver["versions"]).Count);
            if (((JArray) jb["versions"]).Count == ((JArray) ver["versions"]).Count &&
                remoteReleaseVersion == localReleaseVersion && remoteSnapshotVersion == localSnapshotVersion) {
                AppendLog("No update found.");
                return;
            }
            AppendLog("Writting new list... ");
            File.WriteAllText(Variables.McVersions + "\\versions.json", jsonVersionList);
        }

        private void UpdateProfileList()
        {
            profilesDropDownBox.Items.Clear();
            try {
                _profileManager =
                    ProfileManager.ParseProfile(Variables.McDirectory +
                                                      "/launcher_profiles.json");
                if (!_profileManager.Profiles.Any()) {
                    throw new Exception("Someone broke my profiles>:(");
                }
            }
            catch (Exception ex) {
                AppendException("Reading profile list: an exception has occurred\n" + ex.Message +
                                "\nCreating a new one.");
                if (File.Exists(Variables.McDirectory +
                                "/launcher_profiles.json")) {
                    string fileName = "launcher_profiles-" + DateTime.Now.ToString("hhmmss") + ".bak.json";
                    AppendLog("A copy of old profile list has been created: " + fileName);
                    File.Move(Variables.McDirectory +
                              "/launcher_profiles.json", Variables.McDirectory +
                                                         "/" + fileName);
                }
                File.WriteAllText(Variables.McDirectory + "/launcher_profiles.json", new JObject {
                    {
                        "profiles", new JObject {
                            {
                                ProductName, new JObject {
                                    {"name", ProductName}, {
                                        "allowedReleaseTypes", new JArray {
                                            "release",
                                            "other"
                                        }
                                    },
                                    {"launcherVisibilityOnGameClose", "keep the launcher open"}
                                }
                            }
                        }
                    },
                    {"selectedProfile", ProductName}
                }.ToString());
                _profileManager = ProfileManager.ParseProfile(Variables.McDirectory +
                                                                    "/launcher_profiles.json");
                SaveProfiles();
            }
            DeleteProfileButton.Enabled = _profileManager.Profiles.Count > 1;
            profilesDropDownBox.Items.AddRange(_profileManager.Profiles.Keys);
            profilesDropDownBox.SelectedItem = profilesDropDownBox.FindItemExact(_profileManager.LastUsedProfile, true);
        }

        private void UpdateUserList()
        {
            NicknameDropDownList.Items.Clear();
            try {
                _userManager = File.Exists(Variables.McLauncher + "users.json")
                    ? JsonConvert.DeserializeObject<UserManager>(File.ReadAllText(Variables.McLauncher + "users.json"))
                    : new UserManager();
            }
            catch (Exception ex) {
                AppendException("Reading user list: an exception has occurred\n" + ex.Message);
                _userManager = new UserManager();
                SaveUsers();
            }
            NicknameDropDownList.Items.AddRange(_userManager.Accounts.Keys);
            NicknameDropDownList.SelectedItem = NicknameDropDownList.FindItemExact(_userManager.SelectedUsername, true);
        }

        private void SaveProfiles()
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                              "/.minecraft/launcher_profiles.json", _profileManager.ToJson());
        }

        private void SaveUsers()
        {
            File.WriteAllText(Variables.McLauncher + "users.json",
                JsonConvert.SerializeObject(_userManager, Formatting.Indented,
                    new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore}));
        }

        private void CheckVersionAvailability()
        {
            long state = 0;
            string filename,
                version = _versionToLaunch ?? (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile));
            WebClient downloader = new WebClient();
            downloader.DownloadProgressChanged += (sender, e) => {
                StatusBarValue = e.ProgressPercentage;
            };
            downloader.DownloadFileCompleted += delegate { state++; };
            StatusBarVisible = true;
            StatusBarMaxValue = 100;
            StatusBarValue = 0;
            UpdateStatusBarText(string.Format(Variables.ProgramLocalization.CheckingVersionAvailability, version));
            AppendLog($"Checking '{version}' version availability...");
            string path = Path.Combine(Variables.McVersions, version + "\\");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + "/" + version + ".json") || _restoreVersion) {
                filename = version + ".json";
                UpdateStatusBarAndLog("Downloading " + filename + "...", new StackFrame().GetMethod().Name);
                downloader.DownloadFileAsync(new Uri(string.Format(
                    "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.json", version)),
                    string.Format("{0}/{1}/{1}.json", Variables.McVersions, version));
            } else {
                state++;
            }
            StatusBarValue++;
            StatusBarValue = 0;
            while (state != 1) ;
            Version selectedVersion = Version.ParseVersion(
                new DirectoryInfo(Variables.McVersions + version), false);
            if ((!File.Exists(path + "/" + version + ".jar") || _restoreVersion) &&
                selectedVersion.InheritsFrom == null) {
                filename = version + ".jar";
                UpdateStatusBarAndLog("Downloading " + filename + "...", new StackFrame().GetMethod().Name);
                downloader.DownloadFileAsync(new Uri(string.Format(
                    "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.jar", version)),
                    string.Format("{0}/{1}/{1}.jar", Variables.McVersions, version));
            } else {
                state++;
            }
            while (state != 2) ;
            if (selectedVersion.InheritsFrom == null) {
                AppendLog("Finished checking version avalability.");
                return;
            }
            path = Path.Combine(Variables.McVersions, selectedVersion.InheritsFrom + "\\");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(string.Format("{0}/{1}/{1}.jar", Variables.McVersions, selectedVersion.InheritsFrom)) || _restoreVersion) {
                filename = selectedVersion.InheritsFrom + ".jar";
                UpdateStatusBarAndLog("Downloading " + filename + "...", new StackFrame().GetMethod().Name);
                downloader.DownloadFileAsync(new Uri(string.Format(
                    "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.jar", selectedVersion.InheritsFrom)),
                    string.Format("{0}/{1}/{1}.jar", Variables.McVersions, selectedVersion.InheritsFrom));
            } else {
                state++;
            }
            while (state != 3) ;
            if (!File.Exists(string.Format("{0}/{1}/{1}.json", Variables.McVersions, selectedVersion.InheritsFrom)) || _restoreVersion) {
                filename = selectedVersion.InheritsFrom + ".json";
                UpdateStatusBarAndLog("Downloading " + filename + "...");
                downloader.DownloadFileAsync(new Uri(string.Format(
                    "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.json", selectedVersion.InheritsFrom)),
                    string.Format("{0}/{1}/{1}.json", Variables.McVersions, selectedVersion.InheritsFrom));
            } else {
                state++;
            }
            while (state != 4) ;
            AppendLog("Finished checking version avalability.");
        }

        private void CheckLibraries()
        {
            string libraries = string.Empty;
            Version selectedVersion = Version.ParseVersion(
                new DirectoryInfo(Variables.McVersions +
                                  (_versionToLaunch ??
                                   (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)))));
            StatusBarVisible = true;
            StatusBarValue = 0;
            StatusBarMaxValue = selectedVersion.Libs.Count(a => a.IsForWindows()) + 1;
            UpdateStatusBarText(Variables.ProgramLocalization.CheckingLibraries);
            AppendLog("Checking libraries...");
            foreach (
                Lib lib in
                    selectedVersion
                        .Libs.Where(a => a.IsForWindows())) {
                StatusBarValue++;
                if (!File.Exists(Variables.McLibs + lib.ToPath()) || _restoreVersion) {
                    UpdateStatusBarAndLog("Downloading " + lib.Name + "...");
                    AppendDebug("Url: " + (lib.Url ?? @"https://libraries.minecraft.net/") + lib.ToPath());
                    string directory = Path.GetDirectoryName(Variables.McLibs + lib.ToPath());
                    if (!File.Exists(directory)) {
                        Directory.CreateDirectory(directory);
                    }
                    new WebClient().DownloadFile((lib.Url ?? @"https://libraries.minecraft.net/") + lib.ToPath(),
                        Variables.McLibs + lib.ToPath());
                }
                if (lib.IsNative != null) {
                    UpdateStatusBarAndLog("Unpacking " + lib.Name + "...");
                    using (ZipFile zip = ZipFile.Read(Variables.McLibs + lib.ToPath())) {
                        foreach (ZipEntry entry in zip.Where(entry => entry.FileName.EndsWith(".dll"))) {
                            AppendDebug($"Unzipping {entry.FileName}");
                            try {
                                entry.Extract(Variables.McDirectory + "natives\\",
                                    ExtractExistingFileAction.OverwriteSilently);
                            }
                            catch (Exception ex) {
                                AppendException(ex.Message);
                            }
                        }
                    }
                } else {
                    libraries += Variables.McLibs + lib.ToPath() + ";";
                }
                UpdateStatusBarText(Variables.ProgramLocalization.CheckingLibraries);
            }
            libraries += string.Format("{0}{1}\\{1}.jar", Variables.McVersions,
                selectedVersion.InheritsFrom ??
                (_versionToLaunch ?? (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile))));
            Variables.Libraries = libraries;
            AppendLog("Finished checking libraries.");
        }

        private void CheckGameResources()
        {
            UpdateStatusBarAndLog("Checking game assets...");
            Version selectedVersion = Version.ParseVersion(
                new DirectoryInfo(Variables.McVersions +
                                  (_versionToLaunch ??
                                   (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)))));
            string file = string.Format("{0}/assets/indexes/{1}.json", Variables.McDirectory,
                selectedVersion.AssetsIndex ?? "legacy");
            if (!File.Exists(file)) {
                if (!Directory.Exists(Path.GetDirectoryName(file))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(file));
                }
                new WebClient().DownloadFile(
                    string.Format("https://s3.amazonaws.com/Minecraft.Download/indexes/{0}.json",
                        selectedVersion.AssetsIndex ?? "legacy"), file);
            }
            JObject jo = JObject.Parse(File.ReadAllText(file));
            StatusBarValue = 0;
            StatusBarMaxValue = jo["objects"].Cast<JProperty>()
                .Select(peep => jo["objects"][peep.Name]["hash"].ToString())
                .Select(c => c[0].ToString() + c[1].ToString() + "\\" + c)
                .Count(filename => !File.Exists(Variables.McDirectory + "\\assets\\objects\\" + filename) || _restoreVersion) + 1;
            foreach (string resourseFile in jo["objects"].Cast<JProperty>()
                .Select(peep => jo["objects"][peep.Name]["hash"].ToString())
                .Select(c => c[0].ToString() + c[1].ToString() + "\\" + c)
                .Where(
                    filename =>
                        !File.Exists(Variables.McDirectory + "\\assets\\objects\\" + filename) || _restoreVersion)) {
                string path = Variables.McDirectory + "\\assets\\objects\\" + resourseFile[0] + resourseFile[1] +
                              "\\";
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                try {
                    AppendDebug("Downloading " + resourseFile + "...");
                    new WebClient().DownloadFile(@"http://resources.download.minecraft.net/" + resourseFile,
                        Variables.McDirectory + "\\assets\\objects\\" + resourseFile);
                }
                catch (Exception ex) {
                    AppendException(ex.ToString());
                }
                StatusBarValue++;
            }
            AppendLog("Finished checking game assets.");
            if (selectedVersion.AssetsIndex == null) {
                StatusBarValue = 0;
                StatusBarMaxValue = jo["objects"].Cast<JProperty>()
                    .Count(res => !File.Exists(Variables.McDirectory + "\\assets\\legacy\\" + res.Name)) + 1;
                UpdateStatusBarAndLog("Converting assets...");
                foreach (
                    JProperty res in
                        jo["objects"].Cast<JProperty>()
                            .Where(res => !File.Exists(Variables.McDirectory + "\\assets\\legacy\\" + res.Name) || _restoreVersion)) {
                    try {
                        if (!Directory.Exists(
                            new FileInfo(Variables.McDirectory + "\\assets\\legacy\\" + res.Name).DirectoryName)) {
                            Directory.CreateDirectory(
                                new FileInfo(Variables.McDirectory + "\\assets\\legacy\\" + res.Name).DirectoryName);
                        }
                        AppendDebug(
                            $"Converting \"{"\\assets\\objects\\" + res.Value["hash"].ToString()[0] + res.Value["hash"].ToString()[1] + "\\" + res.Value["hash"]}\" to \"{"\\assets\\legacy\\" + res.Name}\"");
                        File.Copy(
                            Variables.McDirectory + "\\assets\\objects\\" + res.Value["hash"].ToString()[0] +
                            res.Value["hash"].ToString()[1] + "\\" + res.Value["hash"],
                            Variables.McDirectory + "\\assets\\legacy\\" + res.Name);
                    }
                    catch (Exception ex) {
                        AppendLog(ex.ToString());
                    }
                    StatusBarValue++;
                }
                AppendLog("Finished converting assets.");
            }
            StatusBarVisible = false;
        }

        private string GetLatestVersion(Profile profile)
        {
            JObject versionsList = JObject.Parse(File.ReadAllText(Variables.McVersions + "\\versions.json"));
            return profile.AllowedReleaseTypes != null
                ? profile.AllowedReleaseTypes.Contains("snapshot")
                    ? versionsList["latest"]["snapshot"].ToString()
                    : versionsList["latest"]["release"].ToString()
                : versionsList["latest"]["release"].ToString();
        }

        public object[] AddNewPage()
        {
            RadPageViewPage outputPage = new RadPageViewPage {
                Text =
                    string.Format("{0} ({1})", Variables.ProgramLocalization.GameOutput,
                        _versionToLaunch ?? _selectedProfile.ProfileName)
            };
            RadButton killProcessButton = new RadButton {
                Text = Variables.ProgramLocalization.KillProcess,
                Anchor = (AnchorStyles.Right | AnchorStyles.Top)
            };
            RadPanel panel = new RadPanel {
                Text = (_versionToLaunch ?? (
                    (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)))),
                Dock = DockStyle.Top
            };
            panel.Size = new Size(panel.Size.Width, 60);
            RadButton closeButton = new RadButton {
                Text = Variables.ProgramLocalization.Close,
                Anchor = (AnchorStyles.Right | AnchorStyles.Top),
                Enabled = false
            };
            RichTextBox reportBox = new RichTextBox {Dock = DockStyle.Fill, ReadOnly = true};
            closeButton.Location = new Point(panel.Size.Width - (closeButton.Size.Width + 5), 5);
            closeButton.Click += (sender, e) => mainPageView.Pages.Remove(outputPage);
            killProcessButton.Location = new Point(panel.Size.Width - (killProcessButton.Size.Width + 5),
                closeButton.Location.Y + closeButton.Size.Height + 5);
            panel.Controls.Add(closeButton);
            panel.Controls.Add(killProcessButton);
            outputPage.Controls.Add(reportBox);
            outputPage.Controls.Add(panel);
            mainPageView.Pages.Add(outputPage);
            mainPageView.SelectedPage = outputPage;
            reportBox.LinkClicked += (sender, e) => Process.Start(e.LinkText);
            return new object[] {
                reportBox,
                killProcessButton,
                closeButton
            };
        }

        private void LoadLocalization()
        {
            News.Text = Variables.ProgramLocalization.NewsTabText;
            ConsolePage.Text = Variables.ProgramLocalization.ConsoleTabText;
            EditVersions.Text = Variables.ProgramLocalization.ManageVersionsTabText;
            AboutPage.Text = Variables.ProgramLocalization.AboutTabText;
            AboutPageViewPage.Text = Variables.ProgramLocalization.AboutTabText;
            LicensesPage.Text = Variables.ProgramLocalization.LicensesTabText;
            SettingsPage.Text = Variables.ProgramLocalization.SettingsTabText;

            LaunchButton.Text = Variables.ProgramLocalization.LaunchButtonText;
            AddProfile.Text = Variables.ProgramLocalization.AddProfileButtonText;
            EditProfile.Text = Variables.ProgramLocalization.EditProfileButtonText;

            DevInfoLabel.Text = Variables.ProgramLocalization.DevInfo;
            GratitudesLabel.Text = Variables.ProgramLocalization.GratitudesText;
            GratitudesDescLabel.Text = Variables.ProgramLocalization.GratitudesDescription;
            PartnersLabel.Text = Variables.ProgramLocalization.PartnersText;
            MCofflineDescLabel.Text = Variables.ProgramLocalization.MCofflineDescription;
            CopyrightInfoLabel.Text = Variables.ProgramLocalization.CopyrightInfo;

            EnableMinecraftUpdateAlerts.Text = Variables.ProgramLocalization.EnableMinecraftUpdateAlertsText;
            EnableMinecraftLogging.Text = Variables.ProgramLocalization.EnableMinecraftLoggingText;
            UseGamePrefix.Text = Variables.ProgramLocalization.UseGamePrefixText;
            CloseGameOutput.Text = Variables.ProgramLocalization.CloseGameOutputText;
        }

        private void UpdateVersionListView()
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action(UpdateVersionListView));
            } else {
                versionsListView.Items.Clear();
                foreach (
                    Version version in
                        Directory.GetDirectories(Variables.McVersions)
                            .Select(versionDir => new DirectoryInfo(versionDir))
                            .Select(info => Version.ParseVersion(info, false))) {
                    versionsListView.Items.Add(version.VersionId, version.ReleaseType,
                        version.InheritsFrom ?? Variables.ProgramLocalization.Independent);
                }
            }
        }

        private void UpdateStatusBarText(string text)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<string>(UpdateStatusBarText), text);
            } else {
                StatusBar.Text = text;
            }
        }

        private void UpdateStatusBarAndLog(string text, string methodName = null)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<string, string>(UpdateStatusBarAndLog), text,
                    new StackFrame(1).GetMethod().Name);
            } else {
                StatusBar.Text = text;
                AppendLog(text, methodName);
            }
        }

        private void AppendLog(string text, string methodName = null)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<string, string>(AppendLog), text, new StackFrame(1).GetMethod().Name);
            } else {
                logBox.AppendText(string.Format(
                    string.IsNullOrEmpty(logBox.Text) ? "[{0}][{1}][{2}] {3}" : "\n[{0}][{1}][{2}] {3}",
                    DateTime.Now.ToString("dd-MM-yy HH:mm:ss"), "INFO",
                    methodName ?? new StackFrame(1, false).GetMethod().Name, text));
            }
        }

        private void AppendException(string text, string methodName = null)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<string, string>(AppendException), text, new StackFrame(1).GetMethod().Name);
            } else {
                logBox.AppendText(string.Format(
                    string.IsNullOrEmpty(logBox.Text) ? "[{0}][{1}][{2}] {3}" : "\n[{0}][{1}][{2}] {3}",
                    DateTime.Now.ToString("dd-MM-yy HH:mm:ss"), "ERR",
                    methodName ?? new StackFrame(1, false).GetMethod().Name, text));
            }
        }

        private void AppendDebug(string text, string methodName = null)
        {
            if (!DebugModeButton.IsChecked) {
                return;
            }
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<string, string>(AppendDebug), text, new StackFrame(1).GetMethod().Name);
            } else {
                logBox.AppendText(string.Format(
                    string.IsNullOrEmpty(logBox.Text) ? "[{0}][{1}][{2}] {3}" : "\n[{0}][{1}][{2}] {3}",
                    DateTime.Now.ToString("dd-MM-yy HH:mm:ss"), "DEBUG",
                    methodName ?? new StackFrame(1, false).GetMethod().Name, text));
            }
        }

    }

    internal class MinecraftProcess
    {
        private readonly LauncherForm _launcherForm;
        private readonly Profile _profile;
        private readonly Process _minecraftProcess;
        private RichTextBox _gameLoggingBox;
        private RadButton _closePageButton, _killProcessButton;
        private static Thread _outputReader, _errorReader;

        public MinecraftProcess(Process minecraftProcess, LauncherForm launcherForm, Profile profile)
        {
            _launcherForm = launcherForm;
            _profile = profile;
            _minecraftProcess = minecraftProcess;
        }

        public void Launch()
        {
            if (_profile.LauncherVisibilityOnGameClose != Profile.LauncherVisibility.CLOSED) {
                if (_launcherForm.EnableMinecraftLogging.Checked) {
                    _outputReader = new Thread(o_reader);
                    _outputReader.Start();
                }
                _errorReader = new Thread(e_reader);
                _errorReader.Start();
                object[] obj = _launcherForm.AddNewPage();
                _gameLoggingBox = (RichTextBox) obj[0];
                _closePageButton = (RadButton) obj[2];
                _killProcessButton = (RadButton) obj[1];
                _killProcessButton.Click += KillProcessButton_Click;
                _minecraftProcess.Exited += MinecraftProcess_Exited;
            }
            _minecraftProcess.Start();
            if (_profile.LauncherVisibilityOnGameClose == Profile.LauncherVisibility.CLOSED) {
                _launcherForm.Close();
            }
            if (_profile.LauncherVisibilityOnGameClose == Profile.LauncherVisibility.HIDDEN) {
                _launcherForm.Hide();
            }
        }

        private void KillProcessButton_Click(object sender, EventArgs e)
        {
            _minecraftProcess.Kill();
        }

        private void MinecraftProcess_Exited(object sender, EventArgs e)
        {
            if (_profile.LauncherVisibilityOnGameClose == Profile.LauncherVisibility.HIDDEN) {
                _launcherForm.Invoke((MethodInvoker) (() => _launcherForm.Show()));
            }
            _outputReader?.Abort();
            _errorReader.Abort();
            AppendLog(
                string.Format("Process exited with error code {0}. Session since {1}({2} total)",
                    _minecraftProcess.ExitCode +
                    (_minecraftProcess.ExitCode == 0
                        ? "(Stable)"
                        : _minecraftProcess.ExitCode == -1 ? "(Killed)" : "(There could be problems)"),
                    _minecraftProcess.StartTime.ToString("HH:mm:ss"),
                    Math.Round(_minecraftProcess.StartTime.Subtract(DateTime.Now).TotalMinutes, 2)
                        .ToString(CultureInfo.InvariantCulture)
                        .Replace('-', ' ') + " min."), false);
            _launcherForm.Invoke((MethodInvoker) delegate {
                _closePageButton.Enabled = true;
                if (_launcherForm.CloseGameOutput.Checked &&
                    (_minecraftProcess.ExitCode == 0 || _minecraftProcess.ExitCode == -1)) {
                    _closePageButton.PerformClick();
                }
                _killProcessButton.Enabled = false;
            });
        }

        private void AppendLog(string text, bool iserror)
        {
            if (_gameLoggingBox.IsDisposed) {
                return;
            }
            if (_gameLoggingBox.InvokeRequired) {
                _gameLoggingBox.Invoke(new Action<string, bool>(AppendLog), text, iserror);
            } else {
                Color color = iserror ? Color.Red : Color.DarkSlateGray;
                string line = (_launcherForm.UseGamePrefix.ToggleState ==
                               ToggleState.On
                    ? "[GAME]"
                    : string.Empty) + text + "\n";
                int start = _gameLoggingBox.TextLength;
                _gameLoggingBox.AppendText(line);
                int end = _gameLoggingBox.TextLength;
                _gameLoggingBox.Select(start, end - start);
                _gameLoggingBox.SelectionColor = color;
                _gameLoggingBox.SelectionLength = 0;
                _gameLoggingBox.ScrollToCaret();
            }
        }

        private void o_reader()
        {
            while (true) {
                while (IsRunning(_minecraftProcess)) {
                    string line = _minecraftProcess.StandardOutput.ReadLine();
                    if (string.IsNullOrEmpty(line)) {
                        continue;
                    }
                    AppendLog(line, false);
                }
                if (_gameLoggingBox == null || !_gameLoggingBox.IsDisposed) {
                    continue;
                }
                _minecraftProcess.EnableRaisingEvents = false;
                _outputReader.Abort();
                _errorReader.Abort();
            }
        }

        private void e_reader()
        {
            while (true) {
                while (IsRunning(_minecraftProcess)) {
                    string line = _minecraftProcess.StandardError.ReadLine();
                    if (string.IsNullOrEmpty(line)) {
                        continue;
                    }
                    AppendLog(line, true);
                }
                if (_gameLoggingBox == null || !_gameLoggingBox.IsDisposed) {
                    continue;
                }
                _minecraftProcess.EnableRaisingEvents = false;
                _outputReader.Abort();
                _errorReader.Abort();
            }
        }

        private static bool IsRunning(Process process)
        {
            try {
                Process.GetProcessById(process.Id);
            }
            catch {
                return false;
            }
            return true;
        }
    }
}
