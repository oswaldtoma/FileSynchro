using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    public static class SQLServerManager
    {
        public static void InitializeConnection()
        {
            var sqlConnectionString = "";
            var sqlConnection = new SqlConnection(sqlConnectionString);
        }
    }
}
