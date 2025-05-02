using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CoffeeCompanyMS.Models;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace CoffeeCompanyMS.Forms.Authentication
{
    internal class UserSession
    {
        public static UserSession Instance { get; } = new UserSession();

        public User loggedInUser { get; private set; }

        public ConnectionFactory connectionFactory { get; private set; }

        private UserSession() { }

        private bool SetLoggedInUser(string email)
        {
            try
            {
                using (SqlConnection conn = connectionFactory.CreateConnection())
                {
                    conn.Open();
                    MessageBox.Show("Login success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string query = "SELECT * FROM dbo.GetUserByEmail(@Email)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        try
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string name = reader["Name"].ToString();
                                    string locationID = reader["LocationID"].ToString();
                                    string role = reader["UserRole"].ToString();

                                    loggedInUser = new User(email, name, locationID, role);
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("User cannot found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Error in getting user. Please try again.\nMessage:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error in connecting to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Login failed! Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Start(string serverName, string email, string password)
        {
            connectionFactory = new ConnectionFactory(serverName, email, password);
            return SetLoggedInUser(email);
        }

        public void End()
        {
            connectionFactory = null;
            loggedInUser = null;
        }
    }
}
