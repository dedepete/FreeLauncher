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
using Version = dotMCLauncher.Core.Version;

namespace FreeLauncher.Forms
{
    public partial class ProfileForm : RadForm
    {
        private readonly ApplicationContext _applicationContext;

        private readonly Localization _localization;

        public Profile CurrentProfile;

        public ProfileForm(Profile profile, ApplicationContext appContext)
        {
            _applicationContext = appContext;
            _localization = _applicationContext.ProgramLocalization;
            CurrentProfile = profile;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
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
                    }
                }
            }

            GetVersions();
            nameBox.Text = CurrentProfile.ProfileName;
            if (CurrentProfile.WorkingDirectory != null) {
                GameDirectoryCheckBox.Checked = true;
                gameDirectoryBox.Text = CurrentProfile.WorkingDirectory;
            } else {
                gameDirectoryBox.Text = _applicationContext.MinecraftDirectory;
            }

            if (CurrentProfile.WindowSize != null) {
                xResolutionBox.Text = CurrentProfile.WindowSize.X.ToString();
                yResolutionBox.Text = CurrentProfile.WindowSize.Y.ToString();
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
                RadMessageBox.Show(this, _localization.JavaDetectionFailed,
                    _localization.Error, MessageBoxButtons.OK, RadMessageIcon.Error);
            }

            javaExecutableBox.Text = CurrentProfile.JavaExecutable ?? Java.JavaExecutable;
            JavaExecutableCheckBox.Checked = javaExecutableBox.Text != Java.JavaExecutable;
            javaArgumentsBox.Text = CurrentProfile.JavaArguments ?? "-Xmx1G";
            JavaArgumentsCheckBox.Checked = javaArgumentsBox.Text != "-Xmx1G";
        }

        private void LoadLocalization()
        {
            ProfileNameLabel.Text = _localization.ProfileName;
            GameDirectoryCheckBox.Text = _localization.WorkingDirectory;
            WindowResolutionLabel.Text = _localization.WindowResolution;
            ActionAfterLaunchLabel.Text = _localization.ActionAfterLaunch;
            FastConnectCheckBox.Text = _localization.Autoconnect;
            snapshotsCheckBox.Text = _localization.Snapshots;
            betaCheckBox.Text = _localization.Beta;
            alphaCheckBox.Text = _localization.Alpha;
            otherCheckBox.Text = _localization.Other;
            JavaExecutableCheckBox.Text = _localization.JavaExecutable;
            JavaArgumentsCheckBox.Text = _localization.JavaFlags;
            cancelButton.Text = _localization.Cancel;
            openGameDirectoryButton.Text = _localization.OpenDirectory;
            saveProfileButton.Text = _localization.Save;
        }

        private void saveProfileButton_Click(object sender, EventArgs e)
        {
            CurrentProfile.ProfileName = nameBox.Text;
            if (GameDirectoryCheckBox.Checked && gameDirectoryBox.Text != _applicationContext.MinecraftDirectory &&
                gameDirectoryBox.Text != string.Empty) {
                CurrentProfile.WorkingDirectory = gameDirectoryBox.Text;
            } else {
                CurrentProfile.WorkingDirectory = null;
            }

            if ((xResolutionBox.Text != "854" || yResolutionBox.Text != "480") && xResolutionBox.Text != string.Empty &&
                yResolutionBox.Text != string.Empty) {
                MinecraftWindowSize winSize = new MinecraftWindowSize {
                    X = Convert.ToInt32(xResolutionBox.Text),
                    Y = Convert.ToInt32(yResolutionBox.Text)
                };
                CurrentProfile.WindowSize = winSize;
            } else {
                CurrentProfile.WindowSize = null;
            }

            if (FastConnectCheckBox.Checked && ipTextBox.Text != null) {
                CurrentProfile.FastConnectionSettigs = new ConnectionSettings() {
                    ServerIP = ipTextBox.Text,
                    ServerPort = Convert.ToInt32((portTextBox.Text != string.Empty
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
            versionsDropDownList.Items.Add(_localization.UseLatestVersion);
            List<string> versionsForAdding = new List<string>();
            JObject versionsFile = JObject.Parse(File.ReadAllText(_applicationContext.MinecraftVersionsDirectory + "/versions.json"));
            foreach (JObject ver in versionsFile["versions"]) {
                string id = ver["id"].ToString();
                string type = ver["type"].ToString();
                versionsForAdding.Add($"{type} {id}");
                RadListDataItem ritem = new RadListDataItem {
                    Text = type + " " + id,
                    Tag = id
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
                var versionsDirectory = new DirectoryInfo(_applicationContext.MinecraftVersionsDirectory);
                Func<DirectoryInfo, bool> isVersionCorrected = vd =>
                {
                    var versionFile = Path.Combine(_applicationContext.MinecraftVersionsDirectory, vd.Name, vd.Name + ".json");
                    return File.Exists(versionFile);
                };

                var correctedVersions = versionsDirectory.GetDirectories().Where(vd => isVersionCorrected(vd));
                var modifiedVersionsDirectories = correctedVersions.Where(cv => versionsForAdding.All(vfa => !vfa.Contains(cv.Name)));
                var modifiedVersions = modifiedVersionsDirectories.Select(vd => Version.ParseVersion(new DirectoryInfo(vd.FullName), false)).ToList();
                foreach (var version in modifiedVersions) {
                    var newItem = new RadListDataItem(version.ReleaseType + " " + version.VersionId) {
                        Tag = version.VersionId
                    };

                    versionsDropDownList.Items.Add(newItem);
                }
            }

            if (CurrentProfile.SelectedVersion != null) {
                var requiredItem = versionsDropDownList.Items.FirstOrDefault(item => item.Text.Contains(CurrentProfile.SelectedVersion));
                if (requiredItem != null) {
                    versionsDropDownList.SelectedItem = requiredItem;
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
