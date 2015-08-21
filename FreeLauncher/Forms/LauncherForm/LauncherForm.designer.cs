using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace FreeLauncher.Forms
{
    partial class LauncherForm
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
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Версия");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Тип");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Зависимость");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            this.vs12theme = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.mainPageView = new Telerik.WinControls.UI.RadPageView();
            this.News = new Telerik.WinControls.UI.RadPageViewPage();
            this.newsBrowser = new System.Windows.Forms.WebBrowser();
            this.webPanel = new Telerik.WinControls.UI.RadPanel();
            this.BackWebButton = new Telerik.WinControls.UI.RadButton();
            this.ForwardWebButton = new Telerik.WinControls.UI.RadButton();
            this.ConsolePage = new Telerik.WinControls.UI.RadPageViewPage();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.ConsoleOptionsPanel = new Telerik.WinControls.UI.RadPanel();
            this.SetToClipboardButton = new Telerik.WinControls.UI.RadButton();
            this.DebugModeButton = new Telerik.WinControls.UI.RadToggleButton();
            this.EditVersions = new Telerik.WinControls.UI.RadPageViewPage();
            this.versionsListView = new Telerik.WinControls.UI.RadListView();
            this.AboutPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.AboutPageView = new Telerik.WinControls.UI.RadPageView();
            this.AboutPageViewPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.radScrollablePanel2 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.AboutVersion = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.LicensesPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.licensePageView = new Telerik.WinControls.UI.RadPageView();
            this.FreeLauncherLicense = new Telerik.WinControls.UI.RadPageViewPage();
            this.FreeLauncherLicenseText = new Telerik.WinControls.UI.RadLabel();
            this.dotMCLauncherLicense = new Telerik.WinControls.UI.RadPageViewPage();
            this.dotMCLauncherLicenseText = new Telerik.WinControls.UI.RadLabel();
            this.SettingsPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.CloseGameOutput = new Telerik.WinControls.UI.RadCheckBox();
            this.UseGamePrefix = new Telerik.WinControls.UI.RadCheckBox();
            this.EnableMinecraftLogging = new Telerik.WinControls.UI.RadCheckBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.LangDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.EnableMinecraftUpdateAlerts = new Telerik.WinControls.UI.RadCheckBox();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.StatusBar = new Telerik.WinControls.UI.RadProgressBar();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.DeleteProfileButton = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.NicknameDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.SelectedVersion = new System.Windows.Forms.Label();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.LaunchButton = new Telerik.WinControls.UI.RadButton();
            this.profilesDropDownBox = new Telerik.WinControls.UI.RadDropDownList();
            this.EditProfile = new Telerik.WinControls.UI.RadButton();
            this.AddProfile = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).BeginInit();
            this.mainPageView.SuspendLayout();
            this.News.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webPanel)).BeginInit();
            this.webPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackWebButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardWebButton)).BeginInit();
            this.ConsolePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsoleOptionsPanel)).BeginInit();
            this.ConsoleOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetToClipboardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebugModeButton)).BeginInit();
            this.EditVersions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionsListView)).BeginInit();
            this.AboutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutPageView)).BeginInit();
            this.AboutPageView.SuspendLayout();
            this.AboutPageViewPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).BeginInit();
            this.radScrollablePanel2.PanelContainer.SuspendLayout();
            this.radScrollablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AboutVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.LicensesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.licensePageView)).BeginInit();
            this.licensePageView.SuspendLayout();
            this.FreeLauncherLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FreeLauncherLicenseText)).BeginInit();
            this.dotMCLauncherLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotMCLauncherLicenseText)).BeginInit();
            this.SettingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseGameOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseGamePrefix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableMinecraftLogging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LangDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableMinecraftUpdateAlerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteProfileButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NicknameDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaunchButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilesDropDownBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPageView
            // 
            this.mainPageView.Controls.Add(this.News);
            this.mainPageView.Controls.Add(this.ConsolePage);
            this.mainPageView.Controls.Add(this.EditVersions);
            this.mainPageView.Controls.Add(this.AboutPage);
            this.mainPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPageView.Location = new System.Drawing.Point(0, 0);
            this.mainPageView.Name = "mainPageView";
            // 
            // 
            // 
            this.mainPageView.RootElement.AccessibleDescription = null;
            this.mainPageView.RootElement.AccessibleName = null;
            this.mainPageView.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.mainPageView.RootElement.AngleTransform = 0F;
            this.mainPageView.RootElement.FlipText = false;
            this.mainPageView.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.mainPageView.RootElement.Text = null;
            this.mainPageView.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.mainPageView.SelectedPage = this.News;
            this.mainPageView.Size = new System.Drawing.Size(858, 363);
            this.mainPageView.TabIndex = 2;
            this.mainPageView.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.mainPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // News
            // 
            this.News.Controls.Add(this.newsBrowser);
            this.News.Controls.Add(this.webPanel);
            this.News.ItemSize = new System.Drawing.SizeF(65F, 24F);
            this.News.Location = new System.Drawing.Point(5, 30);
            this.News.Name = "News";
            this.News.Size = new System.Drawing.Size(848, 328);
            this.News.Text = "НОВОСТИ";
            // 
            // newsBrowser
            // 
            this.newsBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsBrowser.Location = new System.Drawing.Point(0, 0);
            this.newsBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.newsBrowser.Name = "newsBrowser";
            this.newsBrowser.ScriptErrorsSuppressed = true;
            this.newsBrowser.Size = new System.Drawing.Size(848, 308);
            this.newsBrowser.TabIndex = 0;
            this.newsBrowser.Url = new System.Uri("http://mcupdate.tumblr.com/", System.UriKind.Absolute);
            this.newsBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.newsBrowser_Navigated);
            this.newsBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.newsBrowser_Navigating);
            // 
            // webPanel
            // 
            this.webPanel.Controls.Add(this.BackWebButton);
            this.webPanel.Controls.Add(this.ForwardWebButton);
            this.webPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webPanel.Location = new System.Drawing.Point(0, 308);
            this.webPanel.Name = "webPanel";
            // 
            // 
            // 
            this.webPanel.RootElement.AccessibleDescription = null;
            this.webPanel.RootElement.AccessibleName = null;
            this.webPanel.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.webPanel.RootElement.AngleTransform = 0F;
            this.webPanel.RootElement.FlipText = false;
            this.webPanel.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.webPanel.RootElement.Text = null;
            this.webPanel.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.webPanel.Size = new System.Drawing.Size(848, 20);
            this.webPanel.TabIndex = 1;
            this.webPanel.ThemeName = "VisualStudio2012Dark";
            this.webPanel.Visible = false;
            // 
            // BackWebButton
            // 
            this.BackWebButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackWebButton.Location = new System.Drawing.Point(720, 0);
            this.BackWebButton.Name = "BackWebButton";
            // 
            // 
            // 
            this.BackWebButton.RootElement.AccessibleDescription = null;
            this.BackWebButton.RootElement.AccessibleName = null;
            this.BackWebButton.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.BackWebButton.RootElement.AngleTransform = 0F;
            this.BackWebButton.RootElement.FlipText = false;
            this.BackWebButton.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.BackWebButton.RootElement.Text = null;
            this.BackWebButton.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.BackWebButton.Size = new System.Drawing.Size(64, 17);
            this.BackWebButton.TabIndex = 1;
            this.BackWebButton.Text = "<";
            this.BackWebButton.ThemeName = "VisualStudio2012Dark";
            this.BackWebButton.Click += new System.EventHandler(this.backWebButton_Click);
            // 
            // ForwardWebButton
            // 
            this.ForwardWebButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ForwardWebButton.Location = new System.Drawing.Point(784, 0);
            this.ForwardWebButton.Name = "ForwardWebButton";
            // 
            // 
            // 
            this.ForwardWebButton.RootElement.AccessibleDescription = null;
            this.ForwardWebButton.RootElement.AccessibleName = null;
            this.ForwardWebButton.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.ForwardWebButton.RootElement.AngleTransform = 0F;
            this.ForwardWebButton.RootElement.FlipText = false;
            this.ForwardWebButton.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.ForwardWebButton.RootElement.Text = null;
            this.ForwardWebButton.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.ForwardWebButton.Size = new System.Drawing.Size(64, 17);
            this.ForwardWebButton.TabIndex = 0;
            this.ForwardWebButton.Text = ">";
            this.ForwardWebButton.ThemeName = "VisualStudio2012Dark";
            this.ForwardWebButton.Click += new System.EventHandler(this.forwardWebButton_Click);
            // 
            // ConsolePage
            // 
            this.ConsolePage.Controls.Add(this.logBox);
            this.ConsolePage.Controls.Add(this.ConsoleOptionsPanel);
            this.ConsolePage.ItemSize = new System.Drawing.SizeF(65F, 24F);
            this.ConsolePage.Location = new System.Drawing.Point(5, 30);
            this.ConsolePage.Name = "ConsolePage";
            this.ConsolePage.Size = new System.Drawing.Size(848, 328);
            this.ConsolePage.Text = "КОНСОЛЬ";
            // 
            // logBox
            // 
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(848, 299);
            this.logBox.TabIndex = 1;
            this.logBox.Text = "";
            this.logBox.TextChanged += new System.EventHandler(this.logBox_TextChanged);
            // 
            // ConsoleOptionsPanel
            // 
            this.ConsoleOptionsPanel.Controls.Add(this.SetToClipboardButton);
            this.ConsoleOptionsPanel.Controls.Add(this.DebugModeButton);
            this.ConsoleOptionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ConsoleOptionsPanel.Location = new System.Drawing.Point(0, 299);
            this.ConsoleOptionsPanel.Name = "ConsoleOptionsPanel";
            this.ConsoleOptionsPanel.Size = new System.Drawing.Size(848, 29);
            this.ConsoleOptionsPanel.TabIndex = 2;
            this.ConsoleOptionsPanel.ThemeName = "VisualStudio2012Dark";
            // 
            // SetToClipboardButton
            // 
            this.SetToClipboardButton.Location = new System.Drawing.Point(7, 3);
            this.SetToClipboardButton.Name = "SetToClipboardButton";
            this.SetToClipboardButton.Size = new System.Drawing.Size(131, 23);
            this.SetToClipboardButton.TabIndex = 1;
            this.SetToClipboardButton.Text = "Скопировать в буфер";
            this.SetToClipboardButton.ThemeName = "VisualStudio2012Dark";
            this.SetToClipboardButton.Click += new System.EventHandler(this.SetToClipboardButton_Click);
            // 
            // DebugModeButton
            // 
            this.DebugModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugModeButton.Location = new System.Drawing.Point(710, 3);
            this.DebugModeButton.Name = "DebugModeButton";
            this.DebugModeButton.Size = new System.Drawing.Size(131, 23);
            this.DebugModeButton.TabIndex = 0;
            this.DebugModeButton.Text = "Debug Mode";
            this.DebugModeButton.ThemeName = "VisualStudio2012Dark";
            // 
            // EditVersions
            // 
            this.EditVersions.Controls.Add(this.versionsListView);
            this.EditVersions.ItemSize = new System.Drawing.SizeF(145F, 24F);
            this.EditVersions.Location = new System.Drawing.Point(5, 30);
            this.EditVersions.Name = "EditVersions";
            this.EditVersions.Size = new System.Drawing.Size(848, 328);
            this.EditVersions.Text = "УПРАВЛЕНИЕ ВЕРСИЯМИ";
            // 
            // versionsListView
            // 
            this.versionsListView.AllowColumnReorder = false;
            this.versionsListView.AllowColumnResize = false;
            this.versionsListView.AllowEdit = false;
            this.versionsListView.AllowRemove = false;
            this.versionsListView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.versionsListView.CheckOnClickMode = Telerik.WinControls.UI.CheckOnClickMode.FirstClick;
            listViewDetailColumn1.HeaderText = "Версия";
            listViewDetailColumn2.HeaderText = "Тип";
            listViewDetailColumn2.Width = 100F;
            listViewDetailColumn3.HeaderText = "Зависимость";
            listViewDetailColumn3.Width = 100F;
            this.versionsListView.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3});
            this.versionsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionsListView.EnableColumnSort = true;
            this.versionsListView.EnableFiltering = true;
            this.versionsListView.EnableSorting = true;
            this.versionsListView.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
            this.versionsListView.ItemSpacing = -1;
            this.versionsListView.Location = new System.Drawing.Point(0, 0);
            this.versionsListView.Name = "versionsListView";
            // 
            // 
            // 
            this.versionsListView.RootElement.AccessibleDescription = null;
            this.versionsListView.RootElement.AccessibleName = null;
            this.versionsListView.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.versionsListView.RootElement.AngleTransform = 0F;
            this.versionsListView.RootElement.FlipText = false;
            this.versionsListView.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.versionsListView.RootElement.Text = null;
            this.versionsListView.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.versionsListView.SelectLastAddedItem = false;
            this.versionsListView.ShowItemToolTips = false;
            this.versionsListView.Size = new System.Drawing.Size(848, 328);
            this.versionsListView.TabIndex = 0;
            this.versionsListView.ThemeName = "VisualStudio2012Dark";
            this.versionsListView.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.versionsListView.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.versionsListView.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.versionsListView_ItemMouseClick);
            // 
            // AboutPage
            // 
            this.AboutPage.Controls.Add(this.AboutPageView);
            this.AboutPage.ItemSize = new System.Drawing.SizeF(79F, 24F);
            this.AboutPage.Location = new System.Drawing.Point(5, 30);
            this.AboutPage.Name = "AboutPage";
            this.AboutPage.Size = new System.Drawing.Size(848, 328);
            this.AboutPage.Text = "О ЛАУНЧЕРЕ";
            // 
            // AboutPageView
            // 
            this.AboutPageView.Controls.Add(this.AboutPageViewPage);
            this.AboutPageView.Controls.Add(this.LicensesPage);
            this.AboutPageView.Controls.Add(this.SettingsPage);
            this.AboutPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutPageView.Location = new System.Drawing.Point(0, 0);
            this.AboutPageView.Name = "AboutPageView";
            // 
            // 
            // 
            this.AboutPageView.RootElement.AccessibleDescription = null;
            this.AboutPageView.RootElement.AccessibleName = null;
            this.AboutPageView.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.AboutPageView.RootElement.AngleTransform = 0F;
            this.AboutPageView.RootElement.FlipText = false;
            this.AboutPageView.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.AboutPageView.RootElement.Text = null;
            this.AboutPageView.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.AboutPageView.SelectedPage = this.AboutPageViewPage;
            this.AboutPageView.Size = new System.Drawing.Size(848, 328);
            this.AboutPageView.TabIndex = 9;
            this.AboutPageView.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.AboutPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.AboutPageView.GetChildAt(0))).ItemAlignment = Telerik.WinControls.UI.StripViewItemAlignment.Center;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.AboutPageView.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.AboutPageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Bottom;
            // 
            // AboutPageViewPage
            // 
            this.AboutPageViewPage.Controls.Add(this.radScrollablePanel2);
            this.AboutPageViewPage.Location = new System.Drawing.Point(5, 5);
            this.AboutPageViewPage.Name = "AboutPageViewPage";
            this.AboutPageViewPage.Size = new System.Drawing.Size(838, 293);
            this.AboutPageViewPage.Text = "О ЛАУНЧЕРЕ";
            // 
            // radScrollablePanel2
            // 
            this.radScrollablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel2.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel2.Name = "radScrollablePanel2";
            // 
            // radScrollablePanel2.PanelContainer
            // 
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.label6);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.label7);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel5);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.AboutVersion);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel1);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.label2);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.label3);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.label1);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.label5);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.label4);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel2);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel3);
            this.radScrollablePanel2.PanelContainer.Size = new System.Drawing.Size(819, 291);
            // 
            // 
            // 
            this.radScrollablePanel2.RootElement.AccessibleDescription = null;
            this.radScrollablePanel2.RootElement.AccessibleName = null;
            this.radScrollablePanel2.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radScrollablePanel2.RootElement.AngleTransform = 0F;
            this.radScrollablePanel2.RootElement.FlipText = false;
            this.radScrollablePanel2.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radScrollablePanel2.RootElement.Text = null;
            this.radScrollablePanel2.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radScrollablePanel2.Size = new System.Drawing.Size(838, 293);
            this.radScrollablePanel2.TabIndex = 9;
            this.radScrollablePanel2.Text = "radScrollablePanel2";
            this.radScrollablePanel2.ThemeName = "VisualStudio2012Dark";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(14, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "http://vk.com/mcoffline";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(14, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(402, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "MCoffline - лучшая программа для серверных администраторов!";
            // 
            // radLabel5
            // 
            this.radLabel5.BackColor = System.Drawing.Color.Transparent;
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.radLabel5.ForeColor = System.Drawing.Color.Transparent;
            this.radLabel5.Location = new System.Drawing.Point(3, 191);
            this.radLabel5.Name = "radLabel5";
            // 
            // 
            // 
            this.radLabel5.RootElement.AccessibleDescription = null;
            this.radLabel5.RootElement.AccessibleName = null;
            this.radLabel5.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel5.RootElement.AngleTransform = 0F;
            this.radLabel5.RootElement.FlipText = false;
            this.radLabel5.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radLabel5.RootElement.Text = null;
            this.radLabel5.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radLabel5.Size = new System.Drawing.Size(140, 41);
            this.radLabel5.TabIndex = 10;
            this.radLabel5.Text = "Партнёры";
            this.radLabel5.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel5.GetChildAt(0))).Text = "Партнёры";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel5.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // AboutVersion
            // 
            this.AboutVersion.BackColor = System.Drawing.Color.Transparent;
            this.AboutVersion.ForeColor = System.Drawing.Color.DimGray;
            this.AboutVersion.Location = new System.Drawing.Point(122, 34);
            this.AboutVersion.MinimumSize = new System.Drawing.Size(58, 18);
            this.AboutVersion.Name = "AboutVersion";
            // 
            // 
            // 
            this.AboutVersion.RootElement.AccessibleDescription = null;
            this.AboutVersion.RootElement.AccessibleName = null;
            this.AboutVersion.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.AboutVersion.RootElement.AngleTransform = 0F;
            this.AboutVersion.RootElement.FlipText = false;
            this.AboutVersion.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.AboutVersion.RootElement.MinSize = new System.Drawing.Size(58, 18);
            this.AboutVersion.RootElement.Text = null;
            this.AboutVersion.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.AboutVersion.Size = new System.Drawing.Size(58, 18);
            this.AboutVersion.TabIndex = 1;
            this.AboutVersion.Text = "0.0.0.000";
            this.AboutVersion.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.AboutVersion.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.AboutVersion.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.UI.RadLabelElement)(this.AboutVersion.GetChildAt(0))).Text = "0.0.0.000";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.AboutVersion.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.radLabel1.ForeColor = System.Drawing.Color.Transparent;
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
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
            this.radLabel1.Size = new System.Drawing.Size(175, 41);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "FreeLauncher";
            this.radLabel1.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel1.GetChildAt(0))).Text = "FreeLauncher";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(14, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(602, 51);
            this.label2.TabIndex = 4;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(14, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "http://vk.com/sesmc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Разработано Space Earth Studio Minecraft\r\nИздано Space Earth Studio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(14, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "http://ru-minecraft.ru";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(14, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(449, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Большое спасибо администрации портала ru-minecraft.ru за хост файлов";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.radLabel2.ForeColor = System.Drawing.Color.Transparent;
            this.radLabel2.Location = new System.Drawing.Point(3, 117);
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
            this.radLabel2.Size = new System.Drawing.Size(202, 41);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "Благодарности";
            this.radLabel2.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel2.GetChildAt(0))).Text = "Благодарности";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel2.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.radLabel3.ForeColor = System.Drawing.Color.Transparent;
            this.radLabel3.Location = new System.Drawing.Point(172, 3);
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
            this.radLabel3.RootElement.Opacity = 0.2D;
            this.radLabel3.RootElement.Text = null;
            this.radLabel3.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radLabel3.Size = new System.Drawing.Size(279, 41);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "by Space Earth Studio";
            this.radLabel3.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel3.GetChildAt(0))).Text = "by Space Earth Studio";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel3.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // LicensesPage
            // 
            this.LicensesPage.Controls.Add(this.licensePageView);
            this.LicensesPage.Location = new System.Drawing.Point(5, 5);
            this.LicensesPage.Name = "LicensesPage";
            this.LicensesPage.Size = new System.Drawing.Size(838, 293);
            this.LicensesPage.Text = "ЛИЦЕНЗИИ";
            // 
            // licensePageView
            // 
            this.licensePageView.Controls.Add(this.FreeLauncherLicense);
            this.licensePageView.Controls.Add(this.dotMCLauncherLicense);
            this.licensePageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licensePageView.Location = new System.Drawing.Point(0, 0);
            this.licensePageView.Name = "licensePageView";
            // 
            // 
            // 
            this.licensePageView.RootElement.AccessibleDescription = null;
            this.licensePageView.RootElement.AccessibleName = null;
            this.licensePageView.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.licensePageView.RootElement.AngleTransform = 0F;
            this.licensePageView.RootElement.FlipText = false;
            this.licensePageView.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.licensePageView.RootElement.Text = null;
            this.licensePageView.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.licensePageView.SelectedPage = this.FreeLauncherLicense;
            this.licensePageView.Size = new System.Drawing.Size(838, 293);
            this.licensePageView.TabIndex = 0;
            this.licensePageView.Text = "radPageView3";
            this.licensePageView.ThemeName = "VisualStudio2012Dark";
            this.licensePageView.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.licensePageView.GetChildAt(0).GetChildAt(0))).MinSize = new System.Drawing.Size(150, 0);
            // 
            // FreeLauncherLicense
            // 
            this.FreeLauncherLicense.AutoScroll = true;
            this.FreeLauncherLicense.Controls.Add(this.FreeLauncherLicenseText);
            this.FreeLauncherLicense.Location = new System.Drawing.Point(155, 4);
            this.FreeLauncherLicense.Name = "FreeLauncherLicense";
            this.FreeLauncherLicense.Size = new System.Drawing.Size(679, 285);
            this.FreeLauncherLicense.Text = "FreeLauncher";
            // 
            // FreeLauncherLicenseText
            // 
            this.FreeLauncherLicenseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FreeLauncherLicenseText.Location = new System.Drawing.Point(0, 0);
            this.FreeLauncherLicenseText.Name = "FreeLauncherLicenseText";
            this.FreeLauncherLicenseText.Size = new System.Drawing.Size(679, 285);
            this.FreeLauncherLicenseText.TabIndex = 2;
            this.FreeLauncherLicenseText.Text = resources.GetString("FreeLauncherLicenseText.Text");
            this.FreeLauncherLicenseText.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.FreeLauncherLicenseText.GetChildAt(0))).Text = resources.GetString("resource.Text");
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.FreeLauncherLicenseText.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // dotMCLauncherLicense
            // 
            this.dotMCLauncherLicense.AutoScroll = true;
            this.dotMCLauncherLicense.Controls.Add(this.dotMCLauncherLicenseText);
            this.dotMCLauncherLicense.Location = new System.Drawing.Point(155, 4);
            this.dotMCLauncherLicense.Name = "dotMCLauncherLicense";
            this.dotMCLauncherLicense.Size = new System.Drawing.Size(679, 285);
            this.dotMCLauncherLicense.Text = "dotMCLauncher";
            // 
            // dotMCLauncherLicenseText
            // 
            this.dotMCLauncherLicenseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dotMCLauncherLicenseText.Location = new System.Drawing.Point(0, 0);
            this.dotMCLauncherLicenseText.Name = "dotMCLauncherLicenseText";
            this.dotMCLauncherLicenseText.Size = new System.Drawing.Size(679, 285);
            this.dotMCLauncherLicenseText.TabIndex = 1;
            this.dotMCLauncherLicenseText.Text = resources.GetString("dotMCLauncherLicenseText.Text");
            this.dotMCLauncherLicenseText.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.dotMCLauncherLicenseText.GetChildAt(0))).Text = resources.GetString("resource.Text1");
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.dotMCLauncherLicenseText.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // SettingsPage
            // 
            this.SettingsPage.Controls.Add(this.radScrollablePanel1);
            this.SettingsPage.Location = new System.Drawing.Point(5, 5);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Size = new System.Drawing.Size(838, 293);
            this.SettingsPage.Text = "НАСТРОЙКИ";
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel1.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radGroupBox2);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radGroupBox1);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(836, 291);
            // 
            // 
            // 
            this.radScrollablePanel1.RootElement.AccessibleDescription = null;
            this.radScrollablePanel1.RootElement.AccessibleName = null;
            this.radScrollablePanel1.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radScrollablePanel1.RootElement.AngleTransform = 0F;
            this.radScrollablePanel1.RootElement.FlipText = false;
            this.radScrollablePanel1.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radScrollablePanel1.RootElement.Text = null;
            this.radScrollablePanel1.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radScrollablePanel1.Size = new System.Drawing.Size(838, 293);
            this.radScrollablePanel1.TabIndex = 1;
            this.radScrollablePanel1.Text = "radScrollablePanel1";
            this.radScrollablePanel1.ThemeName = "VisualStudio2012Dark";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.radGroupBox2.Controls.Add(this.CloseGameOutput);
            this.radGroupBox2.Controls.Add(this.UseGamePrefix);
            this.radGroupBox2.Controls.Add(this.EnableMinecraftLogging);
            this.radGroupBox2.HeaderText = "Логирование";
            this.radGroupBox2.Location = new System.Drawing.Point(402, 18);
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
            this.radGroupBox2.Size = new System.Drawing.Size(357, 121);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Логирование";
            this.radGroupBox2.ThemeName = "VisualStudio2012Dark";
            // 
            // CloseGameOutput
            // 
            this.CloseGameOutput.Location = new System.Drawing.Point(5, 69);
            this.CloseGameOutput.Name = "CloseGameOutput";
            // 
            // 
            // 
            this.CloseGameOutput.RootElement.AccessibleDescription = null;
            this.CloseGameOutput.RootElement.AccessibleName = null;
            this.CloseGameOutput.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.CloseGameOutput.RootElement.AngleTransform = 0F;
            this.CloseGameOutput.RootElement.FlipText = false;
            this.CloseGameOutput.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.CloseGameOutput.RootElement.Text = null;
            this.CloseGameOutput.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.CloseGameOutput.Size = new System.Drawing.Size(350, 18);
            this.CloseGameOutput.TabIndex = 2;
            this.CloseGameOutput.Text = "Закрывать вкладку вывода игры, если завершение стабильное";
            this.CloseGameOutput.ThemeName = "VisualStudio2012Dark";
            // 
            // UseGamePrefix
            // 
            this.UseGamePrefix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseGamePrefix.Location = new System.Drawing.Point(10, 45);
            this.UseGamePrefix.Name = "UseGamePrefix";
            // 
            // 
            // 
            this.UseGamePrefix.RootElement.AccessibleDescription = null;
            this.UseGamePrefix.RootElement.AccessibleName = null;
            this.UseGamePrefix.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.UseGamePrefix.RootElement.AngleTransform = 0F;
            this.UseGamePrefix.RootElement.FlipText = false;
            this.UseGamePrefix.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.UseGamePrefix.RootElement.Text = null;
            this.UseGamePrefix.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.UseGamePrefix.Size = new System.Drawing.Size(288, 18);
            this.UseGamePrefix.TabIndex = 1;
            this.UseGamePrefix.Text = "Использовать префикс [GAME] для логов Minecraft";
            this.UseGamePrefix.ThemeName = "VisualStudio2012Dark";
            this.UseGamePrefix.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // EnableMinecraftLogging
            // 
            this.EnableMinecraftLogging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableMinecraftLogging.Location = new System.Drawing.Point(5, 21);
            this.EnableMinecraftLogging.Name = "EnableMinecraftLogging";
            // 
            // 
            // 
            this.EnableMinecraftLogging.RootElement.AccessibleDescription = null;
            this.EnableMinecraftLogging.RootElement.AccessibleName = null;
            this.EnableMinecraftLogging.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.EnableMinecraftLogging.RootElement.AngleTransform = 0F;
            this.EnableMinecraftLogging.RootElement.FlipText = false;
            this.EnableMinecraftLogging.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.EnableMinecraftLogging.RootElement.Text = null;
            this.EnableMinecraftLogging.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.EnableMinecraftLogging.Size = new System.Drawing.Size(177, 18);
            this.EnableMinecraftLogging.TabIndex = 0;
            this.EnableMinecraftLogging.Text = "Выводить лог игры в консоль";
            this.EnableMinecraftLogging.ThemeName = "VisualStudio2012Dark";
            this.EnableMinecraftLogging.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.LangDropDownList);
            this.radGroupBox1.Controls.Add(this.EnableMinecraftUpdateAlerts);
            this.radGroupBox1.Controls.Add(this.radCheckBox1);
            this.radGroupBox1.HeaderText = "Основные";
            this.radGroupBox1.Location = new System.Drawing.Point(17, 18);
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
            this.radGroupBox1.Size = new System.Drawing.Size(357, 121);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Основные";
            this.radGroupBox1.ThemeName = "VisualStudio2012Dark";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(5, 69);
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
            this.radLabel4.Size = new System.Drawing.Size(87, 18);
            this.radLabel4.TabIndex = 5;
            this.radLabel4.Text = "Язык/Language:";
            this.radLabel4.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel4.GetChildAt(0))).Text = "Язык/Language:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel4.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // LangDropDownList
            // 
            this.LangDropDownList.AutoCompleteDisplayMember = null;
            this.LangDropDownList.AutoCompleteValueMember = null;
            this.LangDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.LangDropDownList.Enabled = false;
            radListDataItem1.Text = "Русский (ru-default)";
            this.LangDropDownList.Items.Add(radListDataItem1);
            this.LangDropDownList.Location = new System.Drawing.Point(150, 69);
            this.LangDropDownList.Name = "LangDropDownList";
            // 
            // 
            // 
            this.LangDropDownList.RootElement.AccessibleDescription = null;
            this.LangDropDownList.RootElement.AccessibleName = null;
            this.LangDropDownList.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.LangDropDownList.RootElement.AngleTransform = 0F;
            this.LangDropDownList.RootElement.FlipText = false;
            this.LangDropDownList.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.LangDropDownList.RootElement.Text = null;
            this.LangDropDownList.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.LangDropDownList.Size = new System.Drawing.Size(202, 24);
            this.LangDropDownList.TabIndex = 3;
            this.LangDropDownList.Text = "Русский (ru-default)";
            this.LangDropDownList.ThemeName = "VisualStudio2012Dark";
            // 
            // EnableMinecraftUpdateAlerts
            // 
            this.EnableMinecraftUpdateAlerts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableMinecraftUpdateAlerts.Enabled = false;
            this.EnableMinecraftUpdateAlerts.Location = new System.Drawing.Point(5, 45);
            this.EnableMinecraftUpdateAlerts.Name = "EnableMinecraftUpdateAlerts";
            // 
            // 
            // 
            this.EnableMinecraftUpdateAlerts.RootElement.AccessibleDescription = null;
            this.EnableMinecraftUpdateAlerts.RootElement.AccessibleName = null;
            this.EnableMinecraftUpdateAlerts.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.EnableMinecraftUpdateAlerts.RootElement.AngleTransform = 0F;
            this.EnableMinecraftUpdateAlerts.RootElement.FlipText = false;
            this.EnableMinecraftUpdateAlerts.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.EnableMinecraftUpdateAlerts.RootElement.Text = null;
            this.EnableMinecraftUpdateAlerts.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.EnableMinecraftUpdateAlerts.Size = new System.Drawing.Size(340, 18);
            this.EnableMinecraftUpdateAlerts.TabIndex = 2;
            this.EnableMinecraftUpdateAlerts.Text = "Показывать уведомления о наличии новых версий Minecraft";
            this.EnableMinecraftUpdateAlerts.ThemeName = "VisualStudio2012Dark";
            this.EnableMinecraftUpdateAlerts.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Enabled = false;
            this.radCheckBox1.Location = new System.Drawing.Point(5, 21);
            this.radCheckBox1.Name = "radCheckBox1";
            // 
            // 
            // 
            this.radCheckBox1.RootElement.AccessibleDescription = null;
            this.radCheckBox1.RootElement.AccessibleName = null;
            this.radCheckBox1.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radCheckBox1.RootElement.AngleTransform = 0F;
            this.radCheckBox1.RootElement.FlipText = false;
            this.radCheckBox1.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radCheckBox1.RootElement.Text = null;
            this.radCheckBox1.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radCheckBox1.Size = new System.Drawing.Size(257, 18);
            this.radCheckBox1.TabIndex = 0;
            this.radCheckBox1.Text = "Проверять наличие обновлений программы";
            this.radCheckBox1.ThemeName = "VisualStudio2012Dark";
            // 
            // StatusBar
            // 
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBar.Location = new System.Drawing.Point(0, 363);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(858, 24);
            this.StatusBar.TabIndex = 4;
            this.StatusBar.Text = "StatusBar";
            this.StatusBar.ThemeName = "VisualStudio2012Dark";
            this.StatusBar.Visible = false;
            // 
            // radPanel1
            // 
            this.radPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radPanel1.BackgroundImage")));
            this.radPanel1.Controls.Add(this.DeleteProfileButton);
            this.radPanel1.Controls.Add(this.radButton3);
            this.radPanel1.Controls.Add(this.NicknameDropDownList);
            this.radPanel1.Controls.Add(this.SelectedVersion);
            this.radPanel1.Controls.Add(this.LogoBox);
            this.radPanel1.Controls.Add(this.LaunchButton);
            this.radPanel1.Controls.Add(this.profilesDropDownBox);
            this.radPanel1.Controls.Add(this.EditProfile);
            this.radPanel1.Controls.Add(this.AddProfile);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 387);
            this.radPanel1.Name = "radPanel1";
            // 
            // 
            // 
            this.radPanel1.RootElement.AccessibleDescription = null;
            this.radPanel1.RootElement.AccessibleName = null;
            this.radPanel1.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radPanel1.RootElement.AngleTransform = 0F;
            this.radPanel1.RootElement.FlipText = false;
            this.radPanel1.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radPanel1.RootElement.Text = null;
            this.radPanel1.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radPanel1.Size = new System.Drawing.Size(858, 59);
            this.radPanel1.TabIndex = 3;
            this.radPanel1.ThemeName = "VisualStudio2012Dark";
            // 
            // DeleteProfileButton
            // 
            this.DeleteProfileButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteProfileButton.Image")));
            this.DeleteProfileButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeleteProfileButton.Location = new System.Drawing.Point(6, 6);
            this.DeleteProfileButton.Name = "DeleteProfileButton";
            this.DeleteProfileButton.Size = new System.Drawing.Size(32, 24);
            this.DeleteProfileButton.TabIndex = 8;
            this.DeleteProfileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteProfileButton.ThemeName = "VisualStudio2012Dark";
            this.DeleteProfileButton.Click += new System.EventHandler(this.DeleteProfileButton_Click);
            // 
            // radButton3
            // 
            this.radButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radButton3.Enabled = false;
            this.radButton3.Location = new System.Drawing.Point(521, 6);
            this.radButton3.Name = "radButton3";
            // 
            // 
            // 
            this.radButton3.RootElement.AccessibleDescription = null;
            this.radButton3.RootElement.AccessibleName = null;
            this.radButton3.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.radButton3.RootElement.AngleTransform = 0F;
            this.radButton3.RootElement.FlipText = false;
            this.radButton3.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.radButton3.RootElement.Text = null;
            this.radButton3.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radButton3.Size = new System.Drawing.Size(24, 24);
            this.radButton3.TabIndex = 7;
            this.radButton3.Text = "+";
            this.radButton3.ThemeName = "VisualStudio2012Dark";
            // 
            // NicknameDropDownList
            // 
            this.NicknameDropDownList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NicknameDropDownList.AutoCompleteDisplayMember = null;
            this.NicknameDropDownList.AutoCompleteValueMember = null;
            this.NicknameDropDownList.Location = new System.Drawing.Point(314, 6);
            this.NicknameDropDownList.Name = "NicknameDropDownList";
            this.NicknameDropDownList.NullText = "Ник";
            // 
            // 
            // 
            this.NicknameDropDownList.RootElement.AccessibleDescription = null;
            this.NicknameDropDownList.RootElement.AccessibleName = null;
            this.NicknameDropDownList.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.NicknameDropDownList.RootElement.AngleTransform = 0F;
            this.NicknameDropDownList.RootElement.FlipText = false;
            this.NicknameDropDownList.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.NicknameDropDownList.RootElement.Text = null;
            this.NicknameDropDownList.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.NicknameDropDownList.Size = new System.Drawing.Size(204, 24);
            this.NicknameDropDownList.TabIndex = 3;
            this.NicknameDropDownList.ThemeName = "VisualStudio2012Dark";
            // 
            // SelectedVersion
            // 
            this.SelectedVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedVersion.AutoSize = true;
            this.SelectedVersion.BackColor = System.Drawing.Color.Transparent;
            this.SelectedVersion.ForeColor = System.Drawing.Color.White;
            this.SelectedVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SelectedVersion.Location = new System.Drawing.Point(631, 42);
            this.SelectedVersion.MinimumSize = new System.Drawing.Size(220, 13);
            this.SelectedVersion.Name = "SelectedVersion";
            this.SelectedVersion.Size = new System.Drawing.Size(220, 13);
            this.SelectedVersion.TabIndex = 6;
            this.SelectedVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogoBox
            // 
            this.LogoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoBox.BackColor = System.Drawing.Color.Transparent;
            this.LogoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LogoBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoBox.Image")));
            this.LogoBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LogoBox.Location = new System.Drawing.Point(651, -11);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(181, 84);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 5;
            this.LogoBox.TabStop = false;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LaunchButton.Location = new System.Drawing.Point(314, 33);
            this.LaunchButton.Name = "LaunchButton";
            // 
            // 
            // 
            this.LaunchButton.RootElement.AccessibleDescription = null;
            this.LaunchButton.RootElement.AccessibleName = null;
            this.LaunchButton.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.LaunchButton.RootElement.AngleTransform = 0F;
            this.LaunchButton.RootElement.FlipText = false;
            this.LaunchButton.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.LaunchButton.RootElement.Text = null;
            this.LaunchButton.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.LaunchButton.Size = new System.Drawing.Size(231, 22);
            this.LaunchButton.TabIndex = 4;
            this.LaunchButton.Text = "Запуск игры";
            this.LaunchButton.ThemeName = "VisualStudio2012Dark";
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // profilesDropDownBox
            // 
            this.profilesDropDownBox.AutoCompleteDisplayMember = null;
            this.profilesDropDownBox.AutoCompleteValueMember = null;
            this.profilesDropDownBox.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.profilesDropDownBox.Location = new System.Drawing.Point(41, 6);
            this.profilesDropDownBox.Name = "profilesDropDownBox";
            // 
            // 
            // 
            this.profilesDropDownBox.RootElement.AccessibleDescription = null;
            this.profilesDropDownBox.RootElement.AccessibleName = null;
            this.profilesDropDownBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.profilesDropDownBox.RootElement.AngleTransform = 0F;
            this.profilesDropDownBox.RootElement.FlipText = false;
            this.profilesDropDownBox.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.profilesDropDownBox.RootElement.Text = null;
            this.profilesDropDownBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.profilesDropDownBox.Size = new System.Drawing.Size(191, 24);
            this.profilesDropDownBox.TabIndex = 2;
            this.profilesDropDownBox.ThemeName = "VisualStudio2012Dark";
            this.profilesDropDownBox.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.profilesDropDownBox_SelectedIndexChanged);
            // 
            // EditProfile
            // 
            this.EditProfile.Location = new System.Drawing.Point(122, 33);
            this.EditProfile.Name = "EditProfile";
            // 
            // 
            // 
            this.EditProfile.RootElement.AccessibleDescription = null;
            this.EditProfile.RootElement.AccessibleName = null;
            this.EditProfile.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.EditProfile.RootElement.AngleTransform = 0F;
            this.EditProfile.RootElement.FlipText = false;
            this.EditProfile.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.EditProfile.RootElement.Text = null;
            this.EditProfile.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.EditProfile.Size = new System.Drawing.Size(110, 22);
            this.EditProfile.TabIndex = 1;
            this.EditProfile.Text = "Изменить профиль";
            this.EditProfile.TextWrap = true;
            this.EditProfile.ThemeName = "VisualStudio2012Dark";
            this.EditProfile.Click += new System.EventHandler(this.EditProfile_Click);
            // 
            // AddProfile
            // 
            this.AddProfile.Location = new System.Drawing.Point(6, 33);
            this.AddProfile.Name = "AddProfile";
            // 
            // 
            // 
            this.AddProfile.RootElement.AccessibleDescription = null;
            this.AddProfile.RootElement.AccessibleName = null;
            this.AddProfile.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.AddProfile.RootElement.AngleTransform = 0F;
            this.AddProfile.RootElement.FlipText = false;
            this.AddProfile.RootElement.Margin = new System.Windows.Forms.Padding(0);
            this.AddProfile.RootElement.Text = null;
            this.AddProfile.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.AddProfile.Size = new System.Drawing.Size(110, 22);
            this.AddProfile.TabIndex = 0;
            this.AddProfile.Text = "Добавить профиль";
            this.AddProfile.TextWrap = true;
            this.AddProfile.ThemeName = "VisualStudio2012Dark";
            this.AddProfile.Click += new System.EventHandler(this.AddProfile_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 446);
            this.Controls.Add(this.mainPageView);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.radPanel1);
            this.MinimumSize = new System.Drawing.Size(712, 446);
            this.Name = "LauncherForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FreeLauncher";
            this.ThemeName = "VisualStudio2012Dark";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LauncherForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).EndInit();
            this.mainPageView.ResumeLayout(false);
            this.News.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webPanel)).EndInit();
            this.webPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackWebButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardWebButton)).EndInit();
            this.ConsolePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConsoleOptionsPanel)).EndInit();
            this.ConsoleOptionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SetToClipboardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebugModeButton)).EndInit();
            this.EditVersions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.versionsListView)).EndInit();
            this.AboutPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AboutPageView)).EndInit();
            this.AboutPageView.ResumeLayout(false);
            this.AboutPageViewPage.ResumeLayout(false);
            this.radScrollablePanel2.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel2.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).EndInit();
            this.radScrollablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AboutVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.LicensesPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.licensePageView)).EndInit();
            this.licensePageView.ResumeLayout(false);
            this.FreeLauncherLicense.ResumeLayout(false);
            this.FreeLauncherLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FreeLauncherLicenseText)).EndInit();
            this.dotMCLauncherLicense.ResumeLayout(false);
            this.dotMCLauncherLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotMCLauncherLicenseText)).EndInit();
            this.SettingsPage.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseGameOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseGamePrefix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableMinecraftLogging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LangDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableMinecraftUpdateAlerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteProfileButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NicknameDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaunchButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilesDropDownBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VisualStudio2012DarkTheme vs12theme;
        private RadPageView mainPageView;
        private RadPageViewPage News;
        private WebBrowser newsBrowser;
        private RadPanel webPanel;
        private RadButton BackWebButton;
        private RadButton ForwardWebButton;
        private RadPageViewPage ConsolePage;
        public RichTextBox logBox;
        private RadPageViewPage EditVersions;
        private RadListView versionsListView;
        private RadPageViewPage AboutPage;
        private RadPageView AboutPageView;
        private RadPageViewPage AboutPageViewPage;
        private RadScrollablePanel radScrollablePanel2;
        private Label label6;
        private Label label7;
        private RadLabel radLabel5;
        private RadLabel AboutVersion;
        private RadLabel radLabel1;
        private Label label2;
        private Label label3;
        private Label label1;
        private Label label5;
        private Label label4;
        private RadLabel radLabel2;
        private RadLabel radLabel3;
        private RadPageViewPage LicensesPage;
        private RadPageView licensePageView;
        private RadPageViewPage SettingsPage;
        private RadScrollablePanel radScrollablePanel1;
        private RadGroupBox radGroupBox2;
        public RadCheckBox UseGamePrefix;
        public RadCheckBox EnableMinecraftLogging;
        private RadGroupBox radGroupBox1;
        public RadLabel radLabel4;
        private RadDropDownList LangDropDownList;
        public RadCheckBox EnableMinecraftUpdateAlerts;
        public RadCheckBox radCheckBox1;
        private RadPanel radPanel1;
        private RadButton radButton3;
        public RadDropDownList NicknameDropDownList;
        private Label SelectedVersion;
        private PictureBox LogoBox;
        private RadButton LaunchButton;
        public RadDropDownList profilesDropDownBox;
        private RadButton EditProfile;
        private RadButton AddProfile;
        private RadPageViewPage dotMCLauncherLicense;
        private RadPageViewPage FreeLauncherLicense;
        private RadLabel FreeLauncherLicenseText;
        private RadLabel dotMCLauncherLicenseText;
        private RadProgressBar StatusBar;
        private RadPanel ConsoleOptionsPanel;
        public RadCheckBox CloseGameOutput;
        private RadToggleButton DebugModeButton;
        private RadButton DeleteProfileButton;
        private RadButton SetToClipboardButton;
    }
}
