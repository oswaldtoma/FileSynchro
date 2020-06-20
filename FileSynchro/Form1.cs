using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FileSynchro
{
    public partial class FileSynchro : Form
    {
        public FileSynchro()
        {
            InitializeComponent();
            connectButton.Enabled = false;
            ConfigurationMgr.loadSettings();
            localDirTextbox.Text = ConfigurationMgr.localDirToSync;
            ftpServerAddrTextBox.Text = ConfigurationMgr.ftpServerAddress;
            usernameTextBox.Text = ConfigurationMgr.ftpUsername;
            passwordTextBox.Text = ConfigurationMgr.ftpPassword;
            ftpsCheckbox.Checked = ConfigurationMgr.secureMode;
            if(ConfigurationMgr.settingsLoaded)
            {
                ftpSettingsApplyButton.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void localDirBrowseButton_Click(object sender, EventArgs e)
        {
            localDirToSyncDialog.ShowDialog();
            localDirTextbox.Text = localDirToSyncDialog.SelectedPath;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ftpSettingsApplyButton_Click(object sender, EventArgs e)
        {
            if (localDirTextbox.Text != String.Empty && ftpServerAddrTextBox.Text != String.Empty && usernameTextBox.Text != String.Empty && passwordTextBox.Text != String.Empty)
            {
                ftpSettingsApplyButton.Enabled = false;
                fileSystemWatcher1.Path = localDirTextbox.Text;
                connectButton.Enabled = true;
                ConfigurationMgr.localDirToSync = localDirTextbox.Text;
                ConfigurationMgr.ftpServerAddress = ftpServerAddrTextBox.Text;
                ConfigurationMgr.ftpUsername = usernameTextBox.Text;
                ConfigurationMgr.ftpPassword = passwordTextBox.Text;
                ConfigurationMgr.secureMode = ftpsCheckbox.Checked;
                ConfigurationMgr.saveSettings();
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (!Synchronization.isInitialized && ConfigurationMgr.settingsLoaded)
            {
                await Synchronization.init(ConfigurationMgr.localDirToSync, ConfigurationMgr.ftpServerAddress, ConfigurationMgr.ftpUsername, ConfigurationMgr.ftpPassword, ConfigurationMgr.secureMode);
            }
            await Synchronization.synchronize();
        }

        private void localDirTextbox_TextChanged(object sender, EventArgs e)
        {
            ftpSettingsApplyButton.Enabled = true;
        }

        private void ftpServerAddrTextBox_TextChanged(object sender, EventArgs e)
        {
            ftpSettingsApplyButton.Enabled = true;
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            ftpSettingsApplyButton.Enabled = true;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            ftpSettingsApplyButton.Enabled = true;
        }

        private void ftpsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ftpSettingsApplyButton.Enabled = true;
        }

        private async void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            await Synchronization.synchronize();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            if (!Synchronization.isInitialized)
            {
                await Synchronization.init(ConfigurationMgr.localDirToSync, ConfigurationMgr.ftpServerAddress, ConfigurationMgr.ftpUsername, ConfigurationMgr.ftpPassword, ConfigurationMgr.secureMode);
            }
        }

        private void logTimer_Tick(object sender, EventArgs e)
        {
            logsTextBox.Text = Synchronization.logVar;
            logsTextBox.SelectionStart = logsTextBox.Text.Length;
            logsTextBox.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void logsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_resizeChanged(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                trayIcon.Visible = true;
                this.ShowInTaskbar = false;
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                trayIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        private void trayIcon_onMouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
