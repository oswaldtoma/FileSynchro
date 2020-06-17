using FileSync;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSynchro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Synchronization.fileSynchroDb.Database.Initialize(force: false);
            InitializeComponent();
            //TODO config file
            localDirTextbox.Text = "C:\\Users\\Oswald\\Desktop\\lokalnyfolder";
            ftpServerAddrTextBox.Text = "127.0.0.1";
            usernameTextBox.Text = "user";
            passwordTextBox.Text = "password!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Synchronization.synchronize();
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
                Synchronization.init(localDirTextbox.Text, ftpServerAddrTextBox.Text, usernameTextBox.Text, passwordTextBox.Text); 
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void localDirTextbox_TextChanged(object sender, EventArgs e)
        {
            ftpSettingsApplyButton.Enabled = true;
            googleDriveSettingsApplyButton.Enabled = true;
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

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            Synchronization.synchronize();
        }
    }
}
