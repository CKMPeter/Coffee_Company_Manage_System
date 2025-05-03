using CoffeeCompanyMS.Navigations;
using CoffeeCompanyMS.UC;
using CoffeeCompanyMS.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.UC.Pages.Storage;
using CoffeeCompanyMS.UC.Pages.Import;
using CoffeeCompanyMS.UC.Pages.Export;
using CoffeeCompanyMS.Forms.Authentication;

namespace CoffeeCompanyMS
{
    public partial class WarehouseNavBar : UserControl
    {
        public WarehouseNavBar()
        {
            InitializeComponent();
        }

        private void navBar_Load(object sender, EventArgs e)
        {
            SubNavManager.ShowSubNav(new StorageNavBar());
        }

        private void pbStorage_Click(object sender, EventArgs e)
        {
            if (lbMode.Text == "STORAGE") return;
            lbMode.Text = "STORAGE";
            SubNavManager.ShowSubNav(new StorageNavBar());
        }

        private void pbImport_Click(object sender, EventArgs e)
        {
            if (lbMode.Text == "IMPORT") return;
            lbMode.Text = "IMPORT";
            SubNavManager.ShowSubNav(new ImportNavBar());
        }

        private void pbExport_Click(object sender, EventArgs e)
        {
            if (lbMode.Text == "EXPORT") return;
            lbMode.Text = "EXPORT";
            SubNavManager.ShowSubNav(new ExportNavBar());
        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            UserSession.Instance.End();
            Program.mainForm.Hide();
            Program.loginForm.Show();
        }
    }
}
