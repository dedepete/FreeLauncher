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
        private readonly UserManager _userManager;

        public UsersForm()
        {
            InitializeComponent();
            LoadLocalization();
            _userManager = File.Exists(ApplicationContext.McLauncher + "users.json")
                ? JsonConvert.DeserializeObject<UserManager>(File.ReadAllText(ApplicationContext.McLauncher + "users.json"))
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
            AddUserButton.Enabled =
                UsernameTextBox.Enabled = PasswordTextBox.Enabled = YesNoToggleSwitch.Enabled = false;
            ControlBox = false;
            AddUserButton.Text = ApplicationContext.ProgramLocalization.PleaseWait;
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += delegate {
                User user = new User {Username = UsernameTextBox.Text};
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
                AuthManager auth = new AuthManager {Email = UsernameTextBox.Text, Password = PasswordTextBox.Text};
                try {
                    auth.Login();
                    user.Type = auth.IsLegacy ? "legacy" : "mojang";
                    user.AccessToken = auth.AccessToken;
                    user.SessionToken = auth.SessionToken;
                    user.Uuid = auth.Uuid;
                    user.UserProperties = auth.UserProperties;
                    if (_userManager.Accounts.ContainsKey(user.Username)) {
                        _userManager.Accounts[user.Username] = user;
                    } else {
                        _userManager.Accounts.Add(user.Username, user);
                    }
                    _userManager.SelectedUsername = user.Username;
                }
                catch (WebException ex) {
                    switch (ex.Status) {
                        case WebExceptionStatus.ProtocolError:
                            RadMessageBox.Show(ApplicationContext.ProgramLocalization.IncorrectLoginOrPassword, ApplicationContext.ProgramLocalization.Error, MessageBoxButtons.OK,
                                RadMessageIcon.Error);
                            return;
                        default:
                            return;
                    }
                }
                Invoke(new Action(() => {
                    SaveUsers();
                    UpdateUsers();
                    UsernameTextBox.Clear();
                    PasswordTextBox.Clear();
                }));
            };
            bgw.RunWorkerCompleted += delegate {
                UsernameTextBox.Enabled = YesNoToggleSwitch.Enabled = true;
                ControlBox = true;
                AddUserButton.Text = ApplicationContext.ProgramLocalization.AddNewUserButton;
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
            File.WriteAllText(ApplicationContext.McLauncher + "users.json",
                JsonConvert.SerializeObject(_userManager, Formatting.Indented,
                    new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore}));
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
            DeleteUserButton.Text = ApplicationContext.ProgramLocalization.RemoveSelectedUser;
            AddNewUserBox.Text = ApplicationContext.ProgramLocalization.AddNewUserBox;
            NicknameLabel.Text = ApplicationContext.ProgramLocalization.Nickname;
            LicenseQuestionLabel.Text = ApplicationContext.ProgramLocalization.LicenseQuestion;
            PasswordLabel.Text = ApplicationContext.ProgramLocalization.Password;
            AddUserButton.Text = ApplicationContext.ProgramLocalization.AddNewUserButton;
        }
    }

    public class UserManager
    {
        [JsonProperty("selectedUsername")] public string SelectedUsername;
        [JsonProperty("users")] public Dictionary<string, User> Accounts = new Dictionary<string, User>();
    }

    public class User
    {
        [JsonProperty("username")] public string Username;
        [JsonProperty("type")] public string Type;
        [JsonProperty("uuid")] public string Uuid;
        [JsonProperty("sessionToken")] public string SessionToken;
        [JsonProperty("accessToken")] public string AccessToken;
        [JsonProperty("properties")] public JArray UserProperties;
    }
}
