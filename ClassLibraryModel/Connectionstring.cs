using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    internal class Connectionstring
    {
        public class DBConnection
        {
            private static string connectionString = @"Data Source=DESKTOP-JSIV0OT\MSSQLSERVER01;Initial Catalog=YourDB;Integrated Security=True";

            public static string GetConnectionString()
            {
                return connectionString;
            }
        }

    }
}
