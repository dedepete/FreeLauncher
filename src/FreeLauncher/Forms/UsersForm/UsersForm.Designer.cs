namespace FreeLauncher.Forms
{
    partial class UsersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.UsersListControl = new Telerik.WinControls.UI.RadListControl();
            this.DeleteUserButton = new Telerik.WinControls.UI.RadButton();
            this.AddNewUserBox = new Telerik.WinControls.UI.RadGroupBox();
            this.AddUserButton = new Telerik.WinControls.UI.RadButton();
            this.PasswordTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.PasswordLabel = new Telerik.WinControls.UI.RadLabel();
            this.LicenseQuestionLabel = new Telerik.WinControls.UI.RadLabel();
            this.UsernameTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.NicknameLabel = new Telerik.WinControls.UI.RadLabel();
            this.YesNoToggleSwitch = new Telerik.WinControls.UI.RadToggleSwitch();
            this.vs2012theme = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            ((System.ComponentModel.ISupportInitialize)(this.UsersListControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteUserButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddNewUserBox)).BeginInit();
            this.AddNewUserBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddUserButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LicenseQuestionLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NicknameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YesNoToggleSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(1, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Powered by dotMCLauncher.Yggdrasil";
            // 
            // UsersListControl
            // 
            this.UsersListControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UsersListControl.Location = new System.Drawing.Point(12, -1);
            this.UsersListControl.Name = "UsersListControl";
            this.UsersListControl.Size = new System.Drawing.Size(198, 189);
            this.UsersListControl.TabIndex = 1;
            this.UsersListControl.ThemeName = "VisualStudio2012Dark";
            this.UsersListControl.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.UsersListControl_SelectedIndexChanged);
            // 
            // DeleteUserButton
            // 
            this.DeleteUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteUserButton.Enabled = false;
            this.DeleteUserButton.Location = new System.Drawing.Point(12, 194);
            this.DeleteUserButton.Name = "DeleteUserButton";
            this.DeleteUserButton.Size = new System.Drawing.Size(198, 25);
            this.DeleteUserButton.TabIndex = 2;
            this.DeleteUserButton.Text = "Удалить выбранного пользователя";
            this.DeleteUserButton.ThemeName = "VisualStudio2012Dark";
            this.DeleteUserButton.Click += new System.EventHandler(this.DeleteUserButton_Click);
            // 
            // AddNewUserBox
            // 
            this.AddNewUserBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.AddNewUserBox.Controls.Add(this.AddUserButton);
            this.AddNewUserBox.Controls.Add(this.PasswordTextBox);
            this.AddNewUserBox.Controls.Add(this.PasswordLabel);
            this.AddNewUserBox.Controls.Add(this.LicenseQuestionLabel);
            this.AddNewUserBox.Controls.Add(this.UsernameTextBox);
            this.AddNewUserBox.Controls.Add(this.NicknameLabel);
            this.AddNewUserBox.Controls.Add(this.YesNoToggleSwitch);
            this.AddNewUserBox.HeaderText = "Добавление нового аккаунта";
            this.AddNewUserBox.Location = new System.Drawing.Point(216, -1);
            this.AddNewUserBox.Name = "AddNewUserBox";
            this.AddNewUserBox.Size = new System.Drawing.Size(236, 135);
            this.AddNewUserBox.TabIndex = 3;
            this.AddNewUserBox.Text = "Добавление нового аккаунта";
            this.AddNewUserBox.ThemeName = "VisualStudio2012Dark";
            // 
            // AddUserButton
            // 
            this.AddUserButton.Enabled = false;
            this.AddUserButton.Location = new System.Drawing.Point(5, 104);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(226, 25);
            this.AddUserButton.TabIndex = 6;
            this.AddUserButton.Text = "Добавить нового пользователя";
            this.AddUserButton.ThemeName = "VisualStudio2012Dark";
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Enabled = false;
            this.PasswordTextBox.Location = new System.Drawing.Point(73, 74);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '●';
            this.PasswordTextBox.Size = new System.Drawing.Size(158, 24);
            this.PasswordTextBox.TabIndex = 5;
            this.PasswordTextBox.ThemeName = "VisualStudio2012Dark";
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(5, 75);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(47, 18);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Пароль:";
            this.PasswordLabel.ThemeName = "VisualStudio2012Dark";
            // 
            // LicenseQuestionLabel
            // 
            this.LicenseQuestionLabel.Location = new System.Drawing.Point(5, 51);
            this.LicenseQuestionLabel.Name = "LicenseQuestionLabel";
            this.LicenseQuestionLabel.Size = new System.Drawing.Size(161, 18);
            this.LicenseQuestionLabel.TabIndex = 3;
            this.LicenseQuestionLabel.Text = "У вас лицензионный аккаунт?";
            this.LicenseQuestionLabel.ThemeName = "VisualStudio2012Dark";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(73, 20);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(158, 24);
            this.UsernameTextBox.TabIndex = 2;
            this.UsernameTextBox.ThemeName = "VisualStudio2012Dark";
            this.UsernameTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // NicknameLabel
            // 
            this.NicknameLabel.Location = new System.Drawing.Point(5, 21);
            this.NicknameLabel.Name = "NicknameLabel";
            this.NicknameLabel.Size = new System.Drawing.Size(65, 18);
            this.NicknameLabel.TabIndex = 1;
            this.NicknameLabel.Text = "Логин/Ник:";
            this.NicknameLabel.ThemeName = "VisualStudio2012Dark";
            // 
            // YesNoToggleSwitch
            // 
            this.YesNoToggleSwitch.Location = new System.Drawing.Point(190, 50);
            this.YesNoToggleSwitch.Name = "YesNoToggleSwitch";
            this.YesNoToggleSwitch.OffText = "NO";
            this.YesNoToggleSwitch.OnText = "YES";
            this.YesNoToggleSwitch.Size = new System.Drawing.Size(41, 20);
            this.YesNoToggleSwitch.TabIndex = 0;
            this.YesNoToggleSwitch.ThemeName = "VisualStudio2012Dark";
            this.YesNoToggleSwitch.ThumbTickness = 15;
            this.YesNoToggleSwitch.Value = false;
            this.YesNoToggleSwitch.ValueChanged += new System.EventHandler(this.YesNoToggleSwitch_ValueChanged);
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 236);
            this.Controls.Add(this.AddNewUserBox);
            this.Controls.Add(this.DeleteUserButton);
            this.Controls.Add(this.UsersListControl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsersForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "UsersForm";
            this.ThemeName = "VisualStudio2012Dark";
            ((System.ComponentModel.ISupportInitialize)(this.UsersListControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteUserButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddNewUserBox)).EndInit();
            this.AddNewUserBox.ResumeLayout(false);
            this.AddNewUserBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddUserButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LicenseQuestionLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NicknameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YesNoToggleSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadListControl UsersListControl;
        private Telerik.WinControls.UI.RadButton DeleteUserButton;
        private Telerik.WinControls.UI.RadGroupBox AddNewUserBox;
        private Telerik.WinControls.UI.RadToggleSwitch YesNoToggleSwitch;
        private Telerik.WinControls.UI.RadButton AddUserButton;
        private Telerik.WinControls.UI.RadTextBox PasswordTextBox;
        private Telerik.WinControls.UI.RadLabel PasswordLabel;
        private Telerik.WinControls.UI.RadLabel LicenseQuestionLabel;
        private Telerik.WinControls.UI.RadTextBox UsernameTextBox;
        private Telerik.WinControls.UI.RadLabel NicknameLabel;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme vs2012theme;
    }
}
