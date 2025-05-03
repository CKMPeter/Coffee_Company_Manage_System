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
using CoffeeCompanyMS.UC.NavBars;
using CoffeeCompanyMS.UC.Pages.Export;
using CoffeeCompanyMS.UC.Pages.Storage;

namespace CoffeeCompanyMS.UC
{
    public partial class ExportNavBar : UserControl
    {
        private Button[] _buttons;
        private ExportOrdersPage _exportOrderPages;
        private ExportOrderDetailsPage _exportOrderDetailsPage;
        private RecurringExportOrdersPage _recurringExportOrdersPage;

        public ExportNavBar()
        {
            InitializeComponent();
            _buttons = new Button[] {
                btnExportOrders,
                btnOrderDetails,
                btnRecurringOrders
            };
            _exportOrderPages = new ExportOrdersPage();
            _exportOrderDetailsPage = new ExportOrderDetailsPage();
            _recurringExportOrdersPage = new RecurringExportOrdersPage();
        }

        private void ExportNavBar_Load(object sender, EventArgs e)
        {
            NavigationManager.ShowPage(new ExportOrdersPage());
        }

        private void btnExportOrders_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnExportOrders);
            NavigationManager.ShowPage(_exportOrderPages);
        }

        private void btnOrderDetails_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnOrderDetails);
            NavigationManager.ShowPage(_exportOrderDetailsPage);
        }

        private void btnRecurringOrders_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnRecurringOrders);
            NavigationManager.ShowPage(_recurringExportOrdersPage);
        }

        private void resetStyle()
        {
            NavButtonStyleUtils.ResetButtonsStyle(_buttons);
        }

        private void pbReload_Click(object sender, EventArgs e)
        {
            _exportOrderPages = new ExportOrdersPage();
            _exportOrderDetailsPage = new ExportOrderDetailsPage();
            _recurringExportOrdersPage = new RecurringExportOrdersPage();
        }
    }
}
