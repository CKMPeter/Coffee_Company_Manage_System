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
        public static string connectionString;
        private static SqlConnection conn;

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool Connect()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error in connecting to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static SqlCommand GetCommand(string query)
        {
            return new SqlCommand(query, conn);
        }
    }
}
