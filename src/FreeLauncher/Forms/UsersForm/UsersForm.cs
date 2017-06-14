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
        private readonly ApplicationContext _applicationContext;

        private readonly UserManager _userManager;

        public UsersForm(ApplicationContext appContext)
        {
            _applicationContext = appContext;
            InitializeComponent();
            LoadLocalization();
            _userManager = File.Exists(_applicationContext.McLauncher + @"\users.json")
                ? JsonConvert.DeserializeObject<UserManager>(File.ReadAllText(_applicationContext.McLauncher + @"\users.json"))
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
            AddUserButton.Text = _applicationContext.ProgramLocalization.PleaseWait;
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
                    if (ex.Status != WebExceptionStatus.ProtocolError) {
                        return;
                    }
                    RadMessageBox.Show(_applicationContext.ProgramLocalization.IncorrectLoginOrPassword,
                        _applicationContext.ProgramLocalization.Error, MessageBoxButtons.OK,
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
                AddUserButton.Text = _applicationContext.ProgramLocalization.AddNewUserButton;
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
            File.WriteAllText(_applicationContext.McLauncher + @"\users.json",
                JsonConvert.SerializeObject(_userManager, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
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
            DeleteUserButton.Text = _applicationContext.ProgramLocalization.RemoveSelectedUser;
            AddNewUserBox.Text = _applicationContext.ProgramLocalization.AddNewUserBox;
            NicknameLabel.Text = _applicationContext.ProgramLocalization.Nickname;
            LicenseQuestionLabel.Text = _applicationContext.ProgramLocalization.LicenseQuestion;
            PasswordLabel.Text = _applicationContext.ProgramLocalization.Password;
            AddUserButton.Text = _applicationContext.ProgramLocalization.AddNewUserButton;
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
