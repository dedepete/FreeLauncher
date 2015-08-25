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
        public Profile CurrentProfile;

        public ProfileForm(Profile profile)
        {
            CurrentProfile = profile;
            InitializeComponent();
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
                gameDirectoryCheckBox.Checked = true;
                gameDirectoryBox.Text = CurrentProfile.WorkingDirectory;
            } else {
                gameDirectoryBox.Text = Variables.McDirectory;
            }
            if (CurrentProfile.WindowSize != null) {
                xResolutionBox.Text = CurrentProfile.WindowSize.X.ToString();
                yResolutionBox.Text = CurrentProfile.WindowSize.Y.ToString();
            }
            if (CurrentProfile.FastConnectionSettigs != null) {
                fastConnectCheckBox.Checked = true;
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
                RadMessageBox.Show(this,
                    "Не удалось определить путь до Java! Пожалуйста, укажите путь к исполняемому файлу вручную.",
                    "Ошибка", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            javaExecutableBox.Text = CurrentProfile.JavaExecutable ?? Java.JavaExecutable;
            javaExecutableCheckBox.Checked = javaExecutableBox.Text != Java.JavaExecutable;
            javaArgumentsBox.Text = CurrentProfile.JavaArguments ?? "-Xmx1G";
            javaArgumentsCheckBox.Checked = javaArgumentsBox.Text != "-Xmx1G";
        }

        private void saveProfileButton_Click(object sender, EventArgs e)
        {
            CurrentProfile.ProfileName = nameBox.Text;
            if (gameDirectoryCheckBox.Checked && gameDirectoryBox.Text != Variables.McDirectory &&
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
            if (fastConnectCheckBox.Checked && ipTextBox.Text != null) {
                CurrentProfile.FastConnectionSettigs = new ConnectionSettings() {
                    ServerIP = ipTextBox.Text,
                    ServerPort = Convert.ToInt32((portTextBox.Text != string.Empty
                        ? portTextBox.Text
                        : "25565"))
                };
            }
            else {
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
            List<string> types = new List<string>
            {
                "release"
            };
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
            CurrentProfile.SelectedVersion = versionsDropDownList.SelectedItem.Tag?.ToString();
            CurrentProfile.AllowedReleaseTypes = types.ToArray();
            if (javaArgumentsCheckBox.Checked && javaArgumentsBox.Text != "-Xmx1G" &&
                javaArgumentsBox.Text != string.Empty) {
                CurrentProfile.JavaArguments = javaArgumentsBox.Text;
            } else {
                CurrentProfile.JavaArguments = null;
            }
            if (javaExecutableCheckBox.Checked && javaExecutableBox.Text != Java.JavaExecutable &&
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
            versionsDropDownList.Items.Add("Use latest version");
            List<string> list = new List<string>();
            JObject json = JObject.Parse(File.ReadAllText(Variables.McVersions + "/versions.json"));
            foreach (JObject ver in json["versions"]) {
                string id = ver["id"].ToString(),
                    type = ver["type"].ToString();
                list.Add(string.Format("{0} {1}", type, id));
                RadListDataItem ritem = new RadListDataItem { Text = type + " " + id, Tag = id };
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
                foreach (Version version in from b in Directory.GetDirectories(Variables.McVersions)
                    where File.Exists(string.Format("{0}/{1}/{1}.json", Variables.McVersions,
                        new DirectoryInfo(b).Name))
                    let add = list.All(a => !a.Contains(new DirectoryInfo(b).Name))
                    where add
                    select
                        new Version().ParseVersion(
                            new DirectoryInfo(string.Format("{0}/{1}/", Variables.McVersions,
                                new DirectoryInfo(b).Name)), false)) {
                    versionsDropDownList.Items.Add(new RadListDataItem(version.ReleaseType + " " + version.VersionId) {
                        Tag = version.VersionId
                    });
                }
            }
            if (CurrentProfile.SelectedVersion != null) {
                foreach (
                    RadListDataItem a in
                        versionsDropDownList.Items.Where(a => a.Text.Contains(CurrentProfile.SelectedVersion))) {
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
            gameDirectoryBox.Enabled = gameDirectoryCheckBox.Checked;
        }

        private void fastConnectCheckBox_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ipTextBox.Enabled = portTextBox.Enabled = fastConnectCheckBox.Checked;
        }

        private void javaExecutableCheckBox_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            javaExecutableBox.Enabled = javaExecutableCheckBox.Checked;
        }

        private void javaArgumentsCheckBox_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            javaArgumentsBox.Enabled = javaArgumentsCheckBox.Checked;
        }

        private void openGameDirectoryButton_Click(object sender, EventArgs e)
        {
            Process.Start(gameDirectoryBox.Text);
        }
    }
}
