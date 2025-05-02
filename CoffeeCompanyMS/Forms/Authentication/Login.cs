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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CoffeeCompanyMS.UI.Authentication
{
    public partial class Login : Form
    {
        private string mainServerName;

        Dictionary<string, string> serversMap = new Dictionary<string, string>
            {
                { "Server Khoa", "LAPTOP-VM3SPQFB\\ASUSSQL" },
                { "Server Duong", "" },
                { "Server Kien", "" },
                { "Server Manh", "LAPTOP-CRUATNF8" },
            };

        public Login()
        {
            InitializeComponent();
            
            comboBoxServers.Items.AddRange(serversMap.Keys.ToArray());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool result = UserSession.Instance.Start(mainServerName, textBoxGmail.Text, textBoxPassword.Text);
            if (!result) return;

            comboBoxServers.SelectedIndex = 0;
            textBoxGmail.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            Hide();

            Program.mainForm = new Main();
            Program.mainForm.Show();
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
                mainServerName = serversMap[selectedKey];
            }
        }
    }
}
