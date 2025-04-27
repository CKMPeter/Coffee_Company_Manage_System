using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.UI.Authentication
{
    public partial class Login : Form
    {
        private string connectionstring; 
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
            connectionstring = "Data Source=LAPTOP-CRUATNF8;User ID=" + textBoxGmail.Text + ";Password=" + textBoxPassword.Text + ";Connect Timeout=30;Encrypt=False";
            // Do login by connecting to database using SQLConnection
            // If success, get LocationID of the user, then assign it to Main.LocationID
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Open(); // 👉 thử mở kết nối
                    MessageBox.Show("Kết nối thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                    // Nếu mở thành công, gọi function GetLocationIDByEmail
                    string query = "SELECT LocationID FROM dbo.Users WHERE Email = @Email";


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", textBoxGmail.Text);

                        object result = cmd.ExecuteScalar();

                        Guid locationId = (Guid)result;
                        MessageBox.Show("Kết nối thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Login failed! " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            


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
