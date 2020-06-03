namespace FileSynchro
{
    partial class Form1
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
            this.TEST = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LogsPage = new System.Windows.Forms.TabPage();
            this.logsTextBox = new System.Windows.Forms.TextBox();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.localDirToSyncLabel = new System.Windows.Forms.Label();
            this.localDirTextbox = new System.Windows.Forms.TextBox();
            this.localDirBrowseButton = new System.Windows.Forms.Button();
            this.localFolderToSyncDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.LogsPage.SuspendLayout();
            this.SettingsPage.SuspendLayout();
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
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 354);
            this.tabControl1.TabIndex = 1;
            // 
            // LogsPage
            // 
            this.LogsPage.Controls.Add(this.logsTextBox);
            this.LogsPage.Location = new System.Drawing.Point(4, 22);
            this.LogsPage.Name = "LogsPage";
            this.LogsPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogsPage.Size = new System.Drawing.Size(603, 328);
            this.LogsPage.TabIndex = 0;
            this.LogsPage.Text = "Logs";
            this.LogsPage.UseVisualStyleBackColor = true;
            // 
            // logsTextBox
            // 
            this.logsTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.logsTextBox.Location = new System.Drawing.Point(3, 3);
            this.logsTextBox.Multiline = true;
            this.logsTextBox.Name = "logsTextBox";
            this.logsTextBox.ReadOnly = true;
            this.logsTextBox.Size = new System.Drawing.Size(597, 322);
            this.logsTextBox.TabIndex = 0;
            // 
            // SettingsPage
            // 
            this.SettingsPage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SettingsPage.Controls.Add(this.localDirToSyncLabel);
            this.SettingsPage.Controls.Add(this.localDirTextbox);
            this.SettingsPage.Controls.Add(this.localDirBrowseButton);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(603, 328);
            this.SettingsPage.TabIndex = 1;
            this.SettingsPage.Text = "Settings";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 407);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TEST);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.LogsPage.ResumeLayout(false);
            this.LogsPage.PerformLayout();
            this.SettingsPage.ResumeLayout(false);
            this.SettingsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TEST;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage LogsPage;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.TextBox logsTextBox;
        private System.Windows.Forms.FolderBrowserDialog localFolderToSyncDialog;
        private System.Windows.Forms.Label localDirToSyncLabel;
        private System.Windows.Forms.TextBox localDirTextbox;
        private System.Windows.Forms.Button localDirBrowseButton;
    }
}

