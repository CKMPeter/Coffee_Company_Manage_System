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
using CoffeeCompanyMS.UC.Pages.Storage;

namespace CoffeeCompanyMS.UC
{
    public partial class StorageNavBar : UserControl
    {
        private static Button[] _buttons;
        private static BatchSummaryPage _batchSummaryPage;
        private static BatchDetailsPage _batchDetailsPage;
        private static StorageHistoryPage _storageHistoryPage;

        public StorageNavBar()
        {
            InitializeComponent();
            _buttons = new Button[] { 
                btnBatchSummary, 
                btnBatchDetails, 
                btnStorageHistory 
            };
            _batchSummaryPage = new BatchSummaryPage();
            _batchDetailsPage = new BatchDetailsPage();
            _storageHistoryPage = new StorageHistoryPage();
        }

        private void btnBatchSummary_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnBatchSummary);
            SubNavManager.ShowPage(_batchSummaryPage);
        }

        private void btnBatchDetails_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnBatchDetails);
            SubNavManager.ShowPage(_batchDetailsPage);
        }

        private void btnStorageHistory_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnStorageHistory);
            SubNavManager.ShowPage(_storageHistoryPage);
        }

        private static void resetStyle()
        {
            NavButtonStyleUtils.ResetButtonsStyle(_buttons);
        }

        private void pbReload_Click(object sender, EventArgs e)
        {
            _batchSummaryPage = new BatchSummaryPage();
            _batchDetailsPage = new BatchDetailsPage();
            _storageHistoryPage = new StorageHistoryPage();
        }

        public static void BatchSummaryDoubleClick(string ingredientName)
        {
            
            SubNavManager.ShowPage(_batchDetailsPage);

            // Sau đó set dữ liệu Ingredient vào BatchDetailsPage
            if (Guid.TryParse(_batchSummaryPage.selectedLocationId, out Guid locationId))
            {
                _batchDetailsPage.SetLocationAndIngredient(locationId, ingredientName);
            }
        }
    }
}
