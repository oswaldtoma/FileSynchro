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
            InitializeComponent();
            Synchronization.init("C:\\Users\\Oswald\\Desktop\\lokalnyfolder");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Synchronization.synchronize();
        }

        private void localDirBrowseButton_Click(object sender, EventArgs e)
        {
            localFolderToSyncDialog.ShowDialog();
        }
    }
}
