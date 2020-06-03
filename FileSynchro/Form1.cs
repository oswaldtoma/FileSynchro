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
            Synchronization.init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FTPManager ftp = new FTPManager("ftp://127.0.0.1", "user", "password!");
            ftp.downloadFile(".", "TheDotFactory.exe");
        }
    }
}
