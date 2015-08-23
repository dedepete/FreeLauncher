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
        private readonly Configuration _cfg;

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
            }
            else {
                StatusBar.Value1 = i;
            }
        }

        private void SetStatusBarMaxValue(int i)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<int>(SetStatusBarMaxValue), i);
            }
            else {
                StatusBar.Maximum = i;
            }
        }

        private void SetStatusBarVisibility(bool b)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<bool>(SetStatusBarVisibility), b);
            }
            else {
                StatusBar.Visible = b;
            }
        }

        #endregion

        public LauncherForm(ref Configuration cfg)
        {
            InitializeComponent();
            // Loading configuration
            _cfg = cfg;
            EnableMinecraftLogging.Checked = _cfg.EnableGameLogging;
            UseGamePrefix.Checked = _cfg.ShowGamePrefix;
            CloseGameOutput.Checked = _cfg.CloseTabAfterSuccessfulExitCode;
            //
            Text = ProductName + " " + ProductVersion;
            AboutVersion.Text = ProductVersion;
            AppendLog($"Application: {ProductName} v.{ProductVersion}" +
                      (!Variables.ProgramArguments.NotAStandalone ? "-standalone" : string.Empty));
            AppendLog("==============");
            AppendLog("System info:");
            AppendLog($"Operating system: {Environment.OSVersion}({new ComputerInfo().OSFullName})");
            AppendLog($"Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem}");
            AppendLog($"Java path: \"{Java.JavaInstallationPath}\" ({Java.JavaBitInstallation}-bit)");
            AppendLog("==============");
            if (!Directory.Exists(Variables.McDirectory)) {
                Directory.CreateDirectory(Variables.McDirectory);
            }
            if (!Directory.Exists(Variables.McLauncher)) {
                Directory.CreateDirectory(Variables.McLauncher);
            }
            RadMenuItem openVerButton = new RadMenuItem {Text = "Показать в проводнике"};
            openVerButton.Click += (sender, e) => {
                if (versionsListView.SelectedItem == null) {
                    return;
                }
                Console.WriteLine(Path.Combine(Variables.McVersions, versionsListView.SelectedItem[0].ToString() + "\\"));
                Process.Start(Path.Combine(Variables.McVersions, versionsListView.SelectedItem[0].ToString() + "\\"));
            };
            RadContextMenu verListMenuStrip = new RadContextMenu();
            verListMenuStrip.Items.Add(openVerButton);
            verListMenuStrip.Items.Add(new RadMenuSeparatorItem());
            RadMenuItem delVerButton = new RadMenuItem {Text = "Удалить версию"};
            delVerButton.Click += (sender, e) => {
                if (versionsListView.SelectedItem == null) {
                    return;
                }
                DialogResult dr =
                    RadMessageBox.Show(
                        string.Format("{0}({1})?", "Вы действительно хотите удалить эту версию",
                            versionsListView.SelectedItem[0].ToString()),
                        "Удаление",
                        MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr != DialogResult.Yes) return;
                try {
                    Directory.Delete(
                        Path.Combine(Variables.McVersions, versionsListView.SelectedItem[0].ToString() + "\\"), true);
                    AppendLog(string.Format("Версия '{0}' успешно удалена.", versionsListView.SelectedItem[0].ToString()));
                    UpdateVersionListView();
                }
                catch (Exception ex) {
                    AppendException(string.Format("Во время удаления произошла ошибка: {0}", ex.ToString()));
                }
                string path = Path.Combine(Variables.McVersions,
                    _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile) + "\\");
                string state = "Готов к запуску версии ";
                if (!File.Exists(string.Format("{0}/{1}.json", path, _selectedProfile.SelectedVersion ??
                                                                     GetLatestVersion(_selectedProfile)))) {
                    state = "Готов к загрузке версии ";
                }
                SelectedVersion.Text = state + (_selectedProfile.SelectedVersion ??
                                                GetLatestVersion(_selectedProfile));
            };
            verListMenuStrip.Items.Add(delVerButton);
            new RadContextMenuManager().SetRadContextMenu(versionsListView, verListMenuStrip);
            Focus();
            if (!Variables.ProgramArguments.NotAStandalone) {
                UpdateVersions();
            }
            // TODO: Make this thing work with Mojang accounts
            if (File.Exists(Path.Combine(Variables.McDirectory, "username"))) {
                NicknameDropDownList.Text = File.ReadAllText(Path.Combine(Variables.McDirectory, "username"));
            }
            UpdateProfileList();
            UpdateVersionListView();
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
            string state = "Готов к запуску версии ";
            if (!File.Exists(string.Format("{0}/{1}.json", path, _selectedProfile.SelectedVersion ??
                                                                 GetLatestVersion(_selectedProfile)))) {
                state = "Готов к загрузке версии ";
            }
            SelectedVersion.Text = state + (_selectedProfile.SelectedVersion ??
                                            GetLatestVersion(_selectedProfile));
        }

        private void EditProfile_Click(object sender, EventArgs e)
        {
            ProfileForm pf = new ProfileForm(_selectedProfile) {Text = "Edit profile"};
            pf.ShowDialog();
            if (pf.DialogResult == DialogResult.OK) {
                _profileManager.Profiles.Remove(_profileManager.LastUsedProfile);
                if (_profileManager.Profiles.ContainsKey(pf.CurrentProfile.ProfileName)) {
                    RadMessageBox.Show("Данный профиль уже существует в списке!", "Ошибка",
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
            Profile editedProfile = new Profile().ParseProfile(_selectedProfile.ToString());
            editedProfile.ProfileName = "Copy of '" + _selectedProfile.ProfileName + "'(" +
                                        DateTime.Now.ToString("HH:mm:ss") + ")";
            ProfileForm pf = new ProfileForm(editedProfile) {Text = "Add profile"};
            pf.ShowDialog();
            if (pf.DialogResult == DialogResult.OK) {
                if (_profileManager.Profiles.ContainsKey(editedProfile.ProfileName)) {
                    RadMessageBox.Show("Данный профиль уже существует в списке!", "Ошибка",
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
            DialogResult dr = RadMessageBox.Show("Вы действительно хотите удалить этот профиль?", "Подтверждение",
                MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dr != DialogResult.Yes) {
                return;
            }
            _profileManager.Profiles.Remove(_profileManager.LastUsedProfile);
            _profileManager.LastUsedProfile = _profileManager.Profiles.FirstOrDefault().Key;
            SaveProfiles();
            UpdateProfileList();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            BlockControls = true;
            if (string.IsNullOrWhiteSpace(NicknameDropDownList.Text)) {
                NicknameDropDownList.Text = $"Player{DateTime.Now.ToString("hhmmss")}";
            }
            // TODO: Make this thing work with Mojang accounts
            File.WriteAllText(Path.Combine(Variables.McDirectory, "username"), NicknameDropDownList.Text);
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
                        Version selectedVersion = new Version().ParseVersion(
                            new DirectoryInfo(Variables.McVersions +
                                              (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile))));
                        JObject properties = new JObject {
                            new JProperty("freelauncher", new JArray("cheeki_breeki_iv_damke"))
                        };
                        if (_selectedProfile.FastConnectionSettigs != null) {
                            selectedVersion.ArgumentCollection.Add("server", _selectedProfile.FastConnectionSettigs.ServerIP);
                            selectedVersion.ArgumentCollection.Add("port", _selectedProfile.FastConnectionSettigs.ServerPort.ToString());
                        }
                        string javaArgumentsTemp = _selectedProfile.JavaArguments == null
                            ? ""
                            : _selectedProfile.JavaArguments + " ";
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
                                $"{javaArgumentsTemp}-Djava.library.path={Variables.McDirectory + "natives\\"} -cp {(Variables.Libraries.Contains(' ') ? "\"" + Variables.Libraries + "\"" : Variables.Libraries)} {selectedVersion.MainClass} {selectedVersion.ArgumentCollection.ToString(new Dictionary<string, string> {{"auth_player_name", NicknameDropDownList.Text}, {"version_name", _selectedProfile.ProfileName}, {"game_directory", Variables.McDirectory}, {"assets_root", Variables.McDirectory + "assets\\"}, {"game_assets", Variables.McDirectory + "assets\\legacy\\"}, {"assets_index_name", selectedVersion.AssetsIndex}, {"auth_session", "test"}, {"auth_access_token", "test"}, {"auth_uuid", "test"}, {"user_properties", properties.ToString(Formatting.None)}, {"user_type", "mojang"}})}"
                        };
                        AppendLog($"Command line: \"{proc.FileName}\" {proc.Arguments}");
                        AppendLog(string.Format("Игра запущена. Версия: {0}.\nНачат вывод игры в другую вкладку.",
                            selectedVersion.VersionId));
                        new MinecraftProcess(new Process {StartInfo = proc, EnableRaisingEvents = true}, this,
                            _selectedProfile).Launch();
                        BlockControls = false;
                        UpdateVersionListView();
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
            }
            else {
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
            }
            else {
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
        }

        private void SetToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(logBox.Text);
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
            string remoteSnapshotVersion = jb["latest"]["snapshot"].ToString();
            AppendLog("Latest snapshot: " + remoteSnapshotVersion);
            string remoteReleaseVersion = jb["latest"]["release"].ToString();
            AppendLog("Latest release: " + remoteReleaseVersion);
            JObject ver = JObject.Parse(File.ReadAllText(Variables.McVersions + "/versions.json"));
            string localSnapshotVersion = ver["latest"]["snapshot"].ToString();
            string localReleaseVersion = ver["latest"]["release"].ToString();
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
                    new ProfileManager().ParseProfile(Variables.McDirectory +
                                                      "/launcher_profiles.json");
                if (!_profileManager.Profiles.Any()) {
                    throw new Exception("Какая-то редиска сломала список профилей >:(");
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
                                            "release"
                                        }
                                    },
                                    {"launcherVisibilityOnGameClose", "keep the launcher open"}
                                }
                            }
                        }
                    },
                    {"selectedProfile", ProductName}
                }.ToString());
                _profileManager = new ProfileManager().ParseProfile(Variables.McDirectory +
                                                                    "/launcher_profiles.json");
                SaveProfiles();
            }
            DeleteProfileButton.Enabled = _profileManager.Profiles.Count > 1;
            profilesDropDownBox.Items.AddRange(_profileManager.Profiles.Keys);
            profilesDropDownBox.SelectedItem = profilesDropDownBox.FindItemExact(_profileManager.LastUsedProfile, true);
        }

        private void SaveProfiles()
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                              "/.minecraft/launcher_profiles.json", _profileManager.ToJson());
        }

        private void CheckVersionAvailability()
        {
            long state = 0;
            string filename = string.Empty;
            WebClient downloader = new WebClient();
            downloader.DownloadProgressChanged += (sender, e) => {
                StatusBarValue = e.ProgressPercentage;
            };
            UpdateStatusBarText("Выполняется загрузка " + filename + "...");
            downloader.DownloadFileCompleted += delegate { state++; };
            StatusBarVisible = true;
            StatusBarMaxValue = 100;
            StatusBarValue = 0;
            UpdateStatusBarText("Выполняется проверка доступности версии '" +
                                (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)) + "'");
            AppendLog("Выполняется проверка доступности версии '" +
                      (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)) + "'...");
            string path = Path.Combine(Variables.McVersions,
                _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile) + "\\");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            if (
                !File.Exists(path + "/" + (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)) +
                             ".json")) {
                filename = (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)) + ".json";
                UpdateStatusBarAndLog("Выполняется загрузка " + filename + "...", new StackFrame().GetMethod().Name);
                downloader.DownloadFileAsync(new Uri(string.Format(
                    "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.json",
                    _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile))),
                    string.Format("{0}/{1}/{1}.json", Variables.McVersions,
                        _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)));
            }
            else {
                state++;
            }
            StatusBarValue++;
            StatusBarValue = 0;
            while (state != 1) ;
            Version selectedVersion = new Version().ParseVersion(
                new DirectoryInfo(Variables.McVersions +
                                  (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile))), false);
            if (
                !File.Exists(path + "/" + (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)) +
                             ".jar") &&
                selectedVersion.InheritsFrom == null) {
                filename = (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)) + ".jar";
                UpdateStatusBarAndLog("Выполняется загрузка " + filename + "...", new StackFrame().GetMethod().Name);
                downloader.DownloadFileAsync(new Uri(string.Format(
                    "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.jar",
                    _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile))),
                    string.Format("{0}/{1}/{1}.jar", Variables.McVersions,
                        _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)));
            }
            else {
                state++;
            }
            while (state != 2) ;
            if (selectedVersion.InheritsFrom == null) {
                AppendLog("Выполняется проверка доступности завершена.");
                return;
            }
            path = Path.Combine(Variables.McVersions, selectedVersion.InheritsFrom + "\\");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(string.Format("{0}/{1}/{1}.jar", Variables.McVersions, selectedVersion.InheritsFrom))) {
                filename = selectedVersion.InheritsFrom + ".jar";
                UpdateStatusBarAndLog("Выполняется загрузка " + filename + "...", new StackFrame().GetMethod().Name);
                downloader.DownloadFileAsync(new Uri(string.Format(
                    "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.jar", selectedVersion.InheritsFrom)),
                    string.Format("{0}/{1}/{1}.jar", Variables.McVersions, selectedVersion.InheritsFrom));
            }
            else {
                state++;
            }
            while (state != 3) ;
            if (!File.Exists(string.Format("{0}/{1}/{1}.json", Variables.McVersions, selectedVersion.InheritsFrom))) {
                filename = selectedVersion.InheritsFrom + ".json";
                UpdateStatusBarAndLog("Выполняется загрузка " + filename + "...");
                downloader.DownloadFileAsync(new Uri(string.Format(
                    "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.json", selectedVersion.InheritsFrom)),
                    string.Format("{0}/{1}/{1}.json", Variables.McVersions, selectedVersion.InheritsFrom));
            }
            else {
                state++;
            }
            while (state != 4) ;
            AppendLog("Выполняется проверка доступности завершена.");
        }

        private void CheckLibraries()
        {
            string libraries = string.Empty;
            Version selectedVersion = new Version().ParseVersion(
                new DirectoryInfo(Variables.McVersions +
                                  (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile))));
            StatusBarVisible = true;
            StatusBarValue = 0;
            StatusBarMaxValue = selectedVersion.Libs.Count(a => a.IsForWindows()) + 1;
            UpdateStatusBarText("Выполняется проверка библиотек");
            AppendLog("Выполняется проверка библиотек...");
            foreach (
                Lib lib in
                    selectedVersion
                        .Libs.Where(a => a.IsForWindows())) {
                StatusBarValue++;
                if (!File.Exists(Variables.McLibs + lib.ToPath())) {
                    UpdateStatusBarAndLog("Выполняется скачивание " + lib.Name + "...");
                    if (DebugModeButton.IsChecked) {
                        AppendLog("Url: " + (lib.Url ?? @"https://libraries.minecraft.net/") + lib.ToPath());
                    }
                    string directory = Path.GetDirectoryName(Variables.McLibs + lib.ToPath());
                    if (!File.Exists(directory)) {
                        Directory.CreateDirectory(directory);
                    }
                    new WebClient().DownloadFile((lib.Url ?? @"https://libraries.minecraft.net/") + lib.ToPath(),
                        Variables.McLibs + lib.ToPath());
                }
                if (lib.IsNative != null) {
                    UpdateStatusBarAndLog("Выполняется распаковка " + lib.Name + "...");
                    using (ZipFile zip = ZipFile.Read(Variables.McLibs + lib.ToPath()))
                        foreach (ZipEntry entry in zip.Where(entry => entry.FileName.EndsWith(".dll"))) {
                            try {
                                entry.Extract(Variables.McDirectory + "\\natives\\",
                                    ExtractExistingFileAction.OverwriteSilently);
                            }
                            catch (Exception ex) {
                                AppendException(ex.Message);
                            }
                        }
                }
                else {
                    libraries += Variables.McLibs + lib.ToPath() + ";";
                }
                UpdateStatusBarText("Выполняется проверка библиотек");
            }
            libraries += string.Format("{0}{1}\\{1}.jar", Variables.McVersions,
                selectedVersion.InheritsFrom ?? (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)));
            Variables.Libraries = libraries;
            AppendLog("Проверка библиотек завершена.");
        }

        private void CheckGameResources()
        {
            UpdateStatusBarAndLog("Выполняется проверка игровых ресурсов...");
            Version selectedVersion = new Version().ParseVersion(
                new DirectoryInfo(Variables.McVersions +
                                  (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile))));
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
                .Count(filename => !File.Exists(Variables.McDirectory + "\\assets\\objects\\" + filename)) + 1;
            foreach (string resourseFile in jo["objects"].Cast<JProperty>()
                .Select(peep => jo["objects"][peep.Name]["hash"].ToString())
                .Select(c => c[0].ToString() + c[1].ToString() + "\\" + c)
                .Where(
                    filename =>
                        !File.Exists(Variables.McDirectory + "\\assets\\objects\\" + filename))) {
                string path = Variables.McDirectory + "\\assets\\objects\\" + resourseFile[0] + resourseFile[1] +
                              "\\";
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                try {
                    AppendLog("Downloading " + resourseFile + "...");
                    new WebClient().DownloadFile(@"http://resources.download.minecraft.net/" + resourseFile,
                        Variables.McDirectory + "\\assets\\objects\\" + resourseFile);
                }
                catch (Exception ex) {
                    AppendException(ex.ToString());
                }
                StatusBarValue++;
            }
            AppendLog("Проверка игровых ресурсов завершена.");
            if (selectedVersion.AssetsIndex == null) {
                StatusBarValue = 0;
                StatusBarMaxValue = jo["objects"].Cast<JProperty>()
                    .Count(res => !File.Exists(Variables.McDirectory + "\\assets\\legacy\\" + res.Name)) + 1;
                UpdateStatusBarAndLog("Выполняется конвертирование ресурсов...");
                foreach (
                    JProperty res in
                        jo["objects"].Cast<JProperty>()
                            .Where(res => !File.Exists(Variables.McDirectory + "\\assets\\legacy\\" + res.Name))) {
                    try {
                        if (!Directory.Exists(
                            new FileInfo(Variables.McDirectory + "\\assets\\legacy\\" + res.Name).DirectoryName)) {
                            Directory.CreateDirectory(
                                new FileInfo(Variables.McDirectory + "\\assets\\legacy\\" + res.Name).DirectoryName);
                        }
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
                AppendLog("Конвертирование игровых ресурсов завершено.");
            }
            StatusBarVisible = false;
        }

        private string GetLatestVersion(Profile profile)
        {
            JObject versionsList = JObject.Parse(File.ReadAllText(Variables.McVersions + "\\versions.json"));
            return profile.AllowedReleaseTypes.Contains("snapshot")
                ? versionsList["latest"]["snapshot"].ToString()
                : versionsList["latest"]["release"].ToString();
        }

        public object[] AddNewPage()
        {
            RadPageViewPage outputPage = new RadPageViewPage {
                Text = string.Format("{0} ({1})", "ВЫВОД ИГРЫ", _selectedProfile.ProfileName)
            };
            RadButton killProcessButton = new RadButton {
                Text = "Kill Process",
                Anchor = (AnchorStyles.Right | AnchorStyles.Top)
            };
            RadPanel panel = new RadPanel {
                Text = _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile),
                Dock = DockStyle.Top
            };
            panel.Size = new Size(panel.Size.Width, 60);
            RadButton closeButton = new RadButton {
                Text = "Close",
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

        private void UpdateVersionListView()
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action(UpdateVersionListView));
            }
            else {
                versionsListView.Items.Clear();
                foreach (
                    Version version in
                        Directory.GetDirectories(Variables.McVersions)
                            .Select(versionDir => new DirectoryInfo(versionDir))
                            .Select(info => new Version().ParseVersion(info, false))) {
                    versionsListView.Items.Add(version.VersionId, version.ReleaseType,
                        version.InheritsFrom ?? "Independent");
                }
            }
        }

        private void UpdateStatusBarText(string text)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<string>(UpdateStatusBarText), text);
            }
            else {
                StatusBar.Text = text;
            }
        }

        private void UpdateStatusBarAndLog(string text, string methodName = null)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<string, string>(UpdateStatusBarAndLog), text,
                    new StackFrame(1).GetMethod().Name);
            }
            else {
                StatusBar.Text = text;
                AppendLog(text, methodName);
            }
        }

        private void AppendLog(string text, string methodName = null)
        {
            if (logBox.InvokeRequired) {
                logBox.Invoke(new Action<string, string>(AppendLog), text, new StackFrame(1).GetMethod().Name);
            }
            else {
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
            }
            else {
                logBox.AppendText(string.Format(
                    string.IsNullOrEmpty(logBox.Text) ? "[{0}][{1}][{2}] {3}" : "\n[{0}][{1}][{2}] {3}",
                    DateTime.Now.ToString("dd-MM-yy HH:mm:ss"), "ERR",
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
            if (_launcherForm.EnableMinecraftLogging.Checked) {
                _outputReader.Abort();
            }
            _errorReader.Abort();
            AppendLog(
                string.Format("Процесс был завершён с кодом {0}. Сеанс с {1}(Всего {2})",
                    _minecraftProcess.ExitCode +
                    (_minecraftProcess.ExitCode == 0 ? "(Стабильно)" : "(Могли возникнуть проблемы)"),
                    _minecraftProcess.StartTime.ToString("HH:mm:ss"),
                    Math.Round(_minecraftProcess.StartTime.Subtract(DateTime.Now).TotalMinutes, 2)
                        .ToString(CultureInfo.InvariantCulture)
                        .Replace('-', ' ') + " минут"), false);
            _launcherForm.Invoke((MethodInvoker) delegate {
                _closePageButton.Enabled = true;
                if (_launcherForm.CloseGameOutput.Checked && _minecraftProcess.ExitCode == 0) {
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
            }
            else {
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
