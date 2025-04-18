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

namespace CoffeeCompanyMS
{
    public partial class navBar : UserControl
    {
        //variables
        Main mainForm = Program.mainForm;
        public navBar()
        {
            InitializeComponent();
        }

        private void navBar_Load(object sender, EventArgs e)
        {

        }

        private void pbStorage_Click(object sender, EventArgs e)
        {
            // Contain Order History
            // List Of Stock
            if (((Form)this.TopLevelControl).GetType().Name == "Storage") return;
            ((Form)this.TopLevelControl).Hide();
            mainForm.storage.Closed += (s, args) => ((Form)this.TopLevelControl).Close();
            mainForm.storage.Show();
        }   

        private void pbOrder_Click(object sender, EventArgs e)
        {
            //warehouse Order
            lbMode.Text = "ORDER";
        }

        private void pbExport_Click(object sender, EventArgs e)
        {
            lbMode.Text = "DELIVERY";
        }
    }
}
