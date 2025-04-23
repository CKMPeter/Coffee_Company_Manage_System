using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.UI.Import;

namespace CoffeeCompanyMS.UC.Pages.Import
{
    public partial class RecurringImportOrdersPage : UserControl
    {
        public RecurringImportOrdersPage()
        {
            InitializeComponent();
        }

        private void RecurringImportOrders_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateImportOrders createImportOrders = new CreateImportOrders();
            createImportOrders.ShowDialog();
        }
    }
}
