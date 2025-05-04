using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Models;
using CoffeeCompanyMS.UI;
using CoffeeCompanyMS.UI.Export;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CoffeeCompanyMS.UC.Pages.Export
{
    public partial class RecurringExportOrdersPage : UserControl
    {
        private string selectedLocationID;
        public Action<string> MoveToDetaisPage { get; set; }

        public RecurringExportOrdersPage()
        {
            InitializeComponent();
            selectedLocationID = String.Empty;

            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationID = value;
                LoadRecurringExportOrders(selectedLocationID);
            };
        }

        private void RecurringExportOrdersPage_Load(object sender, EventArgs e)
        {
            locationSelector1.LoadLocations();

            User user = UserSession.Instance.loggedInUser;

            // Check whether the logged-in user is a Warehouse Manager
            if (user != null && user.LocationID != String.Empty)
            {
                selectedLocationID = user.LocationID;
                locationSelector1.Disable();
            }

            if (selectedLocationID == String.Empty) return;
            locationSelector1.SetSelectedLocationId(selectedLocationID);

            LoadRecurringExportOrders(selectedLocationID);
        }

        private void LoadRecurringExportOrders(string locationID)
        {
            try
            {
                using (SqlConnection connection = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    connection.Open();

                    string query = "SELECT dbo.GetActiveRecurringExportOrders(@LocationID)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LocationID", locationID);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the data to the DataGridView
                    dataGridViewRecurring.DataSource = dt;

                    if (dataGridViewRecurring.Columns.Count > 0)
                    {
                        dataGridViewRecurring.Columns["RecurrenceID"].HeaderText = "Recurrence ID";
                        dataGridViewRecurring.Columns["DestinationName"].HeaderText = "Destination";
                        dataGridViewRecurring.Columns["RecurrencePeriod"].HeaderText = "Recurrence Period (days)";
                        dataGridViewRecurring.Columns["LatestOrderID"].HeaderText = "Latest Order ID";
                        dataGridViewRecurring.Columns["LatestOrderDate"].HeaderText = "Latest Order Date";
                        dataGridViewRecurring.Columns["EstimatedNextOrderDate"].HeaderText = "Estimated Next Order Date";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recurring export orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateExportOrder createExportOrder = new CreateExportOrder();
            createExportOrder.ShowDialog();
        }

        private void dataGridViewRecurring_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewRecurring.Rows[e.RowIndex];
                string orderID = selectedRow.Cells["LatestOrderID"].Value.ToString();
                MoveToDetaisPage(orderID);
            }
        }
    }
}
