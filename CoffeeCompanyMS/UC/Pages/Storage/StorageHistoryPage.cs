using CoffeeCompanyMS.DAOs;
using CoffeeCompanyMS.DTOs;
using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Models;
using CoffeeCompanyMS.Patterns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace CoffeeCompanyMS.UC.Pages.Storage
{
    public partial class StorageHistoryPage : UserControl
    {
        private Guid selectedLocationID;

        public StorageHistoryPage()
        {
            InitializeComponent();

            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationID = value;
                LoadStorageHistory();
            };
        }

        private void StorageHistoryPage_Load(object sender, EventArgs e)
        {
            selectedLocationID = locationSelector1.SelectedValue;
            if (selectedLocationID != Guid.Empty)
            {
                LoadStorageHistory();
            }
        }

        private void LoadStorageHistory()
        {
            try
            {
                TransferOrderDAO transferOrderDAO = DAOManager.Instance.TransferOrderDAO;
                BatchDAO batchDAO = DAOManager.Instance.BatchDAO;

                List<IngredientEventDTO> events = new List<IngredientEventDTO>();

                events.AddRange(transferOrderDAO.GetImportEventsByLocationId(selectedLocationID));
                events.AddRange(transferOrderDAO.GetExportEventsByLocationId(selectedLocationID));
                events.AddRange(batchDAO.GetWastageEventsByLocationId(selectedLocationID));

                // Sort by date descending
                var sortedEvents = events.OrderByDescending(e => e.Date).ToList();

                // Convert to DataTable for binding
                DataTable table = new DataTable();
                table.Columns.Add("Date", typeof(DateTime));
                table.Columns.Add("EventType", typeof(string));
                table.Columns.Add("Ingredient", typeof(string));
                table.Columns.Add("Quantity", typeof(int));
                table.Columns.Add("Unit", typeof(string));

                foreach (var e in sortedEvents)
                {
                    table.Rows.Add(e.Date, e.EventType, e.Ingredient, e.Quantity, e.Unit);
                }

                dataGridViewStorageHistory.DataSource = table;

                // Set column headers
                dataGridViewStorageHistory.Columns["EventType"].HeaderText = "Event Type";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Storage History: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

