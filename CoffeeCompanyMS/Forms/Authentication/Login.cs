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
using CoffeeCompanyMS.Forms.Authentication;

namespace CoffeeCompanyMS.UI.Authentication
{
    public partial class Login : Form
    {
        private string connectionstring;

        private string serverKhoa = "Data Source=LAPTOP-VM3SPQFB\\ASUSSQL;Initial Catalog=CoffeeCompany;Persist Security Info=True;";
        private string serverDuong = "";
        private string serverKien = "";
        private string serverManh = "";
        private string mainServer;

        Dictionary<string, string> serversMap;

        public Login()
        {
            InitializeComponent();
            serversMap = new Dictionary<string, string>
            {
                { "Server Khoa", "Data Source=LAPTOP-VM3SPQFB\\ASUSSQL;Initial Catalog=CoffeeCompany;Persist Security Info=True;" },
                { "Server Duong", serverDuong },
                { "Server Kien", serverKien },
                { "Server Manh", serverManh },
            };
            comboBoxServers.Items.AddRange(serversMap.Keys.ToArray());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckLogin()) return;
            GetLocationID();
            this.Hide();
            Program.mainForm.Show();
        }

        private bool CheckLogin()
        {
            SQLConnector.connectionString = mainServer + "User ID=" + textBoxGmail.Text + ";Password=" + textBoxPassword.Text + ";Encrypt=False";

            try
            {
                using (SqlConnection conn = SQLConnector.GetSqlConnection())
                {
                    conn.Open();
                    MessageBox.Show("Login success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error in connecting to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Login failed! Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool GetLocationID()
        {
            try
            {
                using (SqlConnection conn = SQLConnector.GetSqlConnection())
                {
                    conn.Open();
                    string query = @"SELECT dbo.GetLocationIDByEmail(@Email)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", textBoxGmail.Text);

                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            Main.locationID = result.ToString();
                        }
                        else
                        {
                            Main.locationID = null;
                        }
                        MessageBox.Show("LocationID = " + Main.locationID, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error in getting LocationID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBoxServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxServers.SelectedIndex >= 0)
            {
                string selectedKey = comboBoxServers.SelectedItem.ToString();
                mainServer = serversMap[selectedKey];
            }
        }
    }
}
