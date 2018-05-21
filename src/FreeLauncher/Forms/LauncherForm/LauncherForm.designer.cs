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
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Дата выхода");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn4 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "Последнего обновление");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn5 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 5", "Индекс ресурсов");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn6 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Зависимость");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn7 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Идентификатор");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn8 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Название");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn9 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Версия");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn10 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Конфигурация релизов");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn11 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "Видимость лаунчера");
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.vs12theme = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.mainPageView = new Telerik.WinControls.UI.RadPageView();
            this.News = new Telerik.WinControls.UI.RadPageViewPage();
            this.newsBrowser = new System.Windows.Forms.WebBrowser();
            this.navBar = new Telerik.WinControls.UI.RadPanel();
            this.BackWebButton = new Telerik.WinControls.UI.RadButton();
            this.ForwardWebButton = new Telerik.WinControls.UI.RadButton();
            this.ConsolePage = new Telerik.WinControls.UI.RadPageViewPage();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.ConsoleOptionsPanel = new Telerik.WinControls.UI.RadPanel();
            this.SetToClipboardButton = new Telerik.WinControls.UI.RadButton();
            this.DebugModeButton = new Telerik.WinControls.UI.RadToggleButton();
            this.EditVersions = new Telerik.WinControls.UI.RadPageViewPage();
            this.versionsListView = new Telerik.WinControls.UI.RadListView();
            this.EditProfiles = new Telerik.WinControls.UI.RadPageViewPage();
            this.profilesListView = new Telerik.WinControls.UI.RadListView();
            this.AboutPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.AboutPageView = new Telerik.WinControls.UI.RadPageView();
            this.AboutPageViewPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.radScrollablePanel2 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.CopyrightInfoLabel = new System.Windows.Forms.Label();
            this.LoggerGroupBox = new Telerik.WinControls.UI.RadGroupBox();
            this.CloseGameOutput = new Telerik.WinControls.UI.RadCheckBox();
            this.EnableMinecraftLogging = new Telerik.WinControls.UI.RadCheckBox();
            this.MainGroupBox = new Telerik.WinControls.UI.RadGroupBox();
            this.CheckUpdatesCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.LangDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.DownloadAssetsBox = new Telerik.WinControls.UI.RadCheckBox();
            this.AboutVersion = new Telerik.WinControls.UI.RadLabel();
            this.mcOfflineURL = new System.Windows.Forms.Label();
            this.MCofflineDescLabel = new System.Windows.Forms.Label();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.PartnersLabel = new Telerik.WinControls.UI.RadLabel();
            this.gitURL = new System.Windows.Forms.Label();
            this.DevInfoLabel = new System.Windows.Forms.Label();
            this.ruMcURL = new System.Windows.Forms.Label();
            this.GratitudesDescLabel = new System.Windows.Forms.Label();
            this.GratitudesLabel = new Telerik.WinControls.UI.RadLabel();
            this.LicensesPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.licensePageView = new Telerik.WinControls.UI.RadPageView();
            this.FreeLauncherLicense = new Telerik.WinControls.UI.RadPageViewPage();
            this.FreeLauncherLicenseText = new Telerik.WinControls.UI.RadLabel();
            this.dotMCLauncherLicense = new Telerik.WinControls.UI.RadPageViewPage();
            this.dotMCLauncherLicenseText = new Telerik.WinControls.UI.RadLabel();
            this.StatusBar = new Telerik.WinControls.UI.RadProgressBar();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.DeleteProfileButton = new Telerik.WinControls.UI.RadButton();
            this.ManageUsersButton = new Telerik.WinControls.UI.RadButton();
            this.NicknameDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.SelectedVersion = new System.Windows.Forms.Label();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.LaunchButton = new Telerik.WinControls.UI.RadButton();
            this.profilesDropDownBox = new Telerik.WinControls.UI.RadDropDownList();
            this.EditProfileButton = new Telerik.WinControls.UI.RadButton();
            this.AddProfile = new Telerik.WinControls.UI.RadButton();
            this.langWikiLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).BeginInit();
            this.mainPageView.SuspendLayout();
            this.News.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.navBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackWebButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardWebButton)).BeginInit();
            this.ConsolePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsoleOptionsPanel)).BeginInit();
            this.ConsoleOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetToClipboardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebugModeButton)).BeginInit();
            this.EditVersions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionsListView)).BeginInit();
            this.EditProfiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilesListView)).BeginInit();
            this.AboutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutPageView)).BeginInit();
            this.AboutPageView.SuspendLayout();
            this.AboutPageViewPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).BeginInit();
            this.radScrollablePanel2.PanelContainer.SuspendLayout();
            this.radScrollablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoggerGroupBox)).BeginInit();
            this.LoggerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseGameOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableMinecraftLogging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGroupBox)).BeginInit();
            this.MainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckUpdatesCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LangDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadAssetsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AboutVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnersLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GratitudesLabel)).BeginInit();
            this.LicensesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.licensePageView)).BeginInit();
            this.licensePageView.SuspendLayout();
            this.FreeLauncherLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FreeLauncherLicenseText)).BeginInit();
            this.dotMCLauncherLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotMCLauncherLicenseText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteProfileButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManageUsersButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NicknameDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaunchButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilesDropDownBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditProfileButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPageView
            // 
            this.mainPageView.Controls.Add(this.News);
            this.mainPageView.Controls.Add(this.ConsolePage);
            this.mainPageView.Controls.Add(this.EditVersions);
            this.mainPageView.Controls.Add(this.EditProfiles);
            this.mainPageView.Controls.Add(this.AboutPage);
            this.mainPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPageView.Location = new System.Drawing.Point(0, 0);
            this.mainPageView.Name = "mainPageView";
            this.mainPageView.SelectedPage = this.News;
            this.mainPageView.Size = new System.Drawing.Size(858, 363);
            this.mainPageView.TabIndex = 2;
            this.mainPageView.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.mainPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // News
            // 
            this.News.Controls.Add(this.newsBrowser);
            this.News.Controls.Add(this.navBar);
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
            this.newsBrowser.Size = new System.Drawing.Size(848, 299);
            this.newsBrowser.TabIndex = 0;
            this.newsBrowser.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.newsBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.newsBrowser_Navigated);
            this.newsBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.newsBrowser_Navigating);
            // 
            // navBar
            // 
            this.navBar.Controls.Add(this.BackWebButton);
            this.navBar.Controls.Add(this.ForwardWebButton);
            this.navBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navBar.Location = new System.Drawing.Point(0, 299);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(848, 29);
            this.navBar.TabIndex = 1;
            this.navBar.ThemeName = "VisualStudio2012Dark";
            this.navBar.Visible = false;
            // 
            // BackWebButton
            // 
            this.BackWebButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackWebButton.Location = new System.Drawing.Point(715, 3);
            this.BackWebButton.Name = "BackWebButton";
            this.BackWebButton.Size = new System.Drawing.Size(64, 23);
            this.BackWebButton.TabIndex = 1;
            this.BackWebButton.Text = "<";
            this.BackWebButton.ThemeName = "VisualStudio2012Dark";
            this.BackWebButton.Click += new System.EventHandler(this.backWebButton_Click);
            // 
            // ForwardWebButton
            // 
            this.ForwardWebButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ForwardWebButton.Location = new System.Drawing.Point(779, 3);
            this.ForwardWebButton.Name = "ForwardWebButton";
            this.ForwardWebButton.Size = new System.Drawing.Size(64, 23);
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
            this.logBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            listViewDetailColumn1.Width = 150F;
            listViewDetailColumn2.HeaderText = "Тип";
            listViewDetailColumn2.Width = 100F;
            listViewDetailColumn3.HeaderText = "Дата выхода";
            listViewDetailColumn3.Width = 150F;
            listViewDetailColumn4.HeaderText = "Последнего обновление";
            listViewDetailColumn4.Width = 150F;
            listViewDetailColumn5.HeaderText = "Индекс ресурсов";
            listViewDetailColumn5.Width = 120F;
            listViewDetailColumn6.HeaderText = "Зависимость";
            listViewDetailColumn6.Width = 100F;
            this.versionsListView.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3,
            listViewDetailColumn4,
            listViewDetailColumn5,
            listViewDetailColumn6});
            this.versionsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionsListView.EnableColumnSort = true;
            this.versionsListView.EnableFiltering = true;
            this.versionsListView.EnableSorting = true;
            this.versionsListView.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
            this.versionsListView.ItemSpacing = -1;
            this.versionsListView.Location = new System.Drawing.Point(0, 0);
            this.versionsListView.Name = "versionsListView";
            this.versionsListView.SelectLastAddedItem = false;
            this.versionsListView.ShowItemToolTips = false;
            this.versionsListView.Size = new System.Drawing.Size(848, 328);
            this.versionsListView.TabIndex = 0;
            this.versionsListView.ThemeName = "VisualStudio2012Dark";
            this.versionsListView.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.versionsListView.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.versionsListView.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.versionsListView_ItemMouseClick);
            // 
            // EditProfiles
            // 
            this.EditProfiles.Controls.Add(this.profilesListView);
            this.EditProfiles.ItemSize = new System.Drawing.SizeF(158F, 24F);
            this.EditProfiles.Location = new System.Drawing.Point(5, 30);
            this.EditProfiles.Name = "EditProfiles";
            this.EditProfiles.Size = new System.Drawing.Size(848, 328);
            this.EditProfiles.Text = "УПРАВЛЕНИЕ ПРОФИЛЯМИ";
            // 
            // profilesListView
            // 
            this.profilesListView.AllowColumnReorder = false;
            this.profilesListView.AllowColumnResize = false;
            this.profilesListView.AllowEdit = false;
            this.profilesListView.AllowRemove = false;
            this.profilesListView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.profilesListView.CheckOnClickMode = Telerik.WinControls.UI.CheckOnClickMode.FirstClick;
            listViewDetailColumn7.HeaderText = "Идентификатор";
            listViewDetailColumn8.HeaderText = "Название";
            listViewDetailColumn9.HeaderText = "Версия";
            listViewDetailColumn10.HeaderText = "Конфигурация релизов";
            listViewDetailColumn11.HeaderText = "Видимость лаунчера";
            this.profilesListView.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn7,
            listViewDetailColumn8,
            listViewDetailColumn9,
            listViewDetailColumn10,
            listViewDetailColumn11});
            this.profilesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilesListView.EnableColumnSort = true;
            this.profilesListView.EnableFiltering = true;
            this.profilesListView.EnableSorting = true;
            this.profilesListView.ItemSpacing = -1;
            this.profilesListView.Location = new System.Drawing.Point(0, 0);
            this.profilesListView.Name = "profilesListView";
            this.profilesListView.SelectLastAddedItem = false;
            this.profilesListView.ShowItemToolTips = false;
            this.profilesListView.Size = new System.Drawing.Size(848, 328);
            this.profilesListView.TabIndex = 1;
            this.profilesListView.ThemeName = "VisualStudio2012Dark";
            this.profilesListView.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.profilesListView.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.profilesListView.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.profilesListView_ItemMouseClick);
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
            this.AboutPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutPageView.Location = new System.Drawing.Point(0, 0);
            this.AboutPageView.Name = "AboutPageView";
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
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.CopyrightInfoLabel);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.LoggerGroupBox);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.MainGroupBox);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.AboutVersion);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.mcOfflineURL);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.MCofflineDescLabel);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel1);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.PartnersLabel);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.gitURL);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.DevInfoLabel);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.ruMcURL);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.GratitudesDescLabel);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.GratitudesLabel);
            this.radScrollablePanel2.PanelContainer.Size = new System.Drawing.Size(836, 291);
            this.radScrollablePanel2.Size = new System.Drawing.Size(838, 293);
            this.radScrollablePanel2.TabIndex = 9;
            this.radScrollablePanel2.Text = "radScrollablePanel2";
            this.radScrollablePanel2.ThemeName = "VisualStudio2012Dark";
            // 
            // CopyrightInfoLabel
            // 
            this.CopyrightInfoLabel.AutoSize = true;
            this.CopyrightInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.CopyrightInfoLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyrightInfoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CopyrightInfoLabel.Location = new System.Drawing.Point(2, 254);
            this.CopyrightInfoLabel.Name = "CopyrightInfoLabel";
            this.CopyrightInfoLabel.Size = new System.Drawing.Size(464, 34);
            this.CopyrightInfoLabel.TabIndex = 14;
            this.CopyrightInfoLabel.Text = "\"Minecraft\" является торговой маркой Mojang AB. Все права защищены.\r\nMojang AB яв" +
    "ляется дочерней студией Microsoft Studios.\r\n";
            this.CopyrightInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoggerGroupBox
            // 
            this.LoggerGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.LoggerGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.LoggerGroupBox.Controls.Add(this.CloseGameOutput);
            this.LoggerGroupBox.Controls.Add(this.EnableMinecraftLogging);
            this.LoggerGroupBox.HeaderText = "Логирование";
            this.LoggerGroupBox.Location = new System.Drawing.Point(469, 141);
            this.LoggerGroupBox.Name = "LoggerGroupBox";
            this.LoggerGroupBox.Size = new System.Drawing.Size(357, 121);
            this.LoggerGroupBox.TabIndex = 13;
            this.LoggerGroupBox.Text = "Логирование";
            this.LoggerGroupBox.ThemeName = "VisualStudio2012Dark";
            // 
            // CloseGameOutput
            // 
            this.CloseGameOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CloseGameOutput.Location = new System.Drawing.Point(5, 45);
            this.CloseGameOutput.Name = "CloseGameOutput";
            this.CloseGameOutput.Size = new System.Drawing.Size(327, 18);
            this.CloseGameOutput.TabIndex = 2;
            this.CloseGameOutput.Text = "Закрывать вкладку, если завершение прошло без ошибок";
            this.CloseGameOutput.ThemeName = "VisualStudio2012Dark";
            this.CloseGameOutput.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // EnableMinecraftLogging
            // 
            this.EnableMinecraftLogging.Location = new System.Drawing.Point(5, 21);
            this.EnableMinecraftLogging.Name = "EnableMinecraftLogging";
            this.EnableMinecraftLogging.Size = new System.Drawing.Size(177, 18);
            this.EnableMinecraftLogging.TabIndex = 0;
            this.EnableMinecraftLogging.Text = "Выводить лог игры в консоль";
            this.EnableMinecraftLogging.ThemeName = "VisualStudio2012Dark";
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.MainGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.MainGroupBox.Controls.Add(this.CheckUpdatesCheckBox);
            this.MainGroupBox.Controls.Add(this.radLabel4);
            this.MainGroupBox.Controls.Add(this.LangDropDownList);
            this.MainGroupBox.Controls.Add(this.DownloadAssetsBox);
            this.MainGroupBox.HeaderText = "Основные";
            this.MainGroupBox.Location = new System.Drawing.Point(469, 14);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(357, 121);
            this.MainGroupBox.TabIndex = 12;
            this.MainGroupBox.Text = "Основные";
            this.MainGroupBox.ThemeName = "VisualStudio2012Dark";
            // 
            // CheckUpdatesCheckBox
            // 
            this.CheckUpdatesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckUpdatesCheckBox.Location = new System.Drawing.Point(5, 51);
            this.CheckUpdatesCheckBox.Name = "CheckUpdatesCheckBox";
            this.CheckUpdatesCheckBox.Size = new System.Drawing.Size(245, 18);
            this.CheckUpdatesCheckBox.TabIndex = 6;
            this.CheckUpdatesCheckBox.Text = "Проверять наличие обновлений лаунчера";
            this.CheckUpdatesCheckBox.ThemeName = "VisualStudio2012Dark";
            this.CheckUpdatesCheckBox.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(5, 21);
            this.radLabel4.Name = "radLabel4";
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
            radListDataItem1.Tag = "ru-RU";
            radListDataItem1.Text = "Русский (ru-default)";
            this.LangDropDownList.Items.Add(radListDataItem1);
            this.LangDropDownList.Location = new System.Drawing.Point(150, 21);
            this.LangDropDownList.Name = "LangDropDownList";
            this.LangDropDownList.Size = new System.Drawing.Size(202, 24);
            this.LangDropDownList.TabIndex = 3;
            this.LangDropDownList.Text = "Русский (ru-RU)";
            this.LangDropDownList.ThemeName = "VisualStudio2012Dark";
            this.LangDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.LangDropDownList_SelectedIndexChanged);
            // 
            // DownloadAssetsBox
            // 
            this.DownloadAssetsBox.Location = new System.Drawing.Point(5, 75);
            this.DownloadAssetsBox.Name = "DownloadAssetsBox";
            this.DownloadAssetsBox.Size = new System.Drawing.Size(181, 18);
            this.DownloadAssetsBox.TabIndex = 0;
            this.DownloadAssetsBox.Text = "Пропускать загрузку ресурсов";
            this.DownloadAssetsBox.ThemeName = "VisualStudio2012Dark";
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
            this.AboutVersion.RootElement.MinSize = new System.Drawing.Size(58, 18);
            this.AboutVersion.Size = new System.Drawing.Size(58, 18);
            this.AboutVersion.TabIndex = 1;
            this.AboutVersion.Text = "0.0.0.000";
            this.AboutVersion.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.AboutVersion.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.AboutVersion.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.UI.RadLabelElement)(this.AboutVersion.GetChildAt(0))).Text = "0.0.0.000";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.AboutVersion.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // mcOfflineURL
            // 
            this.mcOfflineURL.AutoSize = true;
            this.mcOfflineURL.BackColor = System.Drawing.Color.Transparent;
            this.mcOfflineURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mcOfflineURL.ForeColor = System.Drawing.Color.Gray;
            this.mcOfflineURL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mcOfflineURL.Location = new System.Drawing.Point(14, 201);
            this.mcOfflineURL.Name = "mcOfflineURL";
            this.mcOfflineURL.Size = new System.Drawing.Size(127, 13);
            this.mcOfflineURL.TabIndex = 11;
            this.mcOfflineURL.Text = "http://vk.com/mcoffline";
            this.mcOfflineURL.Click += new System.EventHandler(this.urlLabel_Click);
            // 
            // MCofflineDescLabel
            // 
            this.MCofflineDescLabel.AutoSize = true;
            this.MCofflineDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.MCofflineDescLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MCofflineDescLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MCofflineDescLabel.Location = new System.Drawing.Point(14, 184);
            this.MCofflineDescLabel.Name = "MCofflineDescLabel";
            this.MCofflineDescLabel.Size = new System.Drawing.Size(402, 17);
            this.MCofflineDescLabel.TabIndex = 9;
            this.MCofflineDescLabel.Text = "MCoffline - лучшая программа для серверных администраторов!";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.radLabel1.ForeColor = System.Drawing.Color.White;
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(175, 41);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "FreeLauncher";
            this.radLabel1.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel1.GetChildAt(0))).Text = "FreeLauncher";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // PartnersLabel
            // 
            this.PartnersLabel.BackColor = System.Drawing.Color.Transparent;
            this.PartnersLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.PartnersLabel.ForeColor = System.Drawing.Color.Transparent;
            this.PartnersLabel.Location = new System.Drawing.Point(3, 147);
            this.PartnersLabel.Name = "PartnersLabel";
            this.PartnersLabel.Size = new System.Drawing.Size(140, 41);
            this.PartnersLabel.TabIndex = 10;
            this.PartnersLabel.Text = "Партнёры";
            this.PartnersLabel.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.PartnersLabel.GetChildAt(0))).Text = "Партнёры";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.PartnersLabel.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // gitURL
            // 
            this.gitURL.AutoSize = true;
            this.gitURL.BackColor = System.Drawing.Color.Transparent;
            this.gitURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gitURL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gitURL.ForeColor = System.Drawing.Color.Gray;
            this.gitURL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gitURL.Location = new System.Drawing.Point(14, 72);
            this.gitURL.Name = "gitURL";
            this.gitURL.Size = new System.Drawing.Size(163, 15);
            this.gitURL.TabIndex = 5;
            this.gitURL.Text = "https://github.com/dedepete";
            this.gitURL.Click += new System.EventHandler(this.urlLabel_Click);
            // 
            // DevInfoLabel
            // 
            this.DevInfoLabel.AutoSize = true;
            this.DevInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.DevInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.DevInfoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DevInfoLabel.Location = new System.Drawing.Point(14, 55);
            this.DevInfoLabel.Name = "DevInfoLabel";
            this.DevInfoLabel.Size = new System.Drawing.Size(146, 17);
            this.DevInfoLabel.TabIndex = 3;
            this.DevInfoLabel.Text = "Разработано dedepete";
            // 
            // ruMcURL
            // 
            this.ruMcURL.AutoSize = true;
            this.ruMcURL.BackColor = System.Drawing.Color.Transparent;
            this.ruMcURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ruMcURL.ForeColor = System.Drawing.Color.Gray;
            this.ruMcURL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ruMcURL.Location = new System.Drawing.Point(14, 135);
            this.ruMcURL.Name = "ruMcURL";
            this.ruMcURL.Size = new System.Drawing.Size(117, 13);
            this.ruMcURL.TabIndex = 8;
            this.ruMcURL.Text = "http://ru-minecraft.ru";
            this.ruMcURL.Click += new System.EventHandler(this.urlLabel_Click);
            // 
            // GratitudesDescLabel
            // 
            this.GratitudesDescLabel.AutoSize = true;
            this.GratitudesDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.GratitudesDescLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.GratitudesDescLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GratitudesDescLabel.Location = new System.Drawing.Point(14, 118);
            this.GratitudesDescLabel.Name = "GratitudesDescLabel";
            this.GratitudesDescLabel.Size = new System.Drawing.Size(449, 17);
            this.GratitudesDescLabel.TabIndex = 6;
            this.GratitudesDescLabel.Text = "Большое спасибо администрации портала ru-minecraft.ru за хост файлов";
            // 
            // GratitudesLabel
            // 
            this.GratitudesLabel.BackColor = System.Drawing.Color.Transparent;
            this.GratitudesLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.GratitudesLabel.ForeColor = System.Drawing.Color.Transparent;
            this.GratitudesLabel.Location = new System.Drawing.Point(3, 81);
            this.GratitudesLabel.Name = "GratitudesLabel";
            this.GratitudesLabel.Size = new System.Drawing.Size(202, 41);
            this.GratitudesLabel.TabIndex = 7;
            this.GratitudesLabel.Text = "Благодарности";
            this.GratitudesLabel.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.GratitudesLabel.GetChildAt(0))).Text = "Благодарности";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.GratitudesLabel.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
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
            this.radPanel1.Controls.Add(this.ManageUsersButton);
            this.radPanel1.Controls.Add(this.NicknameDropDownList);
            this.radPanel1.Controls.Add(this.SelectedVersion);
            this.radPanel1.Controls.Add(this.LogoBox);
            this.radPanel1.Controls.Add(this.LaunchButton);
            this.radPanel1.Controls.Add(this.profilesDropDownBox);
            this.radPanel1.Controls.Add(this.EditProfileButton);
            this.radPanel1.Controls.Add(this.AddProfile);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 387);
            this.radPanel1.Name = "radPanel1";
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
            // ManageUsersButton
            // 
            this.ManageUsersButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ManageUsersButton.Image = global::FreeLauncher.Properties.Resources.edit;
            this.ManageUsersButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ManageUsersButton.Location = new System.Drawing.Point(513, 6);
            this.ManageUsersButton.Name = "ManageUsersButton";
            this.ManageUsersButton.Size = new System.Drawing.Size(32, 24);
            this.ManageUsersButton.TabIndex = 7;
            this.ManageUsersButton.ThemeName = "VisualStudio2012Dark";
            this.ManageUsersButton.Click += new System.EventHandler(this.ManageUsersButton_Click);
            // 
            // NicknameDropDownList
            // 
            this.NicknameDropDownList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NicknameDropDownList.AutoCompleteDisplayMember = null;
            this.NicknameDropDownList.AutoCompleteValueMember = null;
            this.NicknameDropDownList.Location = new System.Drawing.Point(314, 6);
            this.NicknameDropDownList.Name = "NicknameDropDownList";
            this.NicknameDropDownList.NullText = "Ник";
            this.NicknameDropDownList.Size = new System.Drawing.Size(196, 24);
            this.NicknameDropDownList.TabIndex = 3;
            this.NicknameDropDownList.ThemeName = "VisualStudio2012Dark";
            this.NicknameDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.NicknameDropDownList_SelectedIndexChanged);
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
            this.profilesDropDownBox.Size = new System.Drawing.Size(191, 24);
            this.profilesDropDownBox.TabIndex = 2;
            this.profilesDropDownBox.ThemeName = "VisualStudio2012Dark";
            this.profilesDropDownBox.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.profilesDropDownBox_SelectedIndexChanged);
            // 
            // EditProfileButton
            // 
            this.EditProfileButton.Location = new System.Drawing.Point(122, 33);
            this.EditProfileButton.Name = "EditProfileButton";
            this.EditProfileButton.Size = new System.Drawing.Size(110, 22);
            this.EditProfileButton.TabIndex = 1;
            this.EditProfileButton.Text = "Изменить профиль";
            this.EditProfileButton.TextWrap = true;
            this.EditProfileButton.ThemeName = "VisualStudio2012Dark";
            this.EditProfileButton.Click += new System.EventHandler(this.EditProfile_Click);
            // 
            // AddProfile
            // 
            this.AddProfile.Location = new System.Drawing.Point(6, 33);
            this.AddProfile.Name = "AddProfile";
            this.AddProfile.Size = new System.Drawing.Size(110, 22);
            this.AddProfile.TabIndex = 0;
            this.AddProfile.Text = "Добавить профиль";
            this.AddProfile.TextWrap = true;
            this.AddProfile.ThemeName = "VisualStudio2012Dark";
            this.AddProfile.Click += new System.EventHandler(this.AddProfile_Click);
            // 
            // langWikiLink
            // 
            this.langWikiLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(105)))), ((int)(((byte)(175)))));
            this.langWikiLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.langWikiLink.AutoSize = true;
            this.langWikiLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.langWikiLink.LinkColor = System.Drawing.Color.Gray;
            this.langWikiLink.Location = new System.Drawing.Point(758, 5);
            this.langWikiLink.Name = "langWikiLink";
            this.langWikiLink.Size = new System.Drawing.Size(94, 13);
            this.langWikiLink.TabIndex = 5;
            this.langWikiLink.TabStop = true;
            this.langWikiLink.Text = "Having troubles?";
            this.langWikiLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.langWikiLink_LinkClicked);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 446);
            this.Controls.Add(this.langWikiLink);
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
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.navBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackWebButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardWebButton)).EndInit();
            this.ConsolePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConsoleOptionsPanel)).EndInit();
            this.ConsoleOptionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SetToClipboardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebugModeButton)).EndInit();
            this.EditVersions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.versionsListView)).EndInit();
            this.EditProfiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilesListView)).EndInit();
            this.AboutPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AboutPageView)).EndInit();
            this.AboutPageView.ResumeLayout(false);
            this.AboutPageViewPage.ResumeLayout(false);
            this.radScrollablePanel2.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel2.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).EndInit();
            this.radScrollablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoggerGroupBox)).EndInit();
            this.LoggerGroupBox.ResumeLayout(false);
            this.LoggerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseGameOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableMinecraftLogging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGroupBox)).EndInit();
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckUpdatesCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LangDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadAssetsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AboutVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnersLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GratitudesLabel)).EndInit();
            this.LicensesPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.licensePageView)).EndInit();
            this.licensePageView.ResumeLayout(false);
            this.FreeLauncherLicense.ResumeLayout(false);
            this.FreeLauncherLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FreeLauncherLicenseText)).EndInit();
            this.dotMCLauncherLicense.ResumeLayout(false);
            this.dotMCLauncherLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotMCLauncherLicenseText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteProfileButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManageUsersButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NicknameDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaunchButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilesDropDownBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditProfileButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VisualStudio2012DarkTheme vs12theme;
        private RadPageView mainPageView;
        private RadPageViewPage News;
        private WebBrowser newsBrowser;
        private RadPanel navBar;
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
        private Label mcOfflineURL;
        private Label MCofflineDescLabel;
        private RadLabel PartnersLabel;
        private RadLabel AboutVersion;
        private RadLabel radLabel1;
        private Label gitURL;
        private Label DevInfoLabel;
        private Label ruMcURL;
        private Label GratitudesDescLabel;
        private RadLabel GratitudesLabel;
        private RadPageViewPage LicensesPage;
        private RadPageView licensePageView;
        private RadPanel radPanel1;
        private RadButton ManageUsersButton;
        public RadDropDownList NicknameDropDownList;
        private Label SelectedVersion;
        private PictureBox LogoBox;
        private RadButton LaunchButton;
        public RadDropDownList profilesDropDownBox;
        private RadButton EditProfileButton;
        private RadButton AddProfile;
        private RadPageViewPage dotMCLauncherLicense;
        private RadPageViewPage FreeLauncherLicense;
        private RadLabel dotMCLauncherLicenseText;
        private RadProgressBar StatusBar;
        private RadPanel ConsoleOptionsPanel;
        private RadToggleButton DebugModeButton;
        private RadButton DeleteProfileButton;
        private RadButton SetToClipboardButton;
        private RadGroupBox LoggerGroupBox;
        public RadCheckBox CloseGameOutput;
        public RadCheckBox EnableMinecraftLogging;
        private RadGroupBox MainGroupBox;
        public RadLabel radLabel4;
        private RadDropDownList LangDropDownList;
        public RadCheckBox DownloadAssetsBox;
        private Label CopyrightInfoLabel;
        private LinkLabel langWikiLink;
        private RadLabel FreeLauncherLicenseText;
        private RadPageViewPage EditProfiles;
        private RadListView profilesListView;
        public RadCheckBox CheckUpdatesCheckBox;
    }
}
