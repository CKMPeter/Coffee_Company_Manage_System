using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.Forms.Authentication
{
    internal class SQLConnector
    {
        private static string connectionString = null;

        public static void SetConnectionString(string serverName, string email, string password)
        {
            connectionString = serverName + "User ID=" + email + ";Password=" + password + ";Encrypt=False";
        }

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static void ResetConnectionString()
        {
            connectionString = null;
        }
    }
}
