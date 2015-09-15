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
            this.AddNewUser = new Telerik.WinControls.UI.RadGroupBox();
            this.AddUserButton = new Telerik.WinControls.UI.RadButton();
            this.PasswordTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.UsernameTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.YesNoToggleSwitch = new Telerik.WinControls.UI.RadToggleSwitch();
            this.vs2012theme = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            ((System.ComponentModel.ISupportInitialize)(this.UsersListControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteUserButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddNewUser)).BeginInit();
            this.AddNewUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddUserButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Powered by dotMCLauncher.YaDra4il (Yggdrasil for .NET)";
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
            // AddNewUser
            // 
            this.AddNewUser.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.AddNewUser.Controls.Add(this.AddUserButton);
            this.AddNewUser.Controls.Add(this.PasswordTextBox);
            this.AddNewUser.Controls.Add(this.radLabel3);
            this.AddNewUser.Controls.Add(this.radLabel2);
            this.AddNewUser.Controls.Add(this.UsernameTextBox);
            this.AddNewUser.Controls.Add(this.radLabel1);
            this.AddNewUser.Controls.Add(this.YesNoToggleSwitch);
            this.AddNewUser.HeaderText = "Добавление нового аккаунта";
            this.AddNewUser.Location = new System.Drawing.Point(216, -1);
            this.AddNewUser.Name = "AddNewUser";
            this.AddNewUser.Size = new System.Drawing.Size(236, 135);
            this.AddNewUser.TabIndex = 3;
            this.AddNewUser.Text = "Добавление нового аккаунта";
            this.AddNewUser.ThemeName = "VisualStudio2012Dark";
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
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(5, 75);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(47, 18);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Пароль:";
            this.radLabel3.ThemeName = "VisualStudio2012Dark";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(5, 51);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(161, 18);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "У вас лицензионный аккаунт?";
            this.radLabel2.ThemeName = "VisualStudio2012Dark";
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
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(5, 21);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(65, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Логин/Ник:";
            this.radLabel1.ThemeName = "VisualStudio2012Dark";
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
            this.Controls.Add(this.AddNewUser);
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
            ((System.ComponentModel.ISupportInitialize)(this.AddNewUser)).EndInit();
            this.AddNewUser.ResumeLayout(false);
            this.AddNewUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddUserButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YesNoToggleSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadListControl UsersListControl;
        private Telerik.WinControls.UI.RadButton DeleteUserButton;
        private Telerik.WinControls.UI.RadGroupBox AddNewUser;
        private Telerik.WinControls.UI.RadToggleSwitch YesNoToggleSwitch;
        private Telerik.WinControls.UI.RadButton AddUserButton;
        private Telerik.WinControls.UI.RadTextBox PasswordTextBox;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox UsernameTextBox;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme vs2012theme;
    }
}
