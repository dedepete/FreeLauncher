using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using dotMCLauncher.Core;
using Newtonsoft.Json.Linq;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace FreeLauncher.Forms
{
    public partial class ProfileForm : RadForm
    {
        private readonly Configuration _configuration;

        public Profile Profile { get; set; }

        public ProfileForm(Profile profile, Configuration configuration)
        {
            _configuration = configuration;
            Profile = profile;
            InitializeComponent();
            LoadLocalization();
            if (Profile.AllowedReleaseTypes != null) {
                foreach (string item in Profile.AllowedReleaseTypes) {
                    switch (item) {
                        case "snapshot":
                            snapshotsCheckBox.Checked = true;
                            break;
                        case "old_beta":
                            betaCheckBox.Checked = true;
                            break;
                        case "old_alpha":
                            alphaCheckBox.Checked = true;
                            break;
                        case "other":
                            otherCheckBox.Checked = true;
                            break;
                        default:
                            continue;
                    }
                }
            }
            GetVersions();
            nameBox.Text = Profile.ProfileName;
            if (Profile.WorkingDirectory != null) {
                GameDirectoryCheckBox.Checked = true;
                gameDirectoryBox.Text = Profile.WorkingDirectory;
            } else {
                gameDirectoryBox.Text = _configuration.McDirectory;
            }
            if (Profile.WindowInfo != null) {
                xResolutionBox.Text = Profile.WindowInfo.Width.ToString();
                yResolutionBox.Text = Profile.WindowInfo.Height.ToString();
            }
            if (Profile.ConnectionSettigs != null) {
                FastConnectCheckBox.Checked = true;
                ipTextBox.Text = Profile.ConnectionSettigs.ServerIp;
                portTextBox.Text = Profile.ConnectionSettigs.ServerPort.ToString();
            }
            switch (Profile.LauncherVisibilityOnGameClose) {
                case Profile.LauncherVisibility.HIDDEN:
                    stateBox.SelectedIndex = 1;
                    break;
                case Profile.LauncherVisibility.CLOSED:
                    stateBox.SelectedIndex = 2;
                    break;
                default:
                    stateBox.SelectedIndex = 0;
                    break;
            }
            if (Java.JavaExecutable == @"\bin\java.exe") {
                RadMessageBox.Show(this, _configuration.Localization.JavaDetectionFailed,
                    _configuration.Localization.Error, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            javaExecutableBox.Text = Profile.JavaExecutable ?? Java.JavaExecutable;
            JavaExecutableCheckBox.Checked = javaExecutableBox.Text != Java.JavaExecutable;
            javaArgumentsBox.Text = Profile.JavaArguments ?? "-Xmx1G";
            JavaArgumentsCheckBox.Checked = javaArgumentsBox.Text != "-Xmx1G";
        }

        private void LoadLocalization()
        {
            ApplicationLocalization localization = _configuration.Localization;

            MainProfileSettingsGroupBox.Text = localization.MainProfileSettingsGroup;
            VersionSettingsGroupBox.Text = localization.VersionSettingsGroup;
            JavaSettingsGroupBox.Text = localization.JavaSettingsGroup;

            ProfileNameLabel.Text = localization.ProfileName;
            GameDirectoryCheckBox.Text = localization.WorkingDirectory;
            WindowResolutionLabel.Text = localization.WindowResolution;
            ActionAfterLaunchLabel.Text = localization.ActionAfterLaunch;
            stateBox.Items[0].Text = localization.KeepLauncherOpen;
            stateBox.Items[1].Text = localization.HideLauncher;
            stateBox.Items[2].Text = localization.CloseLauncher;
            FastConnectCheckBox.Text = localization.Autoconnect;

            snapshotsCheckBox.Text = localization.Snapshots;
            betaCheckBox.Text = localization.Beta;
            alphaCheckBox.Text = localization.Alpha;
            otherCheckBox.Text = localization.Other;

            JavaExecutableCheckBox.Text = localization.JavaExecutable;
            JavaArgumentsCheckBox.Text = localization.JavaFlags;

            cancelButton.Text = localization.Cancel;
            openGameDirectoryButton.Text = localization.OpenDirectory;
            saveProfileButton.Text = localization.Save;
        }

        private void saveProfileButton_Click(object sender, EventArgs e)
        {
            Profile.ProfileName = nameBox.Text;
            if (GameDirectoryCheckBox.Checked &&
                !new[] {
                    _configuration.McDirectory, _configuration.McDirectory + "/",
                    _configuration.McDirectory + @"\",
                    string.Empty
                }.Contains(gameDirectoryBox.Text) &&
                gameDirectoryBox.Text != string.Empty) {
                Profile.WorkingDirectory = gameDirectoryBox.Text;
            } else {
                Profile.WorkingDirectory = null;
            }
            if ((xResolutionBox.Text != "854" || yResolutionBox.Text != "480") && xResolutionBox.Text != string.Empty &&
                yResolutionBox.Text != string.Empty) {
                WindowInfo winInfo = new WindowInfo {
                    Width = Convert.ToInt32(xResolutionBox.Text),
                    Height = Convert.ToInt32(yResolutionBox.Text)
                };
                Profile.WindowInfo = winInfo;
            } else {
                Profile.WindowInfo = null;
            }
            if (FastConnectCheckBox.Checked && ipTextBox.Text != null) {
                Profile.ConnectionSettigs = new ServerInfo {
                    ServerIp = ipTextBox.Text,
                    ServerPort = Convert.ToUInt32((portTextBox.Text != string.Empty
                        ? portTextBox.Text
                        : "25565"))
                };
            } else {
                Profile.ConnectionSettigs = null;
            }
            switch (stateBox.SelectedItem.Tag.ToString()) {
                case "hide launcher and re-open when game closes":
                    Profile.LauncherVisibilityOnGameClose = Profile.LauncherVisibility.HIDDEN;
                    break;
                case "close launcher when game starts":
                    Profile.LauncherVisibilityOnGameClose = Profile.LauncherVisibility.CLOSED;
                    break;
                default:
                    Profile.LauncherVisibilityOnGameClose = Profile.LauncherVisibility.VISIBLE;
                    break;
            }
            List<string> types = new List<string>();
            if (snapshotsCheckBox.Checked) {
                types.Add("snapshot");
            }
            if (betaCheckBox.Checked) {
                types.Add("old_beta");
            }
            if (alphaCheckBox.Checked) {
                types.Add("old_alpha");
            }
            if (otherCheckBox.Checked) {
                types.Add("other");
            }
            if (types.Count == 0) {
                types = null;
            }
            Profile.SelectedVersion = versionsDropDownList.SelectedItem.Tag?.ToString();
            Profile.AllowedReleaseTypes = types?.ToArray();
            if (JavaArgumentsCheckBox.Checked && javaArgumentsBox.Text != "-Xmx1G" &&
                javaArgumentsBox.Text != string.Empty) {
                Profile.JavaArguments = javaArgumentsBox.Text;
            } else {
                Profile.JavaArguments = null;
            }
            if (JavaExecutableCheckBox.Checked && javaExecutableBox.Text != Java.JavaExecutable &&
                javaExecutableBox.Text != string.Empty) {
                Profile.JavaExecutable = javaExecutableBox.Text;
            } else {
                Profile.JavaExecutable = null;
            }
        }

        private void GetVersions()
        {
            versionsDropDownList.Items.Clear();
            versionsDropDownList.Items.Add(_configuration.Localization.UseLatestVersion);
            List<string> list = new List<string>();
            JObject json = JObject.Parse(File.ReadAllText(_configuration.McVersions + @"\versions.json"));
            foreach (JObject ver in json["versions"]) {
                string id = ver["id"].ToString(),
                       type = ver["type"].ToString(),
                       text = $"{type} {id}";
                list.Add(string.Format("{0} {1}", type, id));
                if (IsVersionInstalled(id)) {
                    text += " \u2705";
                }
                RadListDataItem ritem = new RadListDataItem {
                    Text = text, Tag = id
                };
                switch (type) {
                    case "snapshot":
                        if (snapshotsCheckBox.Checked) {
                            versionsDropDownList.Items.Add(ritem);
                        }
                        break;
                    case "old_beta":
                        if (betaCheckBox.Checked) {
                            versionsDropDownList.Items.Add(ritem);
                        }
                        break;
                    case "old_alpha":
                        if (alphaCheckBox.Checked) {
                            versionsDropDownList.Items.Add(ritem);
                        }
                        break;
                    case "release":
                        versionsDropDownList.Items.Add(ritem);
                        break;
                    default:
                        if (otherCheckBox.Checked) {
                            versionsDropDownList.Items.Add(ritem);
                        }
                        break;
                }
            }
            if (otherCheckBox.Checked) {
                foreach (VersionManifest version in from b in Directory.GetDirectories(_configuration.McVersions)
                    where File.Exists(string.Format(@"{0}\{1}\{1}.json", _configuration.McVersions,
                        new DirectoryInfo(b).Name))
                    let add = list.All(a => !a.Contains(new DirectoryInfo(b).Name))
                    where add
                    where VersionManifest.IsValid(new DirectoryInfo(string.Format(@"{0}\{1}\", _configuration.McVersions,
                        new DirectoryInfo(b).Name)))
                    select
                    VersionManifest.ParseVersion(
                        new DirectoryInfo(string.Format(@"{0}\{1}\", _configuration.McVersions,
                            new DirectoryInfo(b).Name)), false)) {
                    versionsDropDownList.Items.Add(new RadListDataItem(version.ReleaseType + " " + version.VersionId) {
                        Tag = version.VersionId
                    });
                }
            }
            versionsDropDownList.Items[0].Text = string.Format(versionsDropDownList.Items[0].Text, versionsDropDownList.Items[1].Tag);
            if (IsVersionInstalled(versionsDropDownList.Items[1].Tag.ToString())) {
                versionsDropDownList.Items[0].Text += " \u2705";
            }
            if (Profile.SelectedVersion != null) {
                foreach (
                    RadListDataItem a in
                    versionsDropDownList.Items.Where(a => a.Tag?.ToString() == Profile.SelectedVersion)) {
                    versionsDropDownList.SelectedItem = a;
                    return;
                }
            }
            versionsDropDownList.SelectedIndex = 0;
        }

        private bool IsVersionInstalled(string id)
        {
            return File.Exists(string.Format(@"{0}\{1}\{1}.json", _configuration.McVersions,
                new DirectoryInfo(id).Name)) && File.Exists(string.Format(@"{0}\{1}\{1}.jar", _configuration.McVersions,
                new DirectoryInfo(id).Name));
        }

        private void versionCheckBoxes_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            GetVersions();
        }

        private void gameDirectoryCheckBox_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            gameDirectoryBox.Enabled = GameDirectoryCheckBox.Checked;
        }

        private void fastConnectCheckBox_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ipTextBox.Enabled = FastConnectCheckBox.Checked;
            portTextBox.Enabled = FastConnectCheckBox.Checked;
        }

        private void javaExecutableCheckBox_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            javaExecutableBox.Enabled = JavaExecutableCheckBox.Checked;
        }

        private void javaArgumentsCheckBox_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            javaArgumentsBox.Enabled = JavaArgumentsCheckBox.Checked;
        }

        private void openGameDirectoryButton_Click(object sender, EventArgs e)
        {
            Process.Start(gameDirectoryBox.Text);
        }
    }
}
