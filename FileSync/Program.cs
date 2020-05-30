using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace FileSync
{
    public class FileSyncContext : DbContext
    {
        public FileSyncContext() : base("name=FileSyncDbConnectionStr")
        { 
        }
        public DbSet<File> Files { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());

            using (var db = new FileSyncContext())
            {
                db.Database.CreateIfNotExists();
                var file = new File
                {
                    FileId = 1,
                    FileName = "plik testowy"
                };
                db.Files.Add(file);
                db.SaveChanges();
            }
        }
    }
}
