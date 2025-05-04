using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Models;
using CoffeeCompanyMS.UI.Import;

namespace CoffeeCompanyMS.UC.Pages.Import
{
    public partial class RecurringImportOrdersPage : UserControl
    {
        private string selectedLocationID;
        public Action<string> MoveToDetaisPage { get; set; }

        public RecurringImportOrdersPage()
        {
            InitializeComponent();
            selectedLocationID = string.Empty;

            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationID = value;
                LoadRecurringImportOrders(selectedLocationID);
            };
        }

        private void RecurringImportOrders_Load(object sender, EventArgs e)
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

            LoadRecurringImportOrders(selectedLocationID);
        }

        private void LoadRecurringImportOrders(string locationID)
        {
            try
            {
                using (SqlConnection conn = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM dbo.GetActiveRecurringImportOrders(@LocationID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LocationID", locationID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dataGridViewRecurringOrders.DataSource = dt;

                            if (dataGridViewRecurringOrders.Columns.Count > 0)
                            {
                                dataGridViewRecurringOrders.Columns["RecurrenceID"].HeaderText = "Recurrence ID";
                                dataGridViewRecurringOrders.Columns["SupplierName"].HeaderText = "Supplier";
                                dataGridViewRecurringOrders.Columns["RecurrencePeriod"].HeaderText = "Recurrence Period (days)";
                                dataGridViewRecurringOrders.Columns["LatestOrderID"].HeaderText = "Latest Order ID";
                                dataGridViewRecurringOrders.Columns["LatestOrderDate"].HeaderText = "Latest Order Date";
                                dataGridViewRecurringOrders.Columns["EstimatedNextOrderDate"].HeaderText = "Estimated Next Order Date";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting Recurring Import Orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateImportOrder createImportOrder = new CreateImportOrder();
            createImportOrder.ShowDialog();
        }

        private void dataGridViewRecurringOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewRecurringOrders.Rows[e.RowIndex];
                string orderID = selectedRow.Cells["LatestOrderID"].Value.ToString();
                MoveToDetaisPage(orderID);
            }
        }

        private void CancelRecurringOrder(string orderId)
        {
            try
            {
                using (SqlConnection connection = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("CancelRecurringImportOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ImportOrderID", orderId);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Recurring order cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error canceling recurring order: " + ex.Message, "Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
