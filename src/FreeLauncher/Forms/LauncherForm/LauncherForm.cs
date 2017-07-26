using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using OS = dotMCLauncher.Core.OperatingSystem;

namespace FreeLauncher.Forms
{
    public partial class LauncherForm : RadForm
    {
        #region Variables

        private readonly ApplicationContext _applicationContext;
        private ProfileManager _profileManager;
        private RawVersionListManifest _versionList;
        private Profile _selectedProfile;
        private UserManager _userManager;
        private User _selectedUser;
        private readonly Configuration _cfg;
        private string _versionToLaunch;
        private bool _restoreVersion;

        public int LinuxTimeStamp => (int) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        private int StatusBarValue
        {
            get { return StatusBar.Value1; }
            set { SetStatusBarValue(value); }
        }

        private int StatusBarMaxValue
        {
            set { SetStatusBarMaxValue(value); }
        }

        private bool StatusBarVisible
        {
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

        public LauncherForm(ApplicationContext appContext)
        {
            _applicationContext = appContext;
            InitializeComponent();

            _cfg = _applicationContext.Configuration;
            DownloadAssetsBox.Checked = _cfg.SkipAssetsDownload;
            EnableMinecraftLogging.Checked = _cfg.EnableGameLogging;
            CloseGameOutput.Checked = _cfg.CloseTabAfterSuccessfulExitCode;
            LoadLocalization();

            Text = ProductName + " " + ProductVersion;
            AboutVersion.Text = ProductVersion;
            AppendLog($"Application: {ProductName}");
            AppendLog($"Version: {ProductVersion}");
            AppendLog($"Loaded language: {_applicationContext.ProgramLocalization.Name}({_applicationContext.ProgramLocalization.LanguageTag})");
            AppendLog(new string('=', 12));
            AppendLog("System info:");
            AppendLog($"{new string(' ', 2)}Operating system:");
            AppendLog($"{new string(' ', 4)}OSFullName: {new ComputerInfo().OSFullName}");
            AppendLog($"{new string(' ', 4)}Build: {Environment.OSVersion.Version.Build}");
            AppendLog($"{new string(' ', 4)}Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem}");
            AppendLog($"{new string(' ', 2)}Java path: '{Java.JavaInstallationPath}' ({Java.JavaBitInstallation}-bit)");
            AppendLog(new string('=', 12));

            if (_applicationContext.LocalizationsList.Count != 0) {
                foreach (KeyValuePair<string, Localization> keyvalue in _applicationContext.LocalizationsList) {
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

            if (!Directory.Exists(_applicationContext.McDirectory)) {
                Directory.CreateDirectory(_applicationContext.McDirectory);
            }
            if (!Directory.Exists(_applicationContext.McLauncher)) {
                Directory.CreateDirectory(_applicationContext.McLauncher);
            }

            if (!_applicationContext.ProgramArguments.NotAStandalone) {
                UpdateVersions();
            }

            UpdateProfileList();
            UpdateVersionListView();
            UpdateUserList();
            Focus();
        }

        private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cfg.SkipAssetsDownload = DownloadAssetsBox.Checked;
            _cfg.EnableGameLogging = EnableMinecraftLogging.Checked;
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
            UpdateVersionListView();
            SaveProfiles();
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
            ProfileForm pf = new ProfileForm(_selectedProfile, _applicationContext) {
                Text = _applicationContext.ProgramLocalization.EditingProfileTitle
            };
            pf.ShowDialog();
            if (pf.DialogResult == DialogResult.OK) {
                _profileManager.Profiles.Remove(_profileManager.LastUsedProfile);
                if (_profileManager.Profiles.ContainsKey(pf.CurrentProfile.ProfileName)) {
                    RadMessageBox.Show(_applicationContext.ProgramLocalization.ProfileAlreadyExistsErrorText,
                        _applicationContext.ProgramLocalization.Error,
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
            editedProfile.ProfileName = $"Copy of '{_selectedProfile.ProfileName}'({LinuxTimeStamp})";
            ProfileForm pf = new ProfileForm(editedProfile, _applicationContext) {Text = _applicationContext.ProgramLocalization.AddingProfileTitle};
            pf.ShowDialog();
            if (pf.DialogResult == DialogResult.OK) {
                if (_profileManager.Profiles.ContainsKey(editedProfile.ProfileName)) {
                    RadMessageBox.Show(_applicationContext.ProgramLocalization.ProfileAlreadyExistsErrorText,
                        _applicationContext.ProgramLocalization.Error,
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
                    string.Format(_applicationContext.ProgramLocalization.ProfileDeleteConfirmationText,
                        _profileManager.LastUsedProfile), _applicationContext.ProgramLocalization.DeleteConfirmationTitle,
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
            new UsersForm(_applicationContext).ShowDialog();
            UpdateUserList();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            BlockControls = true;
            if (string.IsNullOrWhiteSpace(NicknameDropDownList.Text)) {
                NicknameDropDownList.Text = $"Player{LinuxTimeStamp}";
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += delegate {
                DownloadVersion(_versionToLaunch ?? (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)));
                UpdateVersionListView();
            };
            bgw.RunWorkerCompleted += delegate {
                string libraries = string.Empty;
                BackgroundWorker bgw1 = new BackgroundWorker();
                bgw1.DoWork += delegate { libraries = DownloadLibraries(); };
                bgw1.RunWorkerCompleted += delegate {
                    BackgroundWorker bgw2 = new BackgroundWorker();
                    bgw2.DoWork += delegate {
                        if (!DownloadAssetsBox.Checked) {
                            DownloadAssets();
                        } else {
                            AppendLog("Assets download skipped.");
                        }
                        StatusBarVisible = false;
                    };
                    bgw2.RunWorkerCompleted += delegate {
                        if (_restoreVersion) {
                            AppendLog($"Successfully restored \"{_versionToLaunch}\" version.");
                            _restoreVersion = false;
                            BlockControls = false;
                            UpdateVersionListView();
                            _versionToLaunch = null;
                            return;
                        }
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
                                        _applicationContext.ProgramLocalization.Error, MessageBoxButtons.OK,
                                        RadMessageIcon.Exclamation);
                                    User user = new User {
                                        Username = NicknameDropDownList.Text,
                                        Type = "offline"
                                    };
                                    _selectedUser = user;
                                } else {
                                    Refresh refresh = new Refresh(_selectedUser.SessionToken,
                                        _selectedUser.AccessToken);
                                    _selectedUser.UserProperties = (JArray) refresh.user?["properties"];
                                    _selectedUser.SessionToken = refresh.accessToken;
                                    _userManager.Accounts[NicknameDropDownList.Text] = _selectedUser;
                                }
                            }
                        }
                        _userManager.SelectedUsername = _selectedUser.Username;
                        SaveUsers();
                        UpdateUserList();
                        VersionManifest selectedVersionManifest = VersionManifest.ParseVersion(
                            new DirectoryInfo(_applicationContext.McVersions + @"\" + (_versionToLaunch ?? (
                                (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile))))));
                        JObject properties = new JObject {
                            new JProperty("freelauncher", new JArray("cheeki_breeki_iv_damke"))
                        };
                        if (_selectedProfile.FastConnectionSettigs != null) {
                            selectedVersionManifest.ArgCollection.Add("server",
                                _selectedProfile.FastConnectionSettigs.ServerIp);
                            selectedVersionManifest.ArgCollection.Add("port",
                                _selectedProfile.FastConnectionSettigs.ServerPort.ToString());
                        }
                        string javaArguments = _selectedProfile.JavaArguments == null
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
                            WorkingDirectory = _selectedProfile.WorkingDirectory ?? _applicationContext.McDirectory + @"\",
                            Arguments =
                                $"{javaArguments}-Djava.library.path={_applicationContext.McDirectory + @"\natives\"} -cp {(libraries.Contains(' ') ? $"\"{libraries}\"" : libraries)} {selectedVersionManifest.MainClass} {selectedVersionManifest.ArgCollection.ToString(new Dictionary<string, string> {{"auth_player_name", _selectedUser.Type == "offline" ? NicknameDropDownList.Text : new Username() {Uuid = _selectedUser.Uuid}.GetUsernameByUuid()}, {"version_name", _selectedProfile.ProfileName}, {"game_directory", _selectedProfile.WorkingDirectory ?? _applicationContext.McDirectory + @"\"}, {"assets_root", _applicationContext.McDirectory + @"\assets\"}, {"game_assets", _applicationContext.McDirectory + @"\assets\legacy\"}, {"assets_index_name", selectedVersionManifest.GetAssetsIndex()}, { "version_type", selectedVersionManifest.ReleaseType }, {"auth_session", _selectedUser.AccessToken ?? "sample_token"}, {"auth_access_token", _selectedUser.SessionToken ?? "sample_token"}, {"auth_uuid", _selectedUser.Uuid ?? "sample_token"}, {"user_properties", _selectedUser.UserProperties?.ToString(Formatting.None) ?? properties.ToString(Formatting.None)}, {"user_type", _selectedUser.Type}})}"
                        };
                        AppendLog($"Command line: \"{proc.FileName}\" {proc.Arguments}");
                        new MinecraftProcess(new Process {StartInfo = proc, EnableRaisingEvents = true}, this,
                            _selectedProfile).Launch();
                        AppendLog($"Version {selectedVersionManifest.VersionId} successfuly launched.");
                        BlockControls = false;
                        UpdateVersionListView();
                        _versionToLaunch = null;
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
            ProcessUrl();
        }

        private void newsBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            ProcessUrl();
        }

        private void ProcessUrl()
        {
            if (newsBrowser.Url != new Uri("https://mcupdate.tumblr.com/")) {
                BackWebButton.Enabled = newsBrowser.CanGoBack;
                ForwardWebButton.Enabled = newsBrowser.CanGoForward;
                navBar.Text = newsBrowser.Url.ToString();
                navBar.Visible = true;
            } else {
                navBar.Visible = false;
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
            VersionManifest ver =
                VersionManifest.ParseVersion(
                    new DirectoryInfo(Path.Combine(_applicationContext.McVersions,
                        versionsListView.SelectedItem[0] + @"\")), false);
            RadMenuItem launchVerButton = new RadMenuItem { Text = _applicationContext.ProgramLocalization.Launch };
            launchVerButton.Click += delegate {
                if (versionsListView.SelectedItem == null) {
                    return;
                }
                _versionToLaunch = versionsListView.SelectedItem[0].ToString();
                LaunchButton.PerformClick();
            };
            bool enableRestoreButton = ver.ReleaseType == "release" || ver.ReleaseType == "snapshot" ||
                                       ver.ReleaseType == "old_beta" || ver.ReleaseType == "old_alpha";
            RadMenuItem restoreVerButton = new RadMenuItem { Text = "Restore", Enabled = enableRestoreButton };
            restoreVerButton.Click += delegate {
                _restoreVersion = true;
                _versionToLaunch = versionsListView.SelectedItem[0].ToString();
                LaunchButton.PerformClick();
            };
            RadMenuItem openVerButton = new RadMenuItem { Text = _applicationContext.ProgramLocalization.OpenLocation };
            openVerButton.Click += delegate {
                if (versionsListView.SelectedItem == null) {
                    return;
                }
                Process.Start(Path.Combine(_applicationContext.McVersions, versionsListView.SelectedItem[0] + @"\"));
            };
            RadMenuItem delVerButton = new RadMenuItem { Text = _applicationContext.ProgramLocalization.DeleteVersion};
            delVerButton.Click += delegate {
                if (versionsListView.SelectedItem == null) {
                    return;
                }
                DialogResult dr =
                    RadMessageBox.Show(
                        string.Format(_applicationContext.ProgramLocalization.DeleteConfirmationText,
                            versionsListView.SelectedItem[0]),
                        _applicationContext.ProgramLocalization.DeleteConfirmationTitle,
                        MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr != DialogResult.Yes) {
                    return;
                }
                try {
                    Directory.Delete(
                        Path.Combine(_applicationContext.McVersions, versionsListView.SelectedItem[0] + @"\"), true);
                    AppendLog($"Version '{versionsListView.SelectedItem[0]}' has been deleted successfuly.");
                    UpdateVersionListView();
                }
                catch (Exception ex) {
                    AppendException($"An error has occurred during version deletion: {ex}");
                }
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

        private void langWikiLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/dedepete/FreeLauncher/wiki/Change-language");
        }

        private void LangDropDownList_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
        {
            if (LangDropDownList.SelectedItem.Tag.ToString() == _cfg.SelectedLanguage) {
                return;
            }

            var selectedLocalization = LangDropDownList.SelectedItem.Tag;
            _applicationContext.SetLocalization(LangDropDownList.SelectedIndex == 0
                ? string.Empty
                : selectedLocalization.ToString());

            _cfg.SelectedLanguage = selectedLocalization.ToString();
            AppendLog($"Application language changed to {selectedLocalization}");
            LoadLocalization();
        }

        private void UpdateVersions()
        {
            AppendLog("Checking version.json...");
            RawVersionListManifest remoteManifest = RawVersionListManifest.ParseList(new WebClient().DownloadString(
                new Uri("https://launchermeta.mojang.com/mc/game/version_manifest.json")));
            if (!Directory.Exists(_applicationContext.McVersions)) {
                Directory.CreateDirectory(_applicationContext.McVersions);
            }
            if (!File.Exists(_applicationContext.McVersions + @"\versions.json")) {
                File.WriteAllText(_applicationContext.McVersions + @"\versions.json", remoteManifest.ToString());
                _versionList = remoteManifest;
                return;
            }
            AppendLog("Latest snapshot: " + remoteManifest.LatestVersions.Snapshot);
            AppendLog("Latest release: " + remoteManifest.LatestVersions.Release);
            RawVersionListManifest localManifest =
                RawVersionListManifest.ParseList(File.ReadAllText(_applicationContext.McVersions + @"\versions.json"));
            AppendLog($"Local versions: {localManifest.Versions.Count}. "
                + $"Remote versions: {remoteManifest.Versions.Count}");
            if (remoteManifest.Versions.Count == localManifest.Versions.Count &&
                remoteManifest.LatestVersions.Release == localManifest.LatestVersions.Release &&
                remoteManifest.LatestVersions.Snapshot == localManifest.LatestVersions.Snapshot) {
                _versionList = localManifest;
                AppendLog("No update found.");
                return;
            }
            AppendLog("Writting new list...");
            File.WriteAllText(_applicationContext.McVersions + @"\versions.json", remoteManifest.ToString());
            _versionList = remoteManifest;
        }

        private void UpdateProfileList()
        {
            profilesDropDownBox.Items.Clear();
            try {
                _profileManager =
                    ProfileManager.ParseProfile(_applicationContext.McDirectory + @"\launcher_profiles.json");
                if (!_profileManager.Profiles.Any()) {
                    throw new FileLoadException("File is corrupted or contains no profiles.");
                }
            }
            catch (Exception ex) {
                AppendException($"An exception has occurred while processing profiles:\n{ex.Message}\nA new profile list will be created.");
                if (File.Exists(_applicationContext.McDirectory + @"\launcher_profiles.json")) {
                    string fileName = $"launcher_profiles-{LinuxTimeStamp}.bak.json";
                    AppendLog("A copy of old profile list has been created: " + fileName);
                    File.Move(_applicationContext.McDirectory + @"\launcher_profiles.json",
                        _applicationContext.McDirectory + @"\" + fileName);
                }
                File.WriteAllText(_applicationContext.McDirectory + @"\launcher_profiles.json", new JObject {
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
                _profileManager = ProfileManager.ParseProfile(_applicationContext.McDirectory + @"\launcher_profiles.json");
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
                _userManager = File.Exists(_applicationContext.McLauncher + @"\users.json")
                    ? JsonConvert.DeserializeObject<UserManager>(
                        File.ReadAllText(_applicationContext.McLauncher + @"\users.json"))
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
            File.WriteAllText(_applicationContext.McDirectory + @"\launcher_profiles.json", _profileManager.ToJson());
        }

        private void SaveUsers()
        {
            File.WriteAllText(_applicationContext.McLauncher + @"\users.json",
                JsonConvert.SerializeObject(_userManager, Formatting.Indented,
                    new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));
        }

        private void DownloadVersion(string version)
        {
            string filename;
            WebClient downloader = new WebClient();
            downloader.DownloadProgressChanged += (sender, e) => {
                StatusBarValue = e.ProgressPercentage;
            };
            StatusBarVisible = true;
            StatusBarMaxValue = 100;
            StatusBarValue = 0;
            UpdateStatusBarText(string.Format(_applicationContext.ProgramLocalization.CheckingVersionAvailability, version));
            AppendLog($"Checking '{version}' version availability...");
            string path = Path.Combine(_applicationContext.McVersions, version + @"\");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists($@"{path}\{version}.json") || _restoreVersion) {
                filename = version + ".json";
                UpdateStatusBarAndLog($"Downloading {filename}...", new StackFrame().GetMethod().Name);
                downloader.DownloadFileTaskAsync(new Uri(_versionList.GetVersion(version)?.ManifestUrl ?? string.Format(
                    "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.json", version)),
                    string.Format(@"{0}\{1}\{1}.json", _applicationContext.McVersions, version)).Wait();
            }
            StatusBarValue = 0;
            VersionManifest selectedVersionManifest = VersionManifest.ParseVersion(
                new DirectoryInfo(_applicationContext.McVersions + @"\" + version), false);
            if ((!File.Exists($"{path}/{version}.jar") || _restoreVersion) &&
                selectedVersionManifest.InheritsFrom == null) {
                filename = version + ".jar";
                UpdateStatusBarAndLog($"Downloading {filename}...", new StackFrame().GetMethod().Name);
                downloader.DownloadFileTaskAsync(new Uri(selectedVersionManifest.DownloadInfo?.Client.Url
                    ?? string.Format("https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.jar", version)),
                    string.Format("{0}/{1}/{1}.jar", _applicationContext.McVersions, version)).Wait();
            }
            if (selectedVersionManifest.InheritsFrom != null) {
                DownloadVersion(selectedVersionManifest.InheritsFrom);
            }
            AppendLog($@"Finished checking {version} version avalability.");
        }

        private string DownloadLibraries()
        {
            StringBuilder libraries = new StringBuilder();
            VersionManifest selectedVersionManifest = VersionManifest.ParseVersion(
                new DirectoryInfo(_applicationContext.McVersions + @"\" +
                                  (_versionToLaunch ??
                                   (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)))));
            StatusBarVisible = true;
            StatusBarValue = 0;
            UpdateStatusBarText(_applicationContext.ProgramLocalization.CheckingLibraries);
            AppendLog("Getting required libraries...");
            Dictionary<DownloadEntry, bool> libsToDownload = new Dictionary<DownloadEntry, bool>();
            foreach (Lib a in selectedVersionManifest.Libs) {
                if (a.IsForWindows()) {
                    if (a.DownloadInfo == null) {
                        libsToDownload.Add(new DownloadEntry {Path = a.GetPath(), Url = a.Url}, false);
                        continue;
                    }
                }
                foreach (DownloadEntry entry in a.DownloadInfo.GetDownloadsEntries(OS.WINDOWS)) {
                    if (entry == null) {
                        continue;
                    }
                    entry.Path = entry.Path ?? a.GetPath();
                    entry.Url = entry.Url ?? a.Url;
                    libsToDownload.Add(entry, entry.IsNative);
                }
            }
            StatusBarMaxValue = libsToDownload.Count + 1;
            foreach (DownloadEntry entry in libsToDownload.Keys) {
                StatusBarValue++;
                if (!File.Exists(_applicationContext.McLibs + @"\" + entry.Path) ||
                    _restoreVersion) {
                    UpdateStatusBarAndLog($"Downloading {entry.Path.Replace('/', '\\')}...");
                    string directory = Path.GetDirectoryName(_applicationContext.McLibs + @"\" + entry.Path);
                    AppendDebug("Url: " + (entry.Url ?? @"https://libraries.minecraft.net/" + entry.Path));
                    AppendDebug("DownloadDir: " + directory);
                    AppendDebug("LibPath: " + entry.Path.Replace('/', '\\'));
                    if (!File.Exists(directory)) {
                        Directory.CreateDirectory(directory);
                    }
                    try {
                        new WebClient().DownloadFile(entry.Url ?? @"https://libraries.minecraft.net/" + entry.Path,
                            _applicationContext.McLibs + @"\" + entry.Path);
                    }
                    catch (WebException ex) {
                        AppendException("Downloading failed: " + ex.Message);
                        File.Delete(_applicationContext.McLibs + @"\" + entry.Path);
                        continue;
                    }
                    catch (Exception ex) {
                        AppendException("Downloading failed: " + ex.Message);
                        continue;
                    }
                }
                if (entry.IsNative) {
                    UpdateStatusBarAndLog($"Unpacking {entry.Path.Replace('/', '\\')}...");
                    using (ZipFile zip = ZipFile.Read(_applicationContext.McLibs + @"\" + entry.Path)) {
                        foreach (ZipEntry zipEntry in zip.Where(zipEntry => zipEntry.FileName.EndsWith(".dll"))) {
                            AppendDebug($"Unzipping {zipEntry.FileName}");
                            try {
                                zipEntry.Extract(_applicationContext.McDirectory + @"\natives\",
                                    ExtractExistingFileAction.OverwriteSilently);
                            }
                            catch (Exception ex) {
                                AppendException(ex.Message);
                            }
                        }
                    }
                } else {
                    libraries.Append(_applicationContext.McLibs + @"\" + entry.Path.Replace('/', '\\') + ";");
                }
                UpdateStatusBarText(_applicationContext.ProgramLocalization.CheckingLibraries);
            }
            libraries.Append(string.Format(@"{0}\{1}\{1}.jar", _applicationContext.McVersions,
                selectedVersionManifest.GetBaseJar()));
            AppendLog("Finished checking libraries.");
            return libraries.ToString();
        }

        private void DownloadAssets()
        {
            UpdateStatusBarAndLog("Checking game assets...");
            VersionManifest selectedVersionManifest = VersionManifest.ParseVersion(
                new DirectoryInfo(_applicationContext.McVersions + @"\" +
                                  (_versionToLaunch ??
                                   (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)))));
            if (selectedVersionManifest.InheritsFrom != null) {
                selectedVersionManifest = selectedVersionManifest.InheritableVersionManifest;
            }
            string file = string.Format(@"{0}\assets\indexes\{1}.json", _applicationContext.McDirectory,
                selectedVersionManifest.AssetsIndex ?? "legacy");
            if (!File.Exists(file)) {
                if (!Directory.Exists(Path.GetDirectoryName(file))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(file));
                }
                new WebClient().DownloadFile(
                    string.Format("https://s3.amazonaws.com/Minecraft.Download/indexes/{0}.json",
                        selectedVersionManifest.AssetsIndex ?? "legacy"), file);
            }
            JObject jo = JObject.Parse(File.ReadAllText(file));
            StatusBarValue = 0;
            StatusBarMaxValue = jo["objects"].Cast<JProperty>()
                                    .Select(peep => jo["objects"][peep.Name]["hash"].ToString())
                                    .Select(c => c.Substring(0, 2) + @"\" + c)
                                    .Count(filename =>
                                            !File.Exists(_applicationContext.McDirectory + @"\assets\objects\" +
                                                         filename) || _restoreVersion) + 1;
            foreach (string resourseFile in jo["objects"].Cast<JProperty>()
                .Select(peep => jo["objects"][peep.Name]["hash"].ToString())
                .Select(c => c.Substring(0, 2) + @"\" + c)
                .Where(filename =>
                    !File.Exists(_applicationContext.McDirectory + @"\assets\objects\" + filename) ||
                    _restoreVersion)) {
                string path = _applicationContext.McDirectory + @"\assets\objects\" + resourseFile.Substring(0, 2) +
                              @"\";
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                try {
                    AppendDebug($"Downloading {resourseFile}...");
                    new WebClient().DownloadFile(@"http://resources.download.minecraft.net/" + resourseFile,
                        _applicationContext.McDirectory + @"\assets\objects\" + resourseFile);
                }
                catch (Exception ex) {
                    AppendException(ex.ToString());
                }
                StatusBarValue++;
            }
            AppendLog("Finished checking game assets.");
            if (selectedVersionManifest.AssetsIndex == null) {
                StatusBarValue = 0;
                StatusBarMaxValue = jo["objects"].Cast<JProperty>()
                                        .Count(
                                            res =>
                                                !File.Exists(_applicationContext.McDirectory + @"\assets\legacy\" +
                                                             res.Name)) + 1;
                UpdateStatusBarAndLog("Converting assets...");
                foreach (
                    JProperty res in
                    jo["objects"].Cast<JProperty>()
                        .Where(
                            res =>
                                !File.Exists(_applicationContext.McDirectory + @"\assets\legacy\" + res.Name) ||
                                _restoreVersion)) {
                    try {
                        if (!Directory.Exists(
                            new FileInfo(_applicationContext.McDirectory + @"\assets\legacy\" + res.Name)
                                .DirectoryName)) {
                            Directory.CreateDirectory(
                                new FileInfo(_applicationContext.McDirectory + @"\assets\legacy\" + res.Name)
                                    .DirectoryName);
                        }
                        AppendDebug(
                            $"Converting '{@"\assets\objects\" + res.Value["hash"].ToString().Substring(0, 2) + @"\" + res.Value["hash"]}' to '{@"\assets\legacy\" + res.Name}'");
                        File.Copy(
                            _applicationContext.McDirectory + @"\assets\objects\" +
                            res.Value["hash"].ToString().Substring(0, 2) + @"\" + res.Value["hash"],
                            _applicationContext.McDirectory + @"\assets\legacy\" + res.Name);
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
            return profile.AllowedReleaseTypes != null
                ? profile.AllowedReleaseTypes.Contains("snapshot")
                    ? _versionList.LatestVersions.Snapshot
                    : _versionList.LatestVersions.Release
                : _versionList.LatestVersions.Release;
        }

        public LauncherFormOutput AddOutputPage()
        {
            RadPageViewPage outputPage = new RadPageViewPage {
                Text =
                    string.Format("{0} ({1})", _applicationContext.ProgramLocalization.GameOutput.ToUpper(),
                        _versionToLaunch ?? _selectedProfile.ProfileName)
            };
            RadButton killProcessButton = new RadButton {
                Text = _applicationContext.ProgramLocalization.KillProcess,
                Anchor = (AnchorStyles.Right | AnchorStyles.Top)
            };
            RadPanel panel = new RadPanel {
                Dock = DockStyle.Top
            };
            panel.Size = new Size(panel.Size.Width, 60);
            RadButton closeButton = new RadButton {
                Text = _applicationContext.ProgramLocalization.Close,
                Anchor = (AnchorStyles.Right | AnchorStyles.Top),
                Enabled = false
            };
            RichTextBox reportBox = new RichTextBox {Dock = DockStyle.Fill, ReadOnly = true, Font = logBox.Font};
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
            return new LauncherFormOutput {
                OutputBox = reportBox,
                CloseButton = closeButton,
                KillButton = killProcessButton,
                McVersion = _versionToLaunch ?? (
                           _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)),
                McType = VersionManifest.ParseVersion(
                            new DirectoryInfo(_applicationContext.McVersions + @"\" + (_versionToLaunch ?? (
                                (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)))))).ReleaseType,
                Panel = panel
            };
        }

        private void LoadLocalization()
        {
            News.Text = _applicationContext.ProgramLocalization.NewsTabText;
            ConsolePage.Text = _applicationContext.ProgramLocalization.ConsoleTabText;
            EditVersions.Text = _applicationContext.ProgramLocalization.ManageVersionsTabText;
            AboutPage.Text = _applicationContext.ProgramLocalization.AboutTabText;
            AboutPageViewPage.Text = _applicationContext.ProgramLocalization.AboutTabText;
            LicensesPage.Text = _applicationContext.ProgramLocalization.LicensesTabText;

            LaunchButton.Text = _applicationContext.ProgramLocalization.LaunchButtonText;
            AddProfile.Text = _applicationContext.ProgramLocalization.AddProfileButtonText;
            EditProfile.Text = _applicationContext.ProgramLocalization.EditProfileButtonText;

            DevInfoLabel.Text = _applicationContext.ProgramLocalization.DevInfo;
            GratitudesLabel.Text = _applicationContext.ProgramLocalization.GratitudesText;
            GratitudesDescLabel.Text = _applicationContext.ProgramLocalization.GratitudesDescription;
            PartnersLabel.Text = _applicationContext.ProgramLocalization.PartnersText;
            MCofflineDescLabel.Text = _applicationContext.ProgramLocalization.MCofflineDescription;
            CopyrightInfoLabel.Text = _applicationContext.ProgramLocalization.CopyrightInfo;

            DownloadAssetsBox.Text = _applicationContext.ProgramLocalization.SkipAssetsDownload;
            EnableMinecraftLogging.Text = _applicationContext.ProgramLocalization.EnableMinecraftLoggingText;
            CloseGameOutput.Text = _applicationContext.ProgramLocalization.CloseGameOutputText;
        }

        private void UpdateVersionListView()
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action(UpdateVersionListView));
            } else {
                versionsListView.Items.Clear();
                foreach (
                    VersionManifest version in
                        Directory.GetDirectories(_applicationContext.McVersions)
                            .Select(versionDir => new DirectoryInfo(versionDir))
                            .Where(VersionManifest.IsValid)
                            .Select(info => VersionManifest.ParseVersion(info, false))) {
                    versionsListView.Items.Add(version.VersionId, version.ReleaseType,
                        version.InheritsFrom ?? _applicationContext.ProgramLocalization.Independent);
                }
                string path = Path.Combine(_applicationContext.McVersions,
                    _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile) + @"\");
                string state = _applicationContext.ProgramLocalization.ReadyToLaunch;
                if (!File.Exists(string.Format(@"{0}\{1}.json", path, _selectedProfile.SelectedVersion ??
                                                                     GetLatestVersion(_selectedProfile))))
                {
                    state = _applicationContext.ProgramLocalization.ReadyToDownload;
                }
                SelectedVersion.Text = string.Format(state, (_selectedProfile.SelectedVersion ??
                                                             GetLatestVersion(_selectedProfile)));
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

        private void AppendText(string text, string logLevel, string methodName)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<string, string, string>(AppendText), text, logLevel,
                    methodName);
            } else {
                logBox.AppendText(string.Format(
                    (string.IsNullOrEmpty(logBox.Text) ? string.Empty : Environment.NewLine) +
                    "[{0}][{2}:{1}] {3}",
                    DateTime.Now.ToString("dd-MM-yy HH:mm:ss"), logLevel,
                    methodName, text));
                Application.DoEvents();
            }
        }

        private void AppendLog(string text, string methodName = null)
        {
            AppendText(text, "INFO", methodName ?? new StackFrame(1).GetMethod().Name);
        }

        private void AppendException(string text, string methodName = null)
        {
            AppendText(text, "ERROR", methodName ?? new StackFrame(1).GetMethod().Name);
        }

        private void AppendDebug(string text, string methodName = null)
        {
            if (!DebugModeButton.IsChecked) {
                return;
            }
            AppendText(text, "DEBUG", methodName ?? new StackFrame(1).GetMethod().Name);
        }
    }

    internal class MinecraftProcess
    {
        private readonly LauncherForm _launcherForm;
        private readonly Profile _profile;
        private readonly Process _minecraftProcess;
        private LauncherFormOutput _output;
        private readonly StringBuilder _outputInfoBuilder;
        private readonly StringBuilder _outputErrorBuilder;

        public MinecraftProcess(Process minecraftProcess, LauncherForm launcherForm, Profile profile)
        {
            _launcherForm = launcherForm;
            _profile = profile;
            _minecraftProcess = minecraftProcess;
            _outputInfoBuilder = new StringBuilder();
            _outputErrorBuilder = new StringBuilder();
        }

        public void Launch()
        {
            if (_profile.LauncherVisibilityOnGameClose != Profile.LauncherVisibility.CLOSED) {
                _output = _launcherForm.AddOutputPage();
                _output.KillButton.Click += KillProcessButton_Click;
                _minecraftProcess.Exited += MinecraftProcess_Exited;
                if (_launcherForm.EnableMinecraftLogging.Checked) {
                    _minecraftProcess.OutputDataReceived +=
                        (sender, args) => _outputInfoBuilder.Append($"{(_outputInfoBuilder.Length == 0 ? string.Empty : Environment.NewLine)}[O] {args.Data}");
                } else {
                    AppendLog($"NOTICE:{Environment.NewLine}Logging from [O]UTPUT thread has been disabled. It can be enabled in the Settings.{Environment.NewLine}{Environment.NewLine}");
                }
                _minecraftProcess.ErrorDataReceived +=
                    (sender, args) => _outputErrorBuilder.Append($"{(_outputErrorBuilder.Length == 0 ? string.Empty : Environment.NewLine)}[E] {args.Data}");
            }
            _minecraftProcess.Start();
            if (_profile.LauncherVisibilityOnGameClose == Profile.LauncherVisibility.CLOSED) {
                _launcherForm.Close();
                return;
            }
            _minecraftProcess.BeginOutputReadLine();
            _minecraftProcess.BeginErrorReadLine();
            new Thread(() => {
                while (!_minecraftProcess.HasExited || _outputInfoBuilder.Length != 0 || _outputErrorBuilder.Length != 0) {
                    if (_output.Panel.Disposing || _output.Panel.IsDisposed) {
                        break;
                    }
                    _output.Panel?.Invoke((MethodInvoker) delegate {
                        _output.Panel.Text = $"Minecraft version: {_output.McVersion}/{_output.McType}" +
                                             "\nStatus: " +
                                             (!_minecraftProcess.HasExited ? "Running" : "Stopped, printing output");
                        Application.DoEvents();
                        if (_outputInfoBuilder.Length > 0) {
                            AppendLog(_outputInfoBuilder.ToString());
                            _outputInfoBuilder.Clear();
                        }
                        if (_outputErrorBuilder.Length > 0) {
                            AppendLog(_outputErrorBuilder.ToString(), true);
                            _outputErrorBuilder.Clear();
                        }
                    });
                }
                if (_minecraftProcess.HasExited) {
                    PrintExitInfo();
                }
            }) {
                IsBackground = true
            }.Start();
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
            _launcherForm.Invoke((MethodInvoker) delegate {
                _output.KillButton.Enabled = false;
                if (_launcherForm.CloseGameOutput.Checked &&
                    new[] { 0, -1 }.Contains(_minecraftProcess.ExitCode)) {
                    _output.CloseButton.PerformClick();
                }
            });
        }

        private void PrintExitInfo()
        {
            if (_output.OutputBox.InvokeRequired) {
                _output.OutputBox.Invoke(new Action(PrintExitInfo));
            } else {
                string reason = _minecraftProcess.ExitCode == 0
                    ? "Stable closure"
                    : _minecraftProcess.ExitCode == -1 ? "Process killed" : "Crashed";
                _output.Panel.Text = $"Minecraft version: {_output.McVersion}/{_output.McType}" +
                                     "\nStatus: Stopped" +
                                     $"\nExit code: {_minecraftProcess.ExitCode} (Reason: {reason})" +
                                     $"\nSession duration: {_minecraftProcess.TotalProcessorTime:g}";
                _output.CloseButton.Enabled = true;
                if (new[] {0, -1}.Contains(_minecraftProcess.ExitCode)) {
                    return;
                }
                AppendLog(string.Empty);
                AppendLog(new string('=', 12));
                AppendLog("//Oops, seems like the game has been exited with unusual error code!");
                AppendLog("//Printing debug information right now!");
                AppendLog(string.Empty);
                AppendLog($"{Application.ProductName} {Application.ProductVersion}");
                AppendLog(string.Empty);
                AppendLog("System info:");
                AppendLog($"{new string(' ', 2)}Operating system:");
                AppendLog($"{new string(' ', 4)}OSFullName: {new ComputerInfo().OSFullName}");
                AppendLog($"{new string(' ', 4)}Build: {Environment.OSVersion.Version.Build}");
                AppendLog($"{new string(' ', 4)}Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem}");
                AppendLog(
                    $"{new string(' ', 2)}Java path: '{Java.JavaInstallationPath}' ({Java.JavaBitInstallation}-bit)");
                AppendLog(string.Empty);
                AppendLog("Process info:");
                AppendLog($"{new string(' ', 2)}Minecraft version/type: {_output.McVersion}/{_output.McType}");
                AppendLog($"{new string(' ', 2)}Executable file: '{_minecraftProcess.StartInfo.FileName}'");
                AppendLog($"{new string(' ', 2)}Arguments: '{_minecraftProcess.StartInfo.Arguments}'");
                AppendLog($"{new string(' ', 2)}Exit code: {_minecraftProcess.ExitCode}");
                AppendLog(string.Empty);
                AppendLog("//Finished printing debug information");
                AppendLog(new string('=', 12));
            }
        }

        private void AppendLog(string text, bool iserror = false)
        {
            if (_output.OutputBox.IsDisposed) {
                return;
            }
            if (_output.OutputBox.InvokeRequired) {
                _output.OutputBox.Invoke(new Action<string, bool>(AppendLog), text, iserror);
            } else {
                Color color = iserror ? Color.Red : Color.DarkSlateGray;
                string line = text + "\n";
                int start = _output.OutputBox.TextLength;
                _output.OutputBox.AppendText(line);
                int end = _output.OutputBox.TextLength;
                _output.OutputBox.Select(start, end - start);
                _output.OutputBox.SelectionColor = color;
                _output.OutputBox.SelectionLength = 0;
                _output.OutputBox.ScrollToCaret();
                Application.DoEvents();
            }
        }
    }

    public struct LauncherFormOutput
    {
        public RichTextBox OutputBox;
        public RadButton CloseButton;
        public RadButton KillButton;
        public RadPanel Panel;
        public string McVersion;
        public string McType;
    }
}
