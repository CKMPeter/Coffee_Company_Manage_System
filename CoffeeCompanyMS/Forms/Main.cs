using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.Navigations;
using CoffeeCompanyMS.UC;

namespace CoffeeCompanyMS.UI
{
    public partial class Main : Form
    {
        public static string locationID = null;

        public Main()
        {
            InitializeComponent();
            SubNavManager.Initialize(this.subNavPanel, this.pageAreaPanel);
            LoadMainNav();
        }
        
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void LoadMainNav()
        {
            UserControl mainNav;
            if (locationID == null)
            {
                mainNav = new CompanyOwnerNavBar();
            }
            else
            {
                mainNav = new WarehouseNavBar();
            }
            mainNav.Dock = DockStyle.Fill;
            navBarPanel.Controls.Add(mainNav);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
