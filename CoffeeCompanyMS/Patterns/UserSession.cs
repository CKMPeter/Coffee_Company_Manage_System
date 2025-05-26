using System.Data.SqlClient;
using System.Windows.Forms;
using CoffeeCompanyMS.DAOs;
using CoffeeCompanyMS.Models;
using CoffeeCompanyMS.Patterns;

namespace CoffeeCompanyMS.Forms.Authentication
{
    /// <summary>
    /// UserSession is a Singleton class
    /// that manages the current user session.
    /// </summary>
    internal class UserSession
    {
        public static UserSession Instance { get; } = new UserSession();

        public User LoggedInUser { get; private set; }

        public ConnectionFactory ConnectionFactory { get; private set; }

        private UserSession() { }

        private bool SetLoggedInUser(string email)
        {
            try
            {
                var userDAO = DAOManager.Instance.UserDAO;

                LoggedInUser = userDAO.GetUserByEmail(email);

                if (LoggedInUser != null)
                {
                    MessageBox.Show("Login success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Start(string serverName, string email, string password)
        {
            ConnectionFactory = new ConnectionFactory(serverName, email, password);
            DAOManager.Initialize();
            return SetLoggedInUser(email);
        }

        public void End()
        {
            ConnectionFactory = null;
            LoggedInUser = null;
        }
    }

}
