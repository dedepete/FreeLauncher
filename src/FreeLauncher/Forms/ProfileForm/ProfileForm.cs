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
        private readonly ApplicationContext _applicationContext;

        public Profile CurrentProfile;

        public ProfileForm(Profile profile, ApplicationContext appContext)
        {
            _applicationContext = appContext;
            CurrentProfile = profile;
            InitializeComponent();
            LoadLocalization();
            if (CurrentProfile.AllowedReleaseTypes != null) {
                foreach (string item in CurrentProfile.AllowedReleaseTypes) {
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
                        case "forge":
                            forgeCheckBox.Checked = true;
                            goto case "modified";
                        case "liteloader":
                            liteCheckBox.Checked = true;
                            goto case "modified";
                        case "optifine":
                            optifineCheckBox.Checked = true;
                            goto case "modified";
                        case "combined":
                            combinedCheckBox.Checked = true;
                            goto case "modified";
                        case "modified":
                            VersionSelector.SelectedPage = modVersionsPage;
                            break;
                        default:
                            throw new InvalidOperationException($"Unexpected value: {item}");
                    }
                }
            }
            GetVersions();
            nameBox.Text = CurrentProfile.ProfileName;
            if (CurrentProfile.WorkingDirectory != null) {
                GameDirectoryCheckBox.Checked = true;
                gameDirectoryBox.Text = CurrentProfile.WorkingDirectory;
            } else {
                gameDirectoryBox.Text = _applicationContext.McDirectory;
            }
            if (CurrentProfile.WindowInfo != null) {
                xResolutionBox.Text = CurrentProfile.WindowInfo.X.ToString();
                yResolutionBox.Text = CurrentProfile.WindowInfo.Y.ToString();
            }
            if (CurrentProfile.FastConnectionSettigs != null) {
                FastConnectCheckBox.Checked = true;
                ipTextBox.Text = CurrentProfile.FastConnectionSettigs.ServerIP;
                portTextBox.Text = CurrentProfile.FastConnectionSettigs.ServerPort.ToString();
            }
            switch (CurrentProfile.LauncherVisibilityOnGameClose) {
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
            if (Java.JavaExecutable == "\\bin\\java.exe") {
                RadMessageBox.Show(this, _applicationContext.ProgramLocalization.JavaDetectionFailed,
                    _applicationContext.ProgramLocalization.Error, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            javaExecutableBox.Text = CurrentProfile.JavaExecutable ?? Java.JavaExecutable;
            JavaExecutableCheckBox.Checked = javaExecutableBox.Text != Java.JavaExecutable;
            javaArgumentsBox.Text = CurrentProfile.JavaArguments ?? "-Xmx1G";
            JavaArgumentsCheckBox.Checked = javaArgumentsBox.Text != "-Xmx1G";
        }

        private void LoadLocalization()
        {
            ProfileNameLabel.Text = _applicationContext.ProgramLocalization.ProfileName;
            GameDirectoryCheckBox.Text = _applicationContext.ProgramLocalization.WorkingDirectory;
            WindowResolutionLabel.Text = _applicationContext.ProgramLocalization.WindowResolution;
            ActionAfterLaunchLabel.Text = _applicationContext.ProgramLocalization.ActionAfterLaunch;
            FastConnectCheckBox.Text = _applicationContext.ProgramLocalization.Autoconnect;
            snapshotsCheckBox.Text = _applicationContext.ProgramLocalization.Snapshots;
            betaCheckBox.Text = _applicationContext.ProgramLocalization.Beta;
            alphaCheckBox.Text = _applicationContext.ProgramLocalization.Alpha;
            otherCheckBox.Text = _applicationContext.ProgramLocalization.Other;
            JavaExecutableCheckBox.Text = _applicationContext.ProgramLocalization.JavaExecutable;
            JavaArgumentsCheckBox.Text = _applicationContext.ProgramLocalization.JavaFlags;
            cancelButton.Text = _applicationContext.ProgramLocalization.Cancel;
            openGameDirectoryButton.Text = _applicationContext.ProgramLocalization.OpenDirectory;
            saveProfileButton.Text = _applicationContext.ProgramLocalization.Save;
        }

        private void saveProfileButton_Click(object sender, EventArgs e)
        {
            CurrentProfile.ProfileName = nameBox.Text;
            if (GameDirectoryCheckBox.Checked && gameDirectoryBox.Text != _applicationContext.McDirectory &&
                gameDirectoryBox.Text != string.Empty) {
                CurrentProfile.WorkingDirectory = gameDirectoryBox.Text;
            } else {
                CurrentProfile.WorkingDirectory = null;
            }
            if ((xResolutionBox.Text != "854" || yResolutionBox.Text != "480") && xResolutionBox.Text != string.Empty &&
                yResolutionBox.Text != string.Empty) {
                WindowInfo winInfo = new WindowInfo {
                    X = Convert.ToInt32(xResolutionBox.Text),
                    Y = Convert.ToInt32(yResolutionBox.Text)
                };
                CurrentProfile.WindowInfo = winInfo;
            } else {
                CurrentProfile.WindowInfo = null;
            }
            if (FastConnectCheckBox.Checked && ipTextBox.Text != null) {
                CurrentProfile.FastConnectionSettigs = new ServerInfo {
                    ServerIP = ipTextBox.Text,
                    ServerPort = Convert.ToUInt32((portTextBox.Text != string.Empty
                        ? portTextBox.Text
                        : "25565"))
                };
            } else {
                CurrentProfile.FastConnectionSettigs = null;
            }
            switch (stateBox.SelectedItem.Tag.ToString()) {
                case "hide launcher and re-open when game closes":
                    CurrentProfile.LauncherVisibilityOnGameClose = Profile.LauncherVisibility.HIDDEN;
                    break;
                case "close launcher when game starts":
                    CurrentProfile.LauncherVisibilityOnGameClose = Profile.LauncherVisibility.CLOSED;
                    break;
                default:
                    CurrentProfile.LauncherVisibilityOnGameClose = Profile.LauncherVisibility.VISIBLE;
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
            if (VersionSelector.SelectedPage == modVersionsPage) {
                if (forgeCheckBox.Checked) {
                    types.Add("forge");
                }
                if (liteCheckBox.Checked) {
                    types.Add("liteloader");
                }
                if (optifineCheckBox.Checked) {
                    types.Add("optifine");
                }
                if (combinedCheckBox.Checked) {
                    types.Add("combined");
                }
                types.Add("modified");
            }
            if (types.Count == 0) {
                types = null;
            }
            CurrentProfile.SelectedVersion = versionsDropDownList.SelectedItem.Tag?.ToString();
            CurrentProfile.AllowedReleaseTypes = types?.ToArray();
            if (JavaArgumentsCheckBox.Checked && javaArgumentsBox.Text != "-Xmx1G" &&
                javaArgumentsBox.Text != string.Empty) {
                CurrentProfile.JavaArguments = javaArgumentsBox.Text;
            } else {
                CurrentProfile.JavaArguments = null;
            }
            if (JavaExecutableCheckBox.Checked && javaExecutableBox.Text != Java.JavaExecutable &&
                javaExecutableBox.Text != string.Empty) {
                CurrentProfile.JavaExecutable = javaExecutableBox.Text;
            } else {
                CurrentProfile.JavaExecutable = null;
            }
        }

        //TODO: Add modified versions
        private void GetVersions()
        {
            versionsDropDownList.Items.Clear();
            versionsDropDownList.Items.Add(_applicationContext.ProgramLocalization.UseLatestVersion);
            List<string> list = new List<string>();
            JObject json = JObject.Parse(File.ReadAllText(_applicationContext.McVersions + "/versions.json"));
            foreach (JObject ver in json["versions"]) {
                string id = ver["id"].ToString(),
                    type = ver["type"].ToString();
                list.Add(string.Format("{0} {1}", type, id));
                RadListDataItem ritem = new RadListDataItem {Text = type + " " + id, Tag = id};
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
                foreach (VersionManifest version in from b in Directory.GetDirectories(_applicationContext.McVersions)
                    where File.Exists(string.Format("{0}/{1}/{1}.json", _applicationContext.McVersions,
                        new DirectoryInfo(b).Name))
                    let add = list.All(a => !a.Contains(new DirectoryInfo(b).Name))
                    where add
                    where VersionManifest.IsValid(new DirectoryInfo(string.Format("{0}/{1}/", _applicationContext.McVersions,
                                new DirectoryInfo(b).Name)))
                    select
                        VersionManifest.ParseVersion(
                            new DirectoryInfo(string.Format("{0}/{1}/", _applicationContext.McVersions,
                                new DirectoryInfo(b).Name)), false)) {
                    versionsDropDownList.Items.Add(new RadListDataItem(version.ReleaseType + " " + version.VersionId) {
                        Tag = version.VersionId
                    });
                }
            }
            if (CurrentProfile.SelectedVersion != null) {
                foreach (
                    RadListDataItem a in
                    versionsDropDownList.Items.Where(a => a.Tag?.ToString() == CurrentProfile.SelectedVersion)) {
                    versionsDropDownList.SelectedItem = a;
                    return;
                }
            }
            versionsDropDownList.SelectedIndex = 0;
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
            ipTextBox.Enabled = portTextBox.Enabled = FastConnectCheckBox.Checked;
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
