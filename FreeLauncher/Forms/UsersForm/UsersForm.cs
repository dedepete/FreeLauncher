using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using dotMCLauncher.YaDra4il;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace FreeLauncher.Forms
{
    public partial class UsersForm : RadForm
    {
        private readonly Localization _localization;

        private readonly UserManager _userManager;

        public UsersForm(ApplicationContext appContext)
        {
            _localization = appContext.ProgramLocalization;
            InitializeComponent();
            LoadLocalization();
            _userManager = UserManager.LoadFromFile(appContext.LauncherDirectory + "users.json");
            UpdateUsers();
        }

        private void YesNoToggleSwitch_ValueChanged(object sender, EventArgs e)
        {
            PasswordTextBox.Enabled = YesNoToggleSwitch.Value;
            TextBox_TextChanged(this, EventArgs.Empty);
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserButton.Enabled =
                UsernameTextBox.Enabled = PasswordTextBox.Enabled = YesNoToggleSwitch.Enabled = false;
            ControlBox = false;
            AddUserButton.Text = _localization.PleaseWait;
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += delegate {
                User user = new User { Username = UsernameTextBox.Text };
                if (!YesNoToggleSwitch.Value) {
                    user.Type = "offline";
                    _userManager.Accounts[user.Username] = user;
                    _userManager.SelectedUsername = user.Username;
                    _userManager.Save();
                    UpdateUsers();
                    return;
                }
                AuthManager auth = new AuthManager { Email = UsernameTextBox.Text, Password = PasswordTextBox.Text };
                try {
                    auth.Login();
                    user.Type = auth.IsLegacy ? "legacy" : "mojang";
                    user.AccessToken = auth.AccessToken;
                    user.SessionToken = auth.SessionToken;
                    user.Uuid = auth.Uuid;
                    user.UserProperties = auth.UserProperties;
                    _userManager.Accounts[user.Username] = user;
                    _userManager.SelectedUsername = user.Username;
                }
                catch (WebException ex) {
                    switch (ex.Status) {
                        case WebExceptionStatus.ProtocolError:
                            RadMessageBox.Show(_localization.IncorrectLoginOrPassword, _localization.Error, MessageBoxButtons.OK,
                                RadMessageIcon.Error);
                            return;
                        default:
                            return;
                    }
                }
                Invoke(new Action(() =>
                {
                    _userManager.Save();
                    UpdateUsers();
                    UsernameTextBox.Clear();
                    PasswordTextBox.Clear();
                }));
            };
            bgw.RunWorkerCompleted += delegate {
                UsernameTextBox.Enabled = YesNoToggleSwitch.Enabled = true;
                ControlBox = true;
                AddUserButton.Text = _localization.AddNewUserButton;
                YesNoToggleSwitch_ValueChanged(this, EventArgs.Empty);
            };
            bgw.RunWorkerAsync();
        }

        private void UpdateUsers()
        {
            UsersListControl.Items.Clear();
            foreach (KeyValuePair<string, User> item in _userManager.Accounts) {
                UsersListControl.Items.Add(new RadListDataItem($"{item.Key}[{_userManager.Accounts[item.Key].Type}]") {
                    Tag = item.Key
                });
            }
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            _userManager.Accounts.Remove(UsersListControl.SelectedItem.Tag.ToString());
            _userManager.Save();
            UpdateUsers();
        }

        private void UsersListControl_SelectedIndexChanged(object sender,
            PositionChangedEventArgs e)
        {
            DeleteUserButton.Enabled = UsersListControl.SelectedItem != null;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UsernameTextBox.Text)) {
                if (!YesNoToggleSwitch.Value ||
                    YesNoToggleSwitch.Value && !string.IsNullOrWhiteSpace(PasswordTextBox.Text)) {
                    AddUserButton.Enabled = true;
                } else if (YesNoToggleSwitch.Value && string.IsNullOrWhiteSpace(PasswordTextBox.Text)) {
                    AddUserButton.Enabled = false;
                }
            } else {
                AddUserButton.Enabled = false;
            }
        }

        private void LoadLocalization()
        {
            DeleteUserButton.Text = _localization.RemoveSelectedUser;
            AddNewUserBox.Text = _localization.AddNewUserBox;
            NicknameLabel.Text = _localization.Nickname;
            LicenseQuestionLabel.Text = _localization.LicenseQuestion;
            PasswordLabel.Text = _localization.Password;
            AddUserButton.Text = _localization.AddNewUserButton;
        }
    }

    public class User
    {
        [JsonProperty("username")]
        public string Username;
        [JsonProperty("type")]
        public string Type;
        [JsonProperty("uuid")]
        public string Uuid;
        [JsonProperty("sessionToken")]
        public string SessionToken;
        [JsonProperty("accessToken")]
        public string AccessToken;
        [JsonProperty("properties")]
        public JArray UserProperties;
    }
}
