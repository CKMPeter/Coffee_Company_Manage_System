using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.Forms.Authentication
{
    internal class ConnectionFactory
    {
        private readonly string connectionString = null;

        public ConnectionFactory(string serverName, 
            string email, string password)
        {
            connectionString = "Data Source=" + serverName 
                + ";Initial Catalog=CoffeeCompany;Persist Security Info=True"
                + ";User ID=" + email 
                + ";Password=" + password 
                + ";Encrypt=False";
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
