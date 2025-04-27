using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.UI.Authentication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckLogin())
            {
                this.Hide();
                Main mainForm = new Main();
                mainForm.Show();
            }
        }

        private bool CheckLogin()
        {
            // Do login by connecting to database using SQLConnection
            // If success, get LocationID of the user, then assign it to Main.LocationID
            return true;

            // If fail, annouce login failed and let user try again
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
