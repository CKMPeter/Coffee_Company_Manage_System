using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.Forms.Authentication
{
    // ConnectionFactory is a class that creates SQL connections 
    // It uses the Factory Method Pattern,
    // which provides a way to create SQLConnection object
    // without exposing the instantiation logic
    // or what connection string is used.
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
