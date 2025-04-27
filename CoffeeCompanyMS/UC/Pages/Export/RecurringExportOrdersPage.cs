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
        private string connectionString = "Data Source=LAPTOP-CRUATNF8;Initial Catalog=CoffeeCompany;Integrated Security=True;Connect Timeout=30;Encrypt=False"; // Connection string
        private string selectedLocationID;  // Keep it as string

        public RecurringExportOrdersPage()
        {
            InitializeComponent();
        }

        private void RecurringExportOrdersPage_Load(object sender, EventArgs e)
        {
            // Call method to load locations and recurring export orders when the page loads
            LoadLocations();

            // Subscribe to the SelectedItemChanged event from the LocationSelector
            locationSelector1.SelectedItemChanged += LocationSelector1_SelectedItemChanged;
        }

        // Method to load recurring export orders based on selected LocationID
        private void LoadRecurringExportOrders(string locationID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to call the function GetActiveRecurringExportOrders, filtering by LocationID
                    string query = "SELECT RecurrenceID, DestinationName, RecurrencePeriod, LastOrderDate, EstimatedNextOrderDate " +
                                   "FROM dbo.GetActiveRecurringExportOrders(@LocationID)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LocationID", locationID);  // Using string

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the data to the DataGridView
                    dataGridViewRecurring.DataSource = dt;
                    dataGridViewRecurring.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewRecurring.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewRecurring.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recurring export orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to load locations from database into a dropdown or list
        private void LoadLocations()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT LocationID, LocationName FROM dbo.GetLocations()";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> locations = new List<string>();
                            List<string> locationIds = new List<string>();  // Keep as string

                            while (reader.Read())
                            {
                                locations.Add(reader["LocationName"].ToString());
                                locationIds.Add(reader["LocationID"].ToString());  // Keep as string
                            }

                            // Assuming locationSelector1 is a ComboBox or ListBox that can display the Location names
                            locationSelector1.SetLocations(locations, locationIds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading locations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for when a location is selected from the location selector
        private void LocationSelector1_SelectedItemChanged(object sender, string locationID)
        {
            try
            {
                // Store selected LocationID
                selectedLocationID = locationID;

                // Reload the recurring export orders based on the selected LocationID
                LoadRecurringExportOrders(selectedLocationID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when selecting location: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button click event to create a new export order
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // This opens a dialog to create a new export order (implementation not shown)
            CreateExportOrder createExportOrder = new CreateExportOrder();
            createExportOrder.ShowDialog();
        }
    }
}
