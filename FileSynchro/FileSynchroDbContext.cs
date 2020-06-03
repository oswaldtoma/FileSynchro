using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSynchro
{
    public class FileSynchroDbContext : DbContext
    {
        public FileSynchroDbContext() : base("name=FileSynchroDbConnectionStr")
        {
        }
        public DbSet<File> RemoteFiles { get; set; }
    }
}
