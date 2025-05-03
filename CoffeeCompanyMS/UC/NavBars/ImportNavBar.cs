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
using CoffeeCompanyMS.UC.Pages.Import;

namespace CoffeeCompanyMS.UC
{
    public partial class ImportNavBar : UserControl
    {
        private Button[] _buttons;
        private ImportOrdersPage _importOrderPage;
        private ImportOrderDetailsPage _importOrderDetailsPage;
        private RecurringImportOrdersPage _recurringImportOrdersPage;

        public ImportNavBar()
        {
            InitializeComponent();
            _buttons = new Button[] {
                btnImportOrders,
                btnOrderDetails,
                btnRecurringOrders
            };
            _importOrderPage = new ImportOrdersPage();
            _importOrderDetailsPage = new ImportOrderDetailsPage();
            _recurringImportOrdersPage = new RecurringImportOrdersPage();
        }

        private void ImportNavBar_Load(object sender, EventArgs e)
        {
            SubNavManager.ShowPage(new ImportOrdersPage());
        }

        private void btnImportOrders_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnImportOrders);
            SubNavManager.ShowPage(_importOrderPage);
        }

        private void btnOrderDetails_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnOrderDetails);
            SubNavManager.ShowPage(_importOrderDetailsPage);
        }

        private void btnRecurringOrders_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnRecurringOrders);
            SubNavManager.ShowPage(_recurringImportOrdersPage);
        }

        private void resetStyle()
        {
            NavButtonStyleUtils.ResetButtonsStyle(_buttons);
        }

        private void pbReload_Click(object sender, EventArgs e)
        {
            _importOrderPage = new ImportOrdersPage();
            _importOrderDetailsPage = new ImportOrderDetailsPage();
            _recurringImportOrdersPage = new RecurringImportOrdersPage();
        }
    }
}
