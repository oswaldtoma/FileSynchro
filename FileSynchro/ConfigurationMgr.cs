using FileSynchro;
using FileSynchro.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace FileSynchro
{
    static public class ConfigurationMgr
    {
        static string settingsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FileSynchro\\config.cfg";
        static string settingsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FileSynchro";
        public static bool settingsLoaded { get; set; }
        public static string localDirToSync { get; set; }
        public static string ftpServerAddress { get; set; }
        public static string ftpUsername { get; set; }
        public static string ftpPassword { get; set; }
        public static bool secureMode { get; set; }

        public static void loadSettings()
        {
            try
            {
                string[] content = System.IO.File.ReadAllLines(settingsFile);

                localDirToSync = content[0];
                ftpServerAddress = content[1];
                ftpUsername = content[2];
                ftpPassword = content[3];

                bool secureModeTemp = false;
                Boolean.TryParse(content[4].ToLower(), out secureModeTemp);
                secureMode = secureModeTemp;
                settingsLoaded = true;
            }
            catch (Exception)
            {
                ftpServerAddress = "127.0.0.1";
                ftpUsername = "";
                ftpPassword = "";
                localDirToSync = "";
            }
        }
        public static void saveSettings()
        {
            List<string> content = new List<string>();
            content.Add(localDirToSync);
            content.Add(ftpServerAddress);
            content.Add(ftpUsername);
            content.Add(ftpPassword);
            content.Add(secureMode.ToString());

            string[] test = content.ToArray();

            if (!System.IO.Directory.Exists(settingsDirectory))
            {
                System.IO.Directory.CreateDirectory(settingsDirectory);
            }
            System.IO.File.WriteAllLines(settingsFile, test);
        }
    }
}
