﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CoffeeCompanyMS.Forms.Authentication;

namespace CoffeeCompanyMS.UI.Authentication
{
    public partial class Login : Form
    {
        private string mainServerName;

        Dictionary<string, string> serversMap = new Dictionary<string, string>
            {
                { "Server Khoa", "DESKTOP-2S48EVN" },
                { "Server Huy", "" },
                { "Server Kien", "" },
                { "Server Minh", "" },
                { "Server Luan", "" },
            };

        public Login()
        {
            InitializeComponent();

            mainServerName = "";
            comboBoxServers.Items.AddRange(serversMap.Keys.ToArray());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            handleLogin();
        }

        private void handleLogin()
        {
            if (comboBoxServers.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose the server name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string email = textBoxGmail.Text, password = textBoxPassword.Text;
            if (email == "" || password == "")
            {
                MessageBox.Show("Please fill all text boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = UserSession.Instance.Start(mainServerName, email, password);
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

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                handleLogin();
            }
        }
    }
}
