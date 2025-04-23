using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.UI.Export;

namespace CoffeeCompanyMS.UC.Pages.Export
{
    public partial class RecurringExportOrdersPage : UserControl
    {
        public RecurringExportOrdersPage()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateExportOrder createExportOrder = new CreateExportOrder();
            createExportOrder.ShowDialog();
        }
    }
}
