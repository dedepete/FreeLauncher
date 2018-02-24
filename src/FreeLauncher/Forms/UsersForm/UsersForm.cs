using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using dotMCLauncher.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace FreeLauncher.Forms
{
    public partial class UsersForm : RadForm
    {
        private readonly Configuration _configuration;

        private readonly UserManager _userManager;

        public UsersForm(Configuration configuration)
        {
            _configuration = configuration;
            InitializeComponent();
            LoadLocalization();
            _userManager = File.Exists(_configuration.McLauncher + @"\users.json")
                ? JsonConvert.DeserializeObject<UserManager>(File.ReadAllText(_configuration.McLauncher + @"\users.json"))
                : new UserManager();
            UpdateUsers();
        }

        private void YesNoToggleSwitch_ValueChanged(object sender, EventArgs e)
        {
            PasswordTextBox.Enabled = YesNoToggleSwitch.Value;
            TextBox_TextChanged(this, EventArgs.Empty);
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserButton.Enabled = false;
            UsernameTextBox.Enabled = false;
            PasswordTextBox.Enabled = false;
            YesNoToggleSwitch.Enabled = false;
            ControlBox = false;
            AddUserButton.Text = _configuration.Localization.PleaseWait;
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += delegate {
                User user = new User {
                    Username = UsernameTextBox.Text
                };
                if (!YesNoToggleSwitch.Value) {
                    user.Type = "offline";
                    if (_userManager.Accounts.ContainsKey(user.Username)) {
                        _userManager.Accounts[user.Username] = user;
                    } else {
                        _userManager.Accounts.Add(user.Username, user);
                    }
                    _userManager.SelectedUsername = user.Username;
                    SaveUsers();
                    UpdateUsers();
                    return;
                }
                AuthManager auth = new AuthManager {
                    Email = UsernameTextBox.Text, Password = PasswordTextBox.Text
                };
                try {
                    auth.Login();
                    user.Type = auth.IsLegacy ? "legacy" : "mojang";
                    user.AccessToken = auth.AccessToken;
                    user.ClientToken = auth.ClientToken;
                    user.Uuid = auth.Uuid;
                    user.UserProperties = auth.UserProperties;
                    if (_userManager.Accounts.ContainsKey(user.Username)) {
                        _userManager.Accounts[user.Username] = user;
                    } else {
                        _userManager.Accounts.Add(user.Username, user);
                    }
                    _userManager.SelectedUsername = user.Username;
                } catch (WebException ex) {
                    if (ex.Status != WebExceptionStatus.ProtocolError) {
                        return;
                    }
                    RadMessageBox.Show(_configuration.Localization.IncorrectLoginOrPassword,
                        _configuration.Localization.Error, MessageBoxButtons.OK,
                        RadMessageIcon.Error);
                    return;
                }
                Invoke(new Action(() => {
                    SaveUsers();
                    UpdateUsers();
                    UsernameTextBox.Clear();
                    PasswordTextBox.Clear();
                }));
            };
            bgw.RunWorkerCompleted += delegate {
                UsernameTextBox.Enabled = true;
                YesNoToggleSwitch.Enabled = true;
                ControlBox = true;
                AddUserButton.Text = _configuration.Localization.AddNewUserButton;
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

        private void SaveUsers()
        {
            File.WriteAllText(_configuration.McLauncher + @"\users.json",
                JsonConvert.SerializeObject(_userManager, Formatting.Indented,
                    new JsonSerializerSettings {
                        NullValueHandling = NullValueHandling.Ignore
                    }));
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            _userManager.Accounts.Remove(UsersListControl.SelectedItem.Tag.ToString());
            SaveUsers();
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
            ApplicationLocalization localization = _configuration.Localization;
            DeleteUserButton.Text = localization.RemoveSelectedUser;
            AddNewUserBox.Text = localization.AddNewUserBox;
            NicknameLabel.Text = localization.Nickname;
            LicenseQuestionLabel.Text = localization.LicenseQuestion;
            PasswordLabel.Text = localization.Password;
            AddUserButton.Text = localization.AddNewUserButton;
        }
    }

    public class UserManager
    {
        [JsonProperty("selectedUsername")]
        public string SelectedUsername { get; set; }

        [JsonProperty("users")]
        public Dictionary<string, User> Accounts { get; set; } = new Dictionary<string, User>();
    }

    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("sessionToken")]
        public string ClientToken { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("properties")]
        public JArray UserProperties { get; set; }
    }
}
