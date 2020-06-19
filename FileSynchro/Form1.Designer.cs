namespace FileSynchro
{
    partial class FileSynchro
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSynchro));
            this.TEST = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LogsPage = new System.Windows.Forms.TabPage();
            this.logsTextBox = new System.Windows.Forms.TextBox();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.connectButton = new System.Windows.Forms.Button();
            this.ftpSettingsApplyButton = new System.Windows.Forms.Button();
            this.ftpsCheckbox = new System.Windows.Forms.CheckBox();
            this.ftpServerAddrTextBox = new System.Windows.Forms.TextBox();
            this.ftpServerAddrLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.localDirToSyncLabel = new System.Windows.Forms.Label();
            this.localDirTextbox = new System.Windows.Forms.TextBox();
            this.localDirBrowseButton = new System.Windows.Forms.Button();
            this.localDirToSyncDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.syncTimer = new System.Windows.Forms.Timer(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.logTimer = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1.SuspendLayout();
            this.LogsPage.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // TEST
            // 
            this.TEST.Location = new System.Drawing.Point(548, 372);
            this.TEST.Name = "TEST";
            this.TEST.Size = new System.Drawing.Size(75, 23);
            this.TEST.TabIndex = 0;
            this.TEST.Text = "TEST";
            this.TEST.UseVisualStyleBackColor = true;
            this.TEST.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.LogsPage);
            this.tabControl1.Controls.Add(this.SettingsPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 405);
            this.tabControl1.TabIndex = 1;
            // 
            // LogsPage
            // 
            this.LogsPage.Controls.Add(this.logsTextBox);
            this.LogsPage.Location = new System.Drawing.Point(4, 22);
            this.LogsPage.Name = "LogsPage";
            this.LogsPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogsPage.Size = new System.Drawing.Size(639, 379);
            this.LogsPage.TabIndex = 0;
            this.LogsPage.Text = "Logs";
            this.LogsPage.UseVisualStyleBackColor = true;
            // 
            // logsTextBox
            // 
            this.logsTextBox.AcceptsReturn = true;
            this.logsTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.logsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsTextBox.Location = new System.Drawing.Point(3, 3);
            this.logsTextBox.Multiline = true;
            this.logsTextBox.Name = "logsTextBox";
            this.logsTextBox.ReadOnly = true;
            this.logsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logsTextBox.Size = new System.Drawing.Size(633, 373);
            this.logsTextBox.TabIndex = 0;
            this.logsTextBox.TextChanged += new System.EventHandler(this.logsTextBox_TextChanged);
            // 
            // SettingsPage
            // 
            this.SettingsPage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SettingsPage.Controls.Add(this.connectButton);
            this.SettingsPage.Controls.Add(this.ftpSettingsApplyButton);
            this.SettingsPage.Controls.Add(this.ftpsCheckbox);
            this.SettingsPage.Controls.Add(this.ftpServerAddrTextBox);
            this.SettingsPage.Controls.Add(this.ftpServerAddrLabel);
            this.SettingsPage.Controls.Add(this.passwordTextBox);
            this.SettingsPage.Controls.Add(this.passwordLabel);
            this.SettingsPage.Controls.Add(this.usernameTextBox);
            this.SettingsPage.Controls.Add(this.usernameLabel);
            this.SettingsPage.Controls.Add(this.localDirToSyncLabel);
            this.SettingsPage.Controls.Add(this.localDirTextbox);
            this.SettingsPage.Controls.Add(this.localDirBrowseButton);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(639, 379);
            this.SettingsPage.TabIndex = 1;
            this.SettingsPage.Text = "Settings";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(183, 258);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(135, 23);
            this.connectButton.TabIndex = 13;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // ftpSettingsApplyButton
            // 
            this.ftpSettingsApplyButton.Location = new System.Drawing.Point(243, 229);
            this.ftpSettingsApplyButton.Name = "ftpSettingsApplyButton";
            this.ftpSettingsApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ftpSettingsApplyButton.TabIndex = 12;
            this.ftpSettingsApplyButton.Text = "Apply";
            this.ftpSettingsApplyButton.UseVisualStyleBackColor = true;
            this.ftpSettingsApplyButton.Click += new System.EventHandler(this.ftpSettingsApplyButton_Click);
            // 
            // ftpsCheckbox
            // 
            this.ftpsCheckbox.AutoSize = true;
            this.ftpsCheckbox.Location = new System.Drawing.Point(325, 120);
            this.ftpsCheckbox.Name = "ftpsCheckbox";
            this.ftpsCheckbox.Size = new System.Drawing.Size(107, 17);
            this.ftpsCheckbox.TabIndex = 11;
            this.ftpsCheckbox.Text = "FTPS (SSL/TLS)";
            this.ftpsCheckbox.UseVisualStyleBackColor = true;
            this.ftpsCheckbox.CheckedChanged += new System.EventHandler(this.ftpsCheckbox_CheckedChanged);
            // 
            // ftpServerAddrTextBox
            // 
            this.ftpServerAddrTextBox.Location = new System.Drawing.Point(183, 118);
            this.ftpServerAddrTextBox.Name = "ftpServerAddrTextBox";
            this.ftpServerAddrTextBox.Size = new System.Drawing.Size(135, 20);
            this.ftpServerAddrTextBox.TabIndex = 10;
            this.ftpServerAddrTextBox.TextChanged += new System.EventHandler(this.ftpServerAddrTextBox_TextChanged);
            // 
            // ftpServerAddrLabel
            // 
            this.ftpServerAddrLabel.AutoSize = true;
            this.ftpServerAddrLabel.Location = new System.Drawing.Point(183, 102);
            this.ftpServerAddrLabel.Name = "ftpServerAddrLabel";
            this.ftpServerAddrLabel.Size = new System.Drawing.Size(71, 13);
            this.ftpServerAddrLabel.TabIndex = 9;
            this.ftpServerAddrLabel.Text = "FTP Address:";
            this.ftpServerAddrLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(183, 203);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(135, 20);
            this.passwordTextBox.TabIndex = 6;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(183, 187);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(183, 164);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(135, 20);
            this.usernameTextBox.TabIndex = 4;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(183, 148);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username:";
            // 
            // localDirToSyncLabel
            // 
            this.localDirToSyncLabel.AutoSize = true;
            this.localDirToSyncLabel.Location = new System.Drawing.Point(6, 3);
            this.localDirToSyncLabel.Name = "localDirToSyncLabel";
            this.localDirToSyncLabel.Size = new System.Drawing.Size(116, 13);
            this.localDirToSyncLabel.TabIndex = 2;
            this.localDirToSyncLabel.Text = "Local directory to sync:";
            // 
            // localDirTextbox
            // 
            this.localDirTextbox.Location = new System.Drawing.Point(9, 19);
            this.localDirTextbox.Name = "localDirTextbox";
            this.localDirTextbox.Size = new System.Drawing.Size(309, 20);
            this.localDirTextbox.TabIndex = 1;
            this.localDirTextbox.TextChanged += new System.EventHandler(this.localDirTextbox_TextChanged);
            // 
            // localDirBrowseButton
            // 
            this.localDirBrowseButton.Location = new System.Drawing.Point(324, 17);
            this.localDirBrowseButton.Name = "localDirBrowseButton";
            this.localDirBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.localDirBrowseButton.TabIndex = 0;
            this.localDirBrowseButton.Text = "Browse...";
            this.localDirBrowseButton.UseVisualStyleBackColor = true;
            this.localDirBrowseButton.Click += new System.EventHandler(this.localDirBrowseButton_Click);
            // 
            // syncTimer
            // 
            this.syncTimer.Enabled = true;
            this.syncTimer.Interval = 60000;
            this.syncTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // logTimer
            // 
            this.logTimer.Enabled = true;
            this.logTimer.Tick += new System.EventHandler(this.logTimer_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "FileSynchro";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_onMouseDoubleClick);
            // 
            // FileSynchro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 405);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TEST);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileSynchro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileSynchro";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_resizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.LogsPage.ResumeLayout(false);
            this.LogsPage.PerformLayout();
            this.SettingsPage.ResumeLayout(false);
            this.SettingsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TEST;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage LogsPage;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.TextBox logsTextBox;
        private System.Windows.Forms.FolderBrowserDialog localDirToSyncDialog;
        private System.Windows.Forms.Label localDirToSyncLabel;
        private System.Windows.Forms.TextBox localDirTextbox;
        private System.Windows.Forms.Button localDirBrowseButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label ftpServerAddrLabel;
        private System.Windows.Forms.CheckBox ftpsCheckbox;
        private System.Windows.Forms.TextBox ftpServerAddrTextBox;
        private System.Windows.Forms.Button ftpSettingsApplyButton;
        private System.Windows.Forms.Timer syncTimer;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Timer logTimer;
        private System.Windows.Forms.NotifyIcon trayIcon;
    }
}

