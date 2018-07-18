using System.ComponentModel;
using Telerik.WinControls.UI;

namespace FreeLauncher.Forms
{
    partial class ProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.JavaSettingsGroupBox = new Telerik.WinControls.UI.RadGroupBox();
            this.javaExecutableBox = new Telerik.WinControls.UI.RadTextBox();
            this.JavaExecutableCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.javaArgumentsBox = new Telerik.WinControls.UI.RadTextBox();
            this.JavaArgumentsCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.VersionSettingsGroupBox = new Telerik.WinControls.UI.RadGroupBox();
            this.snapshotsCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.otherCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.betaCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.versionsDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.alphaCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.MainProfileSettingsGroupBox = new Telerik.WinControls.UI.RadGroupBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.portTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.ipTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.FastConnectCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.ActionAfterLaunchLabel = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.yResolutionBox = new Telerik.WinControls.UI.RadTextBox();
            this.xResolutionBox = new Telerik.WinControls.UI.RadTextBox();
            this.WindowResolutionLabel = new Telerik.WinControls.UI.RadLabel();
            this.stateBox = new Telerik.WinControls.UI.RadDropDownList();
            this.gameDirectoryBox = new Telerik.WinControls.UI.RadTextBox();
            this.GameDirectoryCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.ProfileNameLabel = new Telerik.WinControls.UI.RadLabel();
            this.nameBox = new Telerik.WinControls.UI.RadTextBox();
            this.cancelButton = new Telerik.WinControls.UI.RadButton();
            this.openGameDirectoryButton = new Telerik.WinControls.UI.RadButton();
            this.saveProfileButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.JavaSettingsGroupBox)).BeginInit();
            this.JavaSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.javaExecutableBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JavaExecutableCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.javaArgumentsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JavaArgumentsCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VersionSettingsGroupBox)).BeginInit();
            this.VersionSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snapshotsCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betaCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.versionsDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainProfileSettingsGroupBox)).BeginInit();
            this.MainProfileSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FastConnectCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActionAfterLaunchLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yResolutionBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xResolutionBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WindowResolutionLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameDirectoryBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameDirectoryCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGameDirectoryButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveProfileButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // JavaSettingsGroupBox
            // 
            this.JavaSettingsGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.JavaSettingsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.JavaSettingsGroupBox.Controls.Add(this.javaExecutableBox);
            this.JavaSettingsGroupBox.Controls.Add(this.JavaExecutableCheckBox);
            this.JavaSettingsGroupBox.Controls.Add(this.javaArgumentsBox);
            this.JavaSettingsGroupBox.Controls.Add(this.JavaArgumentsCheckBox);
            this.JavaSettingsGroupBox.HeaderText = "Настройки Java";
            this.JavaSettingsGroupBox.Location = new System.Drawing.Point(5, 326);
            this.JavaSettingsGroupBox.Name = "JavaSettingsGroupBox";
            this.JavaSettingsGroupBox.Size = new System.Drawing.Size(330, 75);
            this.JavaSettingsGroupBox.TabIndex = 7;
            this.JavaSettingsGroupBox.Text = "Настройки Java";
            this.JavaSettingsGroupBox.ThemeName = "VisualStudio2012Dark";
            // 
            // javaExecutableBox
            // 
            this.javaExecutableBox.Enabled = false;
            this.javaExecutableBox.Location = new System.Drawing.Point(145, 20);
            this.javaExecutableBox.Name = "javaExecutableBox";
            this.javaExecutableBox.Size = new System.Drawing.Size(177, 24);
            this.javaExecutableBox.TabIndex = 7;
            this.javaExecutableBox.ThemeName = "VisualStudio2012Dark";
            // 
            // JavaExecutableCheckBox
            // 
            this.JavaExecutableCheckBox.Location = new System.Drawing.Point(3, 21);
            this.JavaExecutableCheckBox.Name = "JavaExecutableCheckBox";
            this.JavaExecutableCheckBox.Size = new System.Drawing.Size(128, 18);
            this.JavaExecutableCheckBox.TabIndex = 6;
            this.JavaExecutableCheckBox.Text = "Исполняемый файл:";
            this.JavaExecutableCheckBox.ThemeName = "VisualStudio2012Dark";
            this.JavaExecutableCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.javaExecutableCheckBox_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.JavaExecutableCheckBox.GetChildAt(0))).Text = "Исполняемый файл:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.JavaExecutableCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // javaArgumentsBox
            // 
            this.javaArgumentsBox.Enabled = false;
            this.javaArgumentsBox.Location = new System.Drawing.Point(145, 47);
            this.javaArgumentsBox.Name = "javaArgumentsBox";
            this.javaArgumentsBox.Size = new System.Drawing.Size(177, 24);
            this.javaArgumentsBox.TabIndex = 5;
            this.javaArgumentsBox.ThemeName = "VisualStudio2012Dark";
            // 
            // JavaArgumentsCheckBox
            // 
            this.JavaArgumentsCheckBox.Location = new System.Drawing.Point(3, 48);
            this.JavaArgumentsCheckBox.Name = "JavaArgumentsCheckBox";
            this.JavaArgumentsCheckBox.Size = new System.Drawing.Size(81, 18);
            this.JavaArgumentsCheckBox.TabIndex = 4;
            this.JavaArgumentsCheckBox.Text = "Флаги JVM:";
            this.JavaArgumentsCheckBox.ThemeName = "VisualStudio2012Dark";
            this.JavaArgumentsCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.javaArgumentsCheckBox_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.JavaArgumentsCheckBox.GetChildAt(0))).Text = "Флаги JVM:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.JavaArgumentsCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // VersionSettingsGroupBox
            // 
            this.VersionSettingsGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.VersionSettingsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.VersionSettingsGroupBox.Controls.Add(this.snapshotsCheckBox);
            this.VersionSettingsGroupBox.Controls.Add(this.otherCheckBox);
            this.VersionSettingsGroupBox.Controls.Add(this.betaCheckBox);
            this.VersionSettingsGroupBox.Controls.Add(this.versionsDropDownList);
            this.VersionSettingsGroupBox.Controls.Add(this.alphaCheckBox);
            this.VersionSettingsGroupBox.HeaderText = "Выбор версии";
            this.VersionSettingsGroupBox.Location = new System.Drawing.Point(5, 164);
            this.VersionSettingsGroupBox.Name = "VersionSettingsGroupBox";
            this.VersionSettingsGroupBox.Size = new System.Drawing.Size(330, 156);
            this.VersionSettingsGroupBox.TabIndex = 6;
            this.VersionSettingsGroupBox.Text = "Выбор версии";
            this.VersionSettingsGroupBox.ThemeName = "VisualStudio2012Dark";
            // 
            // snapshotsCheckBox
            // 
            this.snapshotsCheckBox.Location = new System.Drawing.Point(10, 30);
            this.snapshotsCheckBox.Name = "snapshotsCheckBox";
            this.snapshotsCheckBox.Size = new System.Drawing.Size(304, 18);
            this.snapshotsCheckBox.TabIndex = 8;
            this.snapshotsCheckBox.Text = "Отображать экспериментальные сборки (\"snapshots\")";
            this.snapshotsCheckBox.ThemeName = "VisualStudio2012Dark";
            this.snapshotsCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.versionCheckBoxes_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.snapshotsCheckBox.GetChildAt(0))).Text = "Отображать экспериментальные сборки (\"snapshots\")";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.snapshotsCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // otherCheckBox
            // 
            this.otherCheckBox.Location = new System.Drawing.Point(10, 102);
            this.otherCheckBox.Name = "otherCheckBox";
            this.otherCheckBox.Size = new System.Drawing.Size(301, 18);
            this.otherCheckBox.TabIndex = 12;
            this.otherCheckBox.Text = "Отображать сторонние версии(Forge, LiteLoader, etc.)";
            this.otherCheckBox.ThemeName = "VisualStudio2012Dark";
            this.otherCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.versionCheckBoxes_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.otherCheckBox.GetChildAt(0))).Text = "Отображать сторонние версии(Forge, LiteLoader, etc.)";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.otherCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // betaCheckBox
            // 
            this.betaCheckBox.Location = new System.Drawing.Point(10, 54);
            this.betaCheckBox.Name = "betaCheckBox";
            this.betaCheckBox.Size = new System.Drawing.Size(261, 18);
            this.betaCheckBox.TabIndex = 9;
            this.betaCheckBox.Text = "Отображать старые \"Beta\" сборки(2010-2011)";
            this.betaCheckBox.ThemeName = "VisualStudio2012Dark";
            this.betaCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.versionCheckBoxes_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.betaCheckBox.GetChildAt(0))).Text = "Отображать старые \"Beta\" сборки(2010-2011)";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.betaCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // versionsDropDownList
            // 
            this.versionsDropDownList.AutoCompleteDisplayMember = null;
            this.versionsDropDownList.AutoCompleteValueMember = null;
            this.versionsDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.versionsDropDownList.Location = new System.Drawing.Point(10, 126);
            this.versionsDropDownList.Name = "versionsDropDownList";
            this.versionsDropDownList.Size = new System.Drawing.Size(310, 24);
            this.versionsDropDownList.TabIndex = 11;
            this.versionsDropDownList.ThemeName = "VisualStudio2012Dark";
            // 
            // alphaCheckBox
            // 
            this.alphaCheckBox.Location = new System.Drawing.Point(10, 78);
            this.alphaCheckBox.Name = "alphaCheckBox";
            this.alphaCheckBox.Size = new System.Drawing.Size(253, 18);
            this.alphaCheckBox.TabIndex = 10;
            this.alphaCheckBox.Text = "Отображать старые \"Alpha\" сборки(от 2010)";
            this.alphaCheckBox.ThemeName = "VisualStudio2012Dark";
            this.alphaCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.versionCheckBoxes_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.alphaCheckBox.GetChildAt(0))).Text = "Отображать старые \"Alpha\" сборки(от 2010)";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.alphaCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // MainProfileSettingsGroupBox
            // 
            this.MainProfileSettingsGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.MainProfileSettingsGroupBox.Controls.Add(this.radButton1);
            this.MainProfileSettingsGroupBox.Controls.Add(this.portTextBox);
            this.MainProfileSettingsGroupBox.Controls.Add(this.ipTextBox);
            this.MainProfileSettingsGroupBox.Controls.Add(this.FastConnectCheckBox);
            this.MainProfileSettingsGroupBox.Controls.Add(this.ActionAfterLaunchLabel);
            this.MainProfileSettingsGroupBox.Controls.Add(this.radLabel3);
            this.MainProfileSettingsGroupBox.Controls.Add(this.yResolutionBox);
            this.MainProfileSettingsGroupBox.Controls.Add(this.xResolutionBox);
            this.MainProfileSettingsGroupBox.Controls.Add(this.WindowResolutionLabel);
            this.MainProfileSettingsGroupBox.Controls.Add(this.stateBox);
            this.MainProfileSettingsGroupBox.Controls.Add(this.gameDirectoryBox);
            this.MainProfileSettingsGroupBox.Controls.Add(this.GameDirectoryCheckBox);
            this.MainProfileSettingsGroupBox.Controls.Add(this.ProfileNameLabel);
            this.MainProfileSettingsGroupBox.Controls.Add(this.nameBox);
            this.MainProfileSettingsGroupBox.HeaderText = "Основные настройки профиля";
            this.MainProfileSettingsGroupBox.Location = new System.Drawing.Point(5, 2);
            this.MainProfileSettingsGroupBox.Name = "MainProfileSettingsGroupBox";
            this.MainProfileSettingsGroupBox.Size = new System.Drawing.Size(330, 156);
            this.MainProfileSettingsGroupBox.TabIndex = 5;
            this.MainProfileSettingsGroupBox.Text = "Основные настройки профиля";
            this.MainProfileSettingsGroupBox.ThemeName = "VisualStudio2012Dark";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(280, 72);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(42, 20);
            this.radButton1.TabIndex = 13;
            this.radButton1.Text = "...";
            this.radButton1.ThemeName = "VisualStudio2012Dark";
            // 
            // portTextBox
            // 
            this.portTextBox.Enabled = false;
            this.portTextBox.Location = new System.Drawing.Point(280, 124);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.NullText = "Порт";
            this.portTextBox.Size = new System.Drawing.Size(42, 24);
            this.portTextBox.TabIndex = 12;
            this.portTextBox.ThemeName = "VisualStudio2012Dark";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Enabled = false;
            this.ipTextBox.Location = new System.Drawing.Point(145, 124);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.NullText = "IP";
            this.ipTextBox.Size = new System.Drawing.Size(129, 24);
            this.ipTextBox.TabIndex = 11;
            this.ipTextBox.ThemeName = "VisualStudio2012Dark";
            // 
            // FastConnectCheckBox
            // 
            this.FastConnectCheckBox.Location = new System.Drawing.Point(3, 127);
            this.FastConnectCheckBox.Name = "FastConnectCheckBox";
            this.FastConnectCheckBox.Size = new System.Drawing.Size(122, 18);
            this.FastConnectCheckBox.TabIndex = 10;
            this.FastConnectCheckBox.Text = "Автоподключение:";
            this.FastConnectCheckBox.ThemeName = "VisualStudio2012Dark";
            this.FastConnectCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.fastConnectCheckBox_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.FastConnectCheckBox.GetChildAt(0))).Text = "Автоподключение:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.FastConnectCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // ActionAfterLaunchLabel
            // 
            this.ActionAfterLaunchLabel.BackColor = System.Drawing.Color.Transparent;
            this.ActionAfterLaunchLabel.Location = new System.Drawing.Point(1, 98);
            this.ActionAfterLaunchLabel.Name = "ActionAfterLaunchLabel";
            this.ActionAfterLaunchLabel.Size = new System.Drawing.Size(134, 18);
            this.ActionAfterLaunchLabel.TabIndex = 9;
            this.ActionAfterLaunchLabel.Text = "После запуска Minecraft:";
            this.ActionAfterLaunchLabel.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.ActionAfterLaunchLabel.GetChildAt(0))).Text = "После запуска Minecraft:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.ActionAfterLaunchLabel.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Location = new System.Drawing.Point(203, 73);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(13, 18);
            this.radLabel3.TabIndex = 8;
            this.radLabel3.Text = "Х";
            this.radLabel3.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel3.GetChildAt(0))).Text = "Х";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel3.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // yResolutionBox
            // 
            this.yResolutionBox.Location = new System.Drawing.Point(222, 72);
            this.yResolutionBox.Name = "yResolutionBox";
            this.yResolutionBox.Size = new System.Drawing.Size(52, 24);
            this.yResolutionBox.TabIndex = 7;
            this.yResolutionBox.Text = "480";
            this.yResolutionBox.ThemeName = "VisualStudio2012Dark";
            // 
            // xResolutionBox
            // 
            this.xResolutionBox.Location = new System.Drawing.Point(145, 72);
            this.xResolutionBox.Name = "xResolutionBox";
            this.xResolutionBox.Size = new System.Drawing.Size(52, 24);
            this.xResolutionBox.TabIndex = 6;
            this.xResolutionBox.Text = "854";
            this.xResolutionBox.ThemeName = "VisualStudio2012Dark";
            // 
            // WindowResolutionLabel
            // 
            this.WindowResolutionLabel.BackColor = System.Drawing.Color.Transparent;
            this.WindowResolutionLabel.Location = new System.Drawing.Point(1, 73);
            this.WindowResolutionLabel.Name = "WindowResolutionLabel";
            this.WindowResolutionLabel.Size = new System.Drawing.Size(85, 18);
            this.WindowResolutionLabel.TabIndex = 5;
            this.WindowResolutionLabel.Text = "Размер экрана:";
            this.WindowResolutionLabel.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.WindowResolutionLabel.GetChildAt(0))).Text = "Размер экрана:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.WindowResolutionLabel.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // stateBox
            // 
            this.stateBox.AutoCompleteDisplayMember = null;
            this.stateBox.AutoCompleteValueMember = null;
            this.stateBox.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Tag = "keep the launcher open";
            radListDataItem1.Text = "Оставить лаунчер открытым";
            radListDataItem2.Tag = "hide launcher and re-open when game closes";
            radListDataItem2.Text = "Скрыть лаунчер";
            radListDataItem3.Tag = "close launcher when game starts";
            radListDataItem3.Text = "Закрыть лаунчер";
            this.stateBox.Items.Add(radListDataItem1);
            this.stateBox.Items.Add(radListDataItem2);
            this.stateBox.Items.Add(radListDataItem3);
            this.stateBox.Location = new System.Drawing.Point(145, 98);
            this.stateBox.Name = "stateBox";
            this.stateBox.Size = new System.Drawing.Size(177, 24);
            this.stateBox.TabIndex = 4;
            this.stateBox.ThemeName = "VisualStudio2012Dark";
            // 
            // gameDirectoryBox
            // 
            this.gameDirectoryBox.Enabled = false;
            this.gameDirectoryBox.Location = new System.Drawing.Point(145, 46);
            this.gameDirectoryBox.Name = "gameDirectoryBox";
            this.gameDirectoryBox.Size = new System.Drawing.Size(177, 24);
            this.gameDirectoryBox.TabIndex = 3;
            this.gameDirectoryBox.ThemeName = "VisualStudio2012Dark";
            // 
            // GameDirectoryCheckBox
            // 
            this.GameDirectoryCheckBox.Location = new System.Drawing.Point(3, 47);
            this.GameDirectoryCheckBox.Name = "GameDirectoryCheckBox";
            this.GameDirectoryCheckBox.Size = new System.Drawing.Size(133, 18);
            this.GameDirectoryCheckBox.TabIndex = 2;
            this.GameDirectoryCheckBox.Text = "Рабочая директория:";
            this.GameDirectoryCheckBox.ThemeName = "VisualStudio2012Dark";
            this.GameDirectoryCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.gameDirectoryCheckBox_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.GameDirectoryCheckBox.GetChildAt(0))).Text = "Рабочая директория:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.GameDirectoryCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // ProfileNameLabel
            // 
            this.ProfileNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProfileNameLabel.Location = new System.Drawing.Point(1, 21);
            this.ProfileNameLabel.Name = "ProfileNameLabel";
            this.ProfileNameLabel.Size = new System.Drawing.Size(107, 18);
            this.ProfileNameLabel.TabIndex = 1;
            this.ProfileNameLabel.Text = "Название профиля:";
            this.ProfileNameLabel.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.ProfileNameLabel.GetChildAt(0))).Text = "Название профиля:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.ProfileNameLabel.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(145, 20);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(177, 24);
            this.nameBox.TabIndex = 0;
            this.nameBox.ThemeName = "VisualStudio2012Dark";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(5, 411);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(86, 34);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.ThemeName = "VisualStudio2012Dark";
            // 
            // openGameDirectoryButton
            // 
            this.openGameDirectoryButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.openGameDirectoryButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.openGameDirectoryButton.Location = new System.Drawing.Point(101, 411);
            this.openGameDirectoryButton.Name = "openGameDirectoryButton";
            this.openGameDirectoryButton.Size = new System.Drawing.Size(111, 34);
            this.openGameDirectoryButton.TabIndex = 10;
            this.openGameDirectoryButton.Text = "Открыть раб. директорию";
            this.openGameDirectoryButton.TextWrap = true;
            this.openGameDirectoryButton.ThemeName = "VisualStudio2012Dark";
            this.openGameDirectoryButton.Click += new System.EventHandler(this.openGameDirectoryButton_Click);
            // 
            // saveProfileButton
            // 
            this.saveProfileButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveProfileButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveProfileButton.Location = new System.Drawing.Point(218, 411);
            this.saveProfileButton.Name = "saveProfileButton";
            this.saveProfileButton.Size = new System.Drawing.Size(117, 34);
            this.saveProfileButton.TabIndex = 9;
            this.saveProfileButton.Text = "Сохранить профиль";
            this.saveProfileButton.ThemeName = "VisualStudio2012Dark";
            this.saveProfileButton.Click += new System.EventHandler(this.saveProfileButton_Click);
            // 
            // ProfileForm
            // 
            this.AcceptButton = this.saveProfileButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(341, 447);
            this.Controls.Add(this.openGameDirectoryButton);
            this.Controls.Add(this.saveProfileButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.JavaSettingsGroupBox);
            this.Controls.Add(this.VersionSettingsGroupBox);
            this.Controls.Add(this.MainProfileSettingsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "ProfileForm";
            this.ThemeName = "VisualStudio2012Dark";
            ((System.ComponentModel.ISupportInitialize)(this.JavaSettingsGroupBox)).EndInit();
            this.JavaSettingsGroupBox.ResumeLayout(false);
            this.JavaSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.javaExecutableBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JavaExecutableCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.javaArgumentsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JavaArgumentsCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VersionSettingsGroupBox)).EndInit();
            this.VersionSettingsGroupBox.ResumeLayout(false);
            this.VersionSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snapshotsCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betaCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.versionsDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainProfileSettingsGroupBox)).EndInit();
            this.MainProfileSettingsGroupBox.ResumeLayout(false);
            this.MainProfileSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FastConnectCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActionAfterLaunchLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yResolutionBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xResolutionBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WindowResolutionLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameDirectoryBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameDirectoryCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGameDirectoryButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveProfileButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RadGroupBox JavaSettingsGroupBox;
        private RadTextBox javaExecutableBox;
        private RadCheckBox JavaExecutableCheckBox;
        private RadTextBox javaArgumentsBox;
        private RadCheckBox JavaArgumentsCheckBox;
        private RadGroupBox VersionSettingsGroupBox;
        private RadGroupBox MainProfileSettingsGroupBox;
        private RadButton radButton1;
        private RadTextBox portTextBox;
        private RadTextBox ipTextBox;
        private RadCheckBox FastConnectCheckBox;
        private RadLabel ActionAfterLaunchLabel;
        private RadLabel radLabel3;
        private RadTextBox yResolutionBox;
        private RadTextBox xResolutionBox;
        private RadLabel WindowResolutionLabel;
        private RadDropDownList stateBox;
        private RadTextBox gameDirectoryBox;
        private RadCheckBox GameDirectoryCheckBox;
        private RadLabel ProfileNameLabel;
        public RadTextBox nameBox;
        private RadButton cancelButton;
        private RadButton openGameDirectoryButton;
        private RadButton saveProfileButton;
        private RadCheckBox snapshotsCheckBox;
        private RadCheckBox otherCheckBox;
        private RadCheckBox betaCheckBox;
        public RadDropDownList versionsDropDownList;
        private RadCheckBox alphaCheckBox;
    }
}
