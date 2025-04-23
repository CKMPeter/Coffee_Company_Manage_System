using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.UI.Information;

namespace CoffeeCompanyMS.UC.Pages.Information
{
    public partial class SuppliersPage : UserControl
    {
        public SuppliersPage()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateSupplier createSupplier = new CreateSupplier();
            createSupplier.ShowDialog();
        }
    }
}
