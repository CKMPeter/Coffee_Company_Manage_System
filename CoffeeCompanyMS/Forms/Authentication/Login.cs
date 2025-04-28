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
                { "Server Khoa", serverKhoa },
                { "Server Duong", serverDuong },
                { "Server Kien", serverKien },
                { "Server Manh", serverManh },
            };
            comboBoxServers.Items.AddRange(serversMap.Keys.ToArray());
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

            Main.connectionstring = mainServer + "User ID=" + textBoxGmail.Text + ";Password=" + textBoxPassword.Text + ";Encrypt=False";
            connectionstring = Main.connectionstring;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Open(); // thử mở kết nối
                    MessageBox.Show("Login success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    try
                    {
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
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Login failed! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Login failed! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
