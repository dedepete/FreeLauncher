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
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.javaExecutableBox = new Telerik.WinControls.UI.RadTextBox();
            this.javaExecutableCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.javaArgumentsBox = new Telerik.WinControls.UI.RadTextBox();
            this.javaArgumentsCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.otherCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.versionsDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.alphaCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.betaCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.snapshotsCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.portTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.ipTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.fastConnectCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.yResolutionBox = new Telerik.WinControls.UI.RadTextBox();
            this.xResolutionBox = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.stateBox = new Telerik.WinControls.UI.RadDropDownList();
            this.gameDirectoryBox = new Telerik.WinControls.UI.RadTextBox();
            this.gameDirectoryCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.nameBox = new Telerik.WinControls.UI.RadTextBox();
            this.cancelButton = new Telerik.WinControls.UI.RadButton();
            this.openGameDirectoryButton = new Telerik.WinControls.UI.RadButton();
            this.saveProfileButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.javaExecutableBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.javaExecutableCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.javaArgumentsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.javaArgumentsCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.versionsDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betaCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapshotsCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastConnectCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yResolutionBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xResolutionBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameDirectoryBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameDirectoryCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGameDirectoryButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveProfileButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radGroupBox3.Controls.Add(this.javaExecutableBox);
            this.radGroupBox3.Controls.Add(this.javaExecutableCheckBox);
            this.radGroupBox3.Controls.Add(this.javaArgumentsBox);
            this.radGroupBox3.Controls.Add(this.javaArgumentsCheckBox);
            this.radGroupBox3.HeaderText = "Настройки Java";
            this.radGroupBox3.Location = new System.Drawing.Point(5, 308);
            this.radGroupBox3.Name = "radGroupBox3";
            // 
            // 
            // 
            this.radGroupBox3.RootElement.AccessibleDescription = null;
            this.radGroupBox3.RootElement.AccessibleName = null;
            this.radGroupBox3.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radGroupBox3.RootElement.AngleTransform = 0F;
            this.radGroupBox3.RootElement.FlipText = false;
            this.radGroupBox3.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radGroupBox3.RootElement.Text = null;
            this.radGroupBox3.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radGroupBox3.Size = new System.Drawing.Size(330, 75);
            this.radGroupBox3.TabIndex = 7;
            this.radGroupBox3.Text = "Настройки Java";
            this.radGroupBox3.ThemeName = "VisualStudio2012Dark";
            // 
            // javaExecutableBox
            // 
            this.javaExecutableBox.Enabled = false;
            this.javaExecutableBox.Location = new System.Drawing.Point(145, 20);
            this.javaExecutableBox.Name = "javaExecutableBox";
            // 
            // 
            // 
            this.javaExecutableBox.RootElement.AccessibleDescription = null;
            this.javaExecutableBox.RootElement.AccessibleName = null;
            this.javaExecutableBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.javaExecutableBox.RootElement.AngleTransform = 0F;
            this.javaExecutableBox.RootElement.FlipText = false;
            this.javaExecutableBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.javaExecutableBox.RootElement.Text = null;
            this.javaExecutableBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.javaExecutableBox.Size = new System.Drawing.Size(177, 24);
            this.javaExecutableBox.TabIndex = 7;
            this.javaExecutableBox.ThemeName = "VisualStudio2012Dark";
            // 
            // javaExecutableCheckBox
            // 
            this.javaExecutableCheckBox.Location = new System.Drawing.Point(3, 21);
            this.javaExecutableCheckBox.Name = "javaExecutableCheckBox";
            // 
            // 
            // 
            this.javaExecutableCheckBox.RootElement.AccessibleDescription = null;
            this.javaExecutableCheckBox.RootElement.AccessibleName = null;
            this.javaExecutableCheckBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.javaExecutableCheckBox.RootElement.AngleTransform = 0F;
            this.javaExecutableCheckBox.RootElement.FlipText = false;
            this.javaExecutableCheckBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.javaExecutableCheckBox.RootElement.Text = null;
            this.javaExecutableCheckBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.javaExecutableCheckBox.Size = new System.Drawing.Size(128, 18);
            this.javaExecutableCheckBox.TabIndex = 6;
            this.javaExecutableCheckBox.Text = "Исполняемый файл:";
            this.javaExecutableCheckBox.ThemeName = "VisualStudio2012Dark";
            this.javaExecutableCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.javaExecutableCheckBox_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.javaExecutableCheckBox.GetChildAt(0))).Text = "Исполняемый файл:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.javaExecutableCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // javaArgumentsBox
            // 
            this.javaArgumentsBox.Enabled = false;
            this.javaArgumentsBox.Location = new System.Drawing.Point(145, 47);
            this.javaArgumentsBox.Name = "javaArgumentsBox";
            // 
            // 
            // 
            this.javaArgumentsBox.RootElement.AccessibleDescription = null;
            this.javaArgumentsBox.RootElement.AccessibleName = null;
            this.javaArgumentsBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.javaArgumentsBox.RootElement.AngleTransform = 0F;
            this.javaArgumentsBox.RootElement.FlipText = false;
            this.javaArgumentsBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.javaArgumentsBox.RootElement.Text = null;
            this.javaArgumentsBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.javaArgumentsBox.Size = new System.Drawing.Size(177, 24);
            this.javaArgumentsBox.TabIndex = 5;
            this.javaArgumentsBox.ThemeName = "VisualStudio2012Dark";
            // 
            // javaArgumentsCheckBox
            // 
            this.javaArgumentsCheckBox.Location = new System.Drawing.Point(3, 48);
            this.javaArgumentsCheckBox.Name = "javaArgumentsCheckBox";
            // 
            // 
            // 
            this.javaArgumentsCheckBox.RootElement.AccessibleDescription = null;
            this.javaArgumentsCheckBox.RootElement.AccessibleName = null;
            this.javaArgumentsCheckBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.javaArgumentsCheckBox.RootElement.AngleTransform = 0F;
            this.javaArgumentsCheckBox.RootElement.FlipText = false;
            this.javaArgumentsCheckBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.javaArgumentsCheckBox.RootElement.Text = null;
            this.javaArgumentsCheckBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.javaArgumentsCheckBox.Size = new System.Drawing.Size(83, 18);
            this.javaArgumentsCheckBox.TabIndex = 4;
            this.javaArgumentsCheckBox.Text = "Аргументы:";
            this.javaArgumentsCheckBox.ThemeName = "VisualStudio2012Dark";
            this.javaArgumentsCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.javaArgumentsCheckBox_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.javaArgumentsCheckBox.GetChildAt(0))).Text = "Аргументы:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.javaArgumentsCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radGroupBox2.Controls.Add(this.otherCheckBox);
            this.radGroupBox2.Controls.Add(this.versionsDropDownList);
            this.radGroupBox2.Controls.Add(this.alphaCheckBox);
            this.radGroupBox2.Controls.Add(this.betaCheckBox);
            this.radGroupBox2.Controls.Add(this.snapshotsCheckBox);
            this.radGroupBox2.HeaderText = "Выбор версии";
            this.radGroupBox2.Location = new System.Drawing.Point(5, 164);
            this.radGroupBox2.Name = "radGroupBox2";
            // 
            // 
            // 
            this.radGroupBox2.RootElement.AccessibleDescription = null;
            this.radGroupBox2.RootElement.AccessibleName = null;
            this.radGroupBox2.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radGroupBox2.RootElement.AngleTransform = 0F;
            this.radGroupBox2.RootElement.FlipText = false;
            this.radGroupBox2.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radGroupBox2.RootElement.Text = null;
            this.radGroupBox2.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radGroupBox2.Size = new System.Drawing.Size(330, 143);
            this.radGroupBox2.TabIndex = 6;
            this.radGroupBox2.Text = "Выбор версии";
            this.radGroupBox2.ThemeName = "VisualStudio2012Dark";
            // 
            // otherCheckBox
            // 
            this.otherCheckBox.Location = new System.Drawing.Point(3, 93);
            this.otherCheckBox.Name = "otherCheckBox";
            // 
            // 
            // 
            this.otherCheckBox.RootElement.AccessibleDescription = null;
            this.otherCheckBox.RootElement.AccessibleName = null;
            this.otherCheckBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.otherCheckBox.RootElement.AngleTransform = 0F;
            this.otherCheckBox.RootElement.FlipText = false;
            this.otherCheckBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.otherCheckBox.RootElement.Text = null;
            this.otherCheckBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.otherCheckBox.Size = new System.Drawing.Size(156, 18);
            this.otherCheckBox.TabIndex = 7;
            this.otherCheckBox.Text = "Включить прочие версии";
            this.otherCheckBox.ThemeName = "VisualStudio2012Dark";
            this.otherCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.versionCheckBoxes_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.otherCheckBox.GetChildAt(0))).Text = "Включить прочие версии";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.otherCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // versionsDropDownList
            // 
            this.versionsDropDownList.AutoCompleteDisplayMember = null;
            this.versionsDropDownList.AutoCompleteValueMember = null;
            this.versionsDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.versionsDropDownList.Location = new System.Drawing.Point(3, 114);
            this.versionsDropDownList.Name = "versionsDropDownList";
            // 
            // 
            // 
            this.versionsDropDownList.RootElement.AccessibleDescription = null;
            this.versionsDropDownList.RootElement.AccessibleName = null;
            this.versionsDropDownList.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.versionsDropDownList.RootElement.AngleTransform = 0F;
            this.versionsDropDownList.RootElement.FlipText = false;
            this.versionsDropDownList.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.versionsDropDownList.RootElement.Text = null;
            this.versionsDropDownList.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.versionsDropDownList.Size = new System.Drawing.Size(319, 24);
            this.versionsDropDownList.TabIndex = 6;
            this.versionsDropDownList.ThemeName = "VisualStudio2012Dark";
            // 
            // alphaCheckBox
            // 
            this.alphaCheckBox.Location = new System.Drawing.Point(3, 69);
            this.alphaCheckBox.Name = "alphaCheckBox";
            // 
            // 
            // 
            this.alphaCheckBox.RootElement.AccessibleDescription = null;
            this.alphaCheckBox.RootElement.AccessibleName = null;
            this.alphaCheckBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.alphaCheckBox.RootElement.AngleTransform = 0F;
            this.alphaCheckBox.RootElement.FlipText = false;
            this.alphaCheckBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.alphaCheckBox.RootElement.Text = null;
            this.alphaCheckBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.alphaCheckBox.Size = new System.Drawing.Size(240, 18);
            this.alphaCheckBox.TabIndex = 5;
            this.alphaCheckBox.Text = "Включить старые \"Alpha\" сборки(от 2010)";
            this.alphaCheckBox.ThemeName = "VisualStudio2012Dark";
            this.alphaCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.versionCheckBoxes_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.alphaCheckBox.GetChildAt(0))).Text = "Включить старые \"Alpha\" сборки(от 2010)";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.alphaCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // betaCheckBox
            // 
            this.betaCheckBox.Location = new System.Drawing.Point(3, 45);
            this.betaCheckBox.Name = "betaCheckBox";
            // 
            // 
            // 
            this.betaCheckBox.RootElement.AccessibleDescription = null;
            this.betaCheckBox.RootElement.AccessibleName = null;
            this.betaCheckBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.betaCheckBox.RootElement.AngleTransform = 0F;
            this.betaCheckBox.RootElement.FlipText = false;
            this.betaCheckBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.betaCheckBox.RootElement.Text = null;
            this.betaCheckBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.betaCheckBox.Size = new System.Drawing.Size(248, 18);
            this.betaCheckBox.TabIndex = 4;
            this.betaCheckBox.Text = "Включить старые \"Beta\" сборки(2010-2011)";
            this.betaCheckBox.ThemeName = "VisualStudio2012Dark";
            this.betaCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.versionCheckBoxes_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.betaCheckBox.GetChildAt(0))).Text = "Включить старые \"Beta\" сборки(2010-2011)";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.betaCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // snapshotsCheckBox
            // 
            this.snapshotsCheckBox.Location = new System.Drawing.Point(3, 21);
            this.snapshotsCheckBox.Name = "snapshotsCheckBox";
            // 
            // 
            // 
            this.snapshotsCheckBox.RootElement.AccessibleDescription = null;
            this.snapshotsCheckBox.RootElement.AccessibleName = null;
            this.snapshotsCheckBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.snapshotsCheckBox.RootElement.AngleTransform = 0F;
            this.snapshotsCheckBox.RootElement.FlipText = false;
            this.snapshotsCheckBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.snapshotsCheckBox.RootElement.Text = null;
            this.snapshotsCheckBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.snapshotsCheckBox.Size = new System.Drawing.Size(291, 18);
            this.snapshotsCheckBox.TabIndex = 3;
            this.snapshotsCheckBox.Text = "Включить экспериментальные сборки (\"snapshots\")";
            this.snapshotsCheckBox.ThemeName = "VisualStudio2012Dark";
            this.snapshotsCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.versionCheckBoxes_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.snapshotsCheckBox.GetChildAt(0))).Text = "Включить экспериментальные сборки (\"snapshots\")";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.snapshotsCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radButton1);
            this.radGroupBox1.Controls.Add(this.portTextBox);
            this.radGroupBox1.Controls.Add(this.ipTextBox);
            this.radGroupBox1.Controls.Add(this.fastConnectCheckBox);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.yResolutionBox);
            this.radGroupBox1.Controls.Add(this.xResolutionBox);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.stateBox);
            this.radGroupBox1.Controls.Add(this.gameDirectoryBox);
            this.radGroupBox1.Controls.Add(this.gameDirectoryCheckBox);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.nameBox);
            this.radGroupBox1.HeaderText = "Основные настройки профиля";
            this.radGroupBox1.Location = new System.Drawing.Point(5, 2);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.AccessibleDescription = null;
            this.radGroupBox1.RootElement.AccessibleName = null;
            this.radGroupBox1.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radGroupBox1.RootElement.AngleTransform = 0F;
            this.radGroupBox1.RootElement.FlipText = false;
            this.radGroupBox1.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radGroupBox1.RootElement.Text = null;
            this.radGroupBox1.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radGroupBox1.Size = new System.Drawing.Size(330, 156);
            this.radGroupBox1.TabIndex = 5;
            this.radGroupBox1.Text = "Основные настройки профиля";
            this.radGroupBox1.ThemeName = "VisualStudio2012Dark";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(280, 72);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(42, 24);
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
            // 
            // 
            // 
            this.portTextBox.RootElement.AccessibleDescription = null;
            this.portTextBox.RootElement.AccessibleName = null;
            this.portTextBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.portTextBox.RootElement.AngleTransform = 0F;
            this.portTextBox.RootElement.FlipText = false;
            this.portTextBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.portTextBox.RootElement.Text = null;
            this.portTextBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
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
            // 
            // 
            // 
            this.ipTextBox.RootElement.AccessibleDescription = null;
            this.ipTextBox.RootElement.AccessibleName = null;
            this.ipTextBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.ipTextBox.RootElement.AngleTransform = 0F;
            this.ipTextBox.RootElement.FlipText = false;
            this.ipTextBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.ipTextBox.RootElement.Text = null;
            this.ipTextBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.ipTextBox.Size = new System.Drawing.Size(129, 24);
            this.ipTextBox.TabIndex = 11;
            this.ipTextBox.ThemeName = "VisualStudio2012Dark";
            // 
            // fastConnectCheckBox
            // 
            this.fastConnectCheckBox.Location = new System.Drawing.Point(3, 127);
            this.fastConnectCheckBox.Name = "fastConnectCheckBox";
            // 
            // 
            // 
            this.fastConnectCheckBox.RootElement.AccessibleDescription = null;
            this.fastConnectCheckBox.RootElement.AccessibleName = null;
            this.fastConnectCheckBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.fastConnectCheckBox.RootElement.AngleTransform = 0F;
            this.fastConnectCheckBox.RootElement.FlipText = false;
            this.fastConnectCheckBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.fastConnectCheckBox.RootElement.Text = null;
            this.fastConnectCheckBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.fastConnectCheckBox.Size = new System.Drawing.Size(144, 18);
            this.fastConnectCheckBox.TabIndex = 10;
            this.fastConnectCheckBox.Text = "Быстрое подключение:";
            this.fastConnectCheckBox.ThemeName = "VisualStudio2012Dark";
            this.fastConnectCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.fastConnectCheckBox_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.fastConnectCheckBox.GetChildAt(0))).Text = "Быстрое подключение:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.fastConnectCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.Color.Transparent;
            this.radLabel4.Location = new System.Drawing.Point(1, 98);
            this.radLabel4.Name = "radLabel4";
            // 
            // 
            // 
            this.radLabel4.RootElement.AccessibleDescription = null;
            this.radLabel4.RootElement.AccessibleName = null;
            this.radLabel4.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel4.RootElement.AngleTransform = 0F;
            this.radLabel4.RootElement.FlipText = false;
            this.radLabel4.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radLabel4.RootElement.Text = null;
            this.radLabel4.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radLabel4.Size = new System.Drawing.Size(134, 18);
            this.radLabel4.TabIndex = 9;
            this.radLabel4.Text = "После запуска Minecraft:";
            this.radLabel4.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel4.GetChildAt(0))).Text = "После запуска Minecraft:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel4.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Location = new System.Drawing.Point(203, 73);
            this.radLabel3.Name = "radLabel3";
            // 
            // 
            // 
            this.radLabel3.RootElement.AccessibleDescription = null;
            this.radLabel3.RootElement.AccessibleName = null;
            this.radLabel3.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel3.RootElement.AngleTransform = 0F;
            this.radLabel3.RootElement.FlipText = false;
            this.radLabel3.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radLabel3.RootElement.Text = null;
            this.radLabel3.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
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
            // 
            // 
            // 
            this.yResolutionBox.RootElement.AccessibleDescription = null;
            this.yResolutionBox.RootElement.AccessibleName = null;
            this.yResolutionBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.yResolutionBox.RootElement.AngleTransform = 0F;
            this.yResolutionBox.RootElement.FlipText = false;
            this.yResolutionBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.yResolutionBox.RootElement.Text = null;
            this.yResolutionBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.yResolutionBox.Size = new System.Drawing.Size(52, 24);
            this.yResolutionBox.TabIndex = 7;
            this.yResolutionBox.Text = "480";
            this.yResolutionBox.ThemeName = "VisualStudio2012Dark";
            // 
            // xResolutionBox
            // 
            this.xResolutionBox.Location = new System.Drawing.Point(145, 72);
            this.xResolutionBox.Name = "xResolutionBox";
            // 
            // 
            // 
            this.xResolutionBox.RootElement.AccessibleDescription = null;
            this.xResolutionBox.RootElement.AccessibleName = null;
            this.xResolutionBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.xResolutionBox.RootElement.AngleTransform = 0F;
            this.xResolutionBox.RootElement.FlipText = false;
            this.xResolutionBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.xResolutionBox.RootElement.Text = null;
            this.xResolutionBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.xResolutionBox.Size = new System.Drawing.Size(52, 24);
            this.xResolutionBox.TabIndex = 6;
            this.xResolutionBox.Text = "854";
            this.xResolutionBox.ThemeName = "VisualStudio2012Dark";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Location = new System.Drawing.Point(1, 73);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.AccessibleDescription = null;
            this.radLabel2.RootElement.AccessibleName = null;
            this.radLabel2.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel2.RootElement.AngleTransform = 0F;
            this.radLabel2.RootElement.FlipText = false;
            this.radLabel2.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radLabel2.RootElement.Text = null;
            this.radLabel2.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radLabel2.Size = new System.Drawing.Size(85, 18);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Размер экрана:";
            this.radLabel2.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel2.GetChildAt(0))).Text = "Размер экрана:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel2.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
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
            // 
            // 
            // 
            this.stateBox.RootElement.AccessibleDescription = null;
            this.stateBox.RootElement.AccessibleName = null;
            this.stateBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.stateBox.RootElement.AngleTransform = 0F;
            this.stateBox.RootElement.FlipText = false;
            this.stateBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.stateBox.RootElement.Text = null;
            this.stateBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.stateBox.Size = new System.Drawing.Size(177, 24);
            this.stateBox.TabIndex = 4;
            this.stateBox.ThemeName = "VisualStudio2012Dark";
            // 
            // gameDirectoryBox
            // 
            this.gameDirectoryBox.Enabled = false;
            this.gameDirectoryBox.Location = new System.Drawing.Point(145, 46);
            this.gameDirectoryBox.Name = "gameDirectoryBox";
            // 
            // 
            // 
            this.gameDirectoryBox.RootElement.AccessibleDescription = null;
            this.gameDirectoryBox.RootElement.AccessibleName = null;
            this.gameDirectoryBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.gameDirectoryBox.RootElement.AngleTransform = 0F;
            this.gameDirectoryBox.RootElement.FlipText = false;
            this.gameDirectoryBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.gameDirectoryBox.RootElement.Text = null;
            this.gameDirectoryBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.gameDirectoryBox.Size = new System.Drawing.Size(177, 24);
            this.gameDirectoryBox.TabIndex = 3;
            this.gameDirectoryBox.ThemeName = "VisualStudio2012Dark";
            // 
            // gameDirectoryCheckBox
            // 
            this.gameDirectoryCheckBox.Location = new System.Drawing.Point(3, 47);
            this.gameDirectoryCheckBox.Name = "gameDirectoryCheckBox";
            // 
            // 
            // 
            this.gameDirectoryCheckBox.RootElement.AccessibleDescription = null;
            this.gameDirectoryCheckBox.RootElement.AccessibleName = null;
            this.gameDirectoryCheckBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.gameDirectoryCheckBox.RootElement.AngleTransform = 0F;
            this.gameDirectoryCheckBox.RootElement.FlipText = false;
            this.gameDirectoryCheckBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.gameDirectoryCheckBox.RootElement.Text = null;
            this.gameDirectoryCheckBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.gameDirectoryCheckBox.Size = new System.Drawing.Size(134, 18);
            this.gameDirectoryCheckBox.TabIndex = 2;
            this.gameDirectoryCheckBox.Text = "Игровая директория:";
            this.gameDirectoryCheckBox.ThemeName = "VisualStudio2012Dark";
            this.gameDirectoryCheckBox.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.gameDirectoryCheckBox_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.gameDirectoryCheckBox.GetChildAt(0))).Text = "Игровая директория:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.gameDirectoryCheckBox.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Location = new System.Drawing.Point(1, 21);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.AccessibleDescription = null;
            this.radLabel1.RootElement.AccessibleName = null;
            this.radLabel1.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel1.RootElement.AngleTransform = 0F;
            this.radLabel1.RootElement.FlipText = false;
            this.radLabel1.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radLabel1.RootElement.Text = null;
            this.radLabel1.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radLabel1.Size = new System.Drawing.Size(107, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Название профиля:";
            this.radLabel1.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel1.GetChildAt(0))).Text = "Название профиля:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel1.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(145, 20);
            this.nameBox.Name = "nameBox";
            // 
            // 
            // 
            this.nameBox.RootElement.AccessibleDescription = null;
            this.nameBox.RootElement.AccessibleName = null;
            this.nameBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.nameBox.RootElement.AngleTransform = 0F;
            this.nameBox.RootElement.FlipText = false;
            this.nameBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.nameBox.RootElement.Text = null;
            this.nameBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.nameBox.Size = new System.Drawing.Size(177, 24);
            this.nameBox.TabIndex = 0;
            this.nameBox.ThemeName = "VisualStudio2012Dark";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(5, 393);
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
            this.openGameDirectoryButton.Location = new System.Drawing.Point(101, 393);
            this.openGameDirectoryButton.Name = "openGameDirectoryButton";
            // 
            // 
            // 
            this.openGameDirectoryButton.RootElement.AccessibleDescription = null;
            this.openGameDirectoryButton.RootElement.AccessibleName = null;
            this.openGameDirectoryButton.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.openGameDirectoryButton.RootElement.AngleTransform = 0F;
            this.openGameDirectoryButton.RootElement.FlipText = false;
            this.openGameDirectoryButton.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.openGameDirectoryButton.RootElement.Text = null;
            this.openGameDirectoryButton.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.openGameDirectoryButton.Size = new System.Drawing.Size(111, 34);
            this.openGameDirectoryButton.TabIndex = 10;
            this.openGameDirectoryButton.Text = "Открыть игр. директорию";
            this.openGameDirectoryButton.TextWrap = true;
            this.openGameDirectoryButton.ThemeName = "VisualStudio2012Dark";
            this.openGameDirectoryButton.Click += new System.EventHandler(this.openGameDirectoryButton_Click);
            // 
            // saveProfileButton
            // 
            this.saveProfileButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveProfileButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveProfileButton.Location = new System.Drawing.Point(218, 393);
            this.saveProfileButton.Name = "saveProfileButton";
            // 
            // 
            // 
            this.saveProfileButton.RootElement.AccessibleDescription = null;
            this.saveProfileButton.RootElement.AccessibleName = null;
            this.saveProfileButton.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.saveProfileButton.RootElement.AngleTransform = 0F;
            this.saveProfileButton.RootElement.FlipText = false;
            this.saveProfileButton.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.saveProfileButton.RootElement.Text = null;
            this.saveProfileButton.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
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
            this.ClientSize = new System.Drawing.Size(341, 429);
            this.Controls.Add(this.openGameDirectoryButton);
            this.Controls.Add(this.saveProfileButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ProfileForm";
            this.ThemeName = "VisualStudio2012Dark";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.javaExecutableBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.javaExecutableCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.javaArgumentsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.javaArgumentsCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.versionsDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betaCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapshotsCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastConnectCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yResolutionBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xResolutionBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameDirectoryBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameDirectoryCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGameDirectoryButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveProfileButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RadGroupBox radGroupBox3;
        private RadTextBox javaExecutableBox;
        private RadCheckBox javaExecutableCheckBox;
        private RadTextBox javaArgumentsBox;
        private RadCheckBox javaArgumentsCheckBox;
        private RadGroupBox radGroupBox2;
        private RadCheckBox otherCheckBox;
        public RadDropDownList versionsDropDownList;
        private RadCheckBox alphaCheckBox;
        private RadCheckBox betaCheckBox;
        private RadCheckBox snapshotsCheckBox;
        private RadGroupBox radGroupBox1;
        private RadButton radButton1;
        private RadTextBox portTextBox;
        private RadTextBox ipTextBox;
        private RadCheckBox fastConnectCheckBox;
        private RadLabel radLabel4;
        private RadLabel radLabel3;
        private RadTextBox yResolutionBox;
        private RadTextBox xResolutionBox;
        private RadLabel radLabel2;
        private RadDropDownList stateBox;
        private RadTextBox gameDirectoryBox;
        private RadCheckBox gameDirectoryCheckBox;
        private RadLabel radLabel1;
        public RadTextBox nameBox;
        private RadButton cancelButton;
        private RadButton openGameDirectoryButton;
        private RadButton saveProfileButton;
    }
}
