using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.UC.Pages.Export
{
    public partial class ExportOrderDetailsPage : UserControl
    {
        private string orderID;
        public ExportOrderDetailsPage(string orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
        }
        public ExportOrderDetailsPage()
        {
            InitializeComponent();
            this.orderID = "";
        }

        private void ExportOrderDetailsPage_Load(object sender, EventArgs e)
        {

        }
    }
}
