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
        public static Button[] buttons;
        private static BatchSummaryPage _batchSummaryPage;
        private static BatchDetailsPage _batchDetailsPage;
        private static StorageHistoryPage _storageHistoryPage;

        public StorageNavBar()
        {
            InitializeComponent();

            buttons = new Button[] { 
                btnBatchSummary, 
                btnBatchDetails, 
                btnStorageHistory 
            };
            _batchSummaryPage = new BatchSummaryPage();
            _batchDetailsPage = new BatchDetailsPage();
            _storageHistoryPage = new StorageHistoryPage();


            _batchSummaryPage.MoveToDetaisPage = DoubleClick_ToDetailsPage;

            SubNavManager.ShowPage(_batchSummaryPage);
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
            NavButtonStyleUtils.ResetButtonsStyle(buttons);
        }

        private void pbReload_Click(object sender, EventArgs e)
        {
            _batchSummaryPage = new BatchSummaryPage();
            _batchDetailsPage = new BatchDetailsPage();
            _storageHistoryPage = new StorageHistoryPage();
        }

        private void DoubleClick_ToDetailsPage(string locationID, string ingredientName)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnBatchDetails);
            SubNavManager.ShowPage(new BatchDetailsPage(locationID, ingredientName));
        }
    }
}
