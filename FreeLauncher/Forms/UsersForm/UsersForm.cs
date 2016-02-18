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

        private void IsLicenseAccountSwitch_ValueChanged(object sender, EventArgs e)
        {
            PasswordTextBox.Enabled = IsLicenseAccountSwitch.Value;
            TextBox_TextChanged(this, EventArgs.Empty);
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserButton.Enabled = false;
            UsernameTextBox.Enabled = false;
            PasswordTextBox.Enabled = false;
            IsLicenseAccountSwitch.Enabled = false;
            ControlBox = false;
            AddUserButton.Text = _localization.PleaseWait;
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += AddUserOnBackground;
            bgw.RunWorkerCompleted += AddUserCompleted;
            bgw.RunWorkerAsync();
        }

        private void AddUserCompleted(Object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            UsernameTextBox.Enabled = true;
            IsLicenseAccountSwitch.Enabled = true;
            ControlBox = true;
            AddUserButton.Text = _localization.AddNewUserButton;
            IsLicenseAccountSwitch_ValueChanged(this, EventArgs.Empty);
        }

        private void AddUserOnBackground(Object sender, DoWorkEventArgs doWorkEventArgs)
        {
            User newUser = new User {
                Username = UsernameTextBox.Text
            };

            if (!IsLicenseAccountSwitch.Value) {
                newUser.Type = "offline";
                _userManager.Accounts[newUser.Username] = newUser;
                _userManager.SelectedUsername = newUser.Username;
                _userManager.Save();
                UpdateUsers();
                return;
            }

            AuthManager auth = new AuthManager {
                Email = UsernameTextBox.Text,
                Password = PasswordTextBox.Text
            };

            try {
                auth.Login();
                newUser.Type = auth.IsLegacy ? "legacy" : "mojang";
                newUser.AccessToken = auth.AccessToken;
                newUser.SessionToken = auth.SessionToken;
                newUser.Uuid = auth.Uuid;
                newUser.UserProperties = auth.UserProperties;
                _userManager.Accounts[newUser.Username] = newUser;
                _userManager.SelectedUsername = newUser.Username;
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
            var isUserNameEmpty = string.IsNullOrWhiteSpace(UsernameTextBox.Text);
            if (isUserNameEmpty) {
                AddUserButton.Enabled = false;
                return;
            }

            var isPasswordEmpty = string.IsNullOrWhiteSpace(PasswordTextBox.Text);
            var isLicenseAccount = IsLicenseAccountSwitch.Value;
            AddUserButton.Enabled = !isLicenseAccount || !isPasswordEmpty;
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
}
