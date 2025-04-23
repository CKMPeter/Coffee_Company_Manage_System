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
        private Button[] _buttons;
        private BatchSummaryPage _batchSummaryPage;
        private BatchDetailsPage _batchDetailsPage;
        private StorageHistoryPage _storageHistoryPage;

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

        private void resetStyle()
        {
            NavButtonStyleUtils.ResetButtonsStyle(_buttons);
        }

        private void pbReload_Click(object sender, EventArgs e)
        {
            _batchSummaryPage = new BatchSummaryPage();
            _batchDetailsPage = new BatchDetailsPage();
            _storageHistoryPage = new StorageHistoryPage();
        }
    }
}
