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
using CoffeeCompanyMS.UI;
using CoffeeCompanyMS.UI.Import;

namespace CoffeeCompanyMS.UC.Pages.Import
{
    public partial class RecurringImportOrdersPage : UserControl
    {
        private string selectedLocationId;

        public RecurringImportOrdersPage()
        {
            InitializeComponent();
            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                if (Guid.TryParse(value, out Guid locationId))
                {
                    selectedLocationId = value;
                    LoadRecurringImportOrders(locationId);
                }
                else
                {
                    MessageBox.Show("Location ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        private void RecurringImportOrders_Load(object sender, EventArgs e)
        {
            LoadLocations();
        }

        private void LoadLocations()
        {
            try
            {
                using (SqlConnection conn = SQLConnector.GetSqlConnection())
                {
                    conn.Open();

                    string query = "SELECT LocationID, LocationName FROM dbo.GetLocations()";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> locations = new List<string>();
                            List<string> locationIds = new List<string>();

                            while (reader.Read())
                            {
                                locations.Add(reader["LocationName"].ToString());
                                locationIds.Add(reader["LocationID"].ToString());
                            }

                            if (locationSelector1 != null)
                            {
                                locationSelector1.SetLocations(locations, locationIds);

                                if (locationIds.Count == 0)
                                {
                                    MessageBox.Show("No locations found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Location selector is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải Locations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecurringImportOrders(Guid locationId)
        {
            try
            {
                if (locationId == Guid.Empty)
                {
                    MessageBox.Show("Invalid Location ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = SQLConnector.GetSqlConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM dbo.GetActiveRecurringImportOrders(@LocationID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LocationID", locationId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                dataGridViewRecurringOrders.DataSource = dt;

                                if (dataGridViewRecurringOrders.Columns.Count > 0)
                                {
                                    dataGridViewRecurringOrders.Columns["RecurrenceID"].HeaderText = "Recurrence ID";
                                    dataGridViewRecurringOrders.Columns["SupplierName"].HeaderText = "Supplier";
                                    dataGridViewRecurringOrders.Columns["RecurrencePeriod"].HeaderText = "Period";
                                    dataGridViewRecurringOrders.Columns["LastOrderDate"].HeaderText = "Last Order";
                                    dataGridViewRecurringOrders.Columns["EstimatedNextOrderDate"].HeaderText = "Estimated Next Order";

             
                                }
                            }
                            else
                            {
                                MessageBox.Show("No recurring import orders found for the selected location.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải Recurring Import Orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatRecurrencePeriodColumn()
        {
            if (!dataGridViewRecurringOrders.Columns.Contains("RecurrencePeriod"))
                return;

            foreach (DataGridViewRow row in dataGridViewRecurringOrders.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var recurrencePeriod = row.Cells["RecurrencePeriod"].Value?.ToString();
                if (!string.IsNullOrEmpty(recurrencePeriod))
                {
                    row.Cells["RecurrencePeriod"].Value = recurrencePeriod + " days";
                }
            }
        }

        private void FormatSupplierNameColumn()
        {
            if (!dataGridViewRecurringOrders.Columns.Contains("SupplierName"))
                return;

            foreach (DataGridViewRow row in dataGridViewRecurringOrders.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var supplierNameCell = row.Cells["SupplierName"];
                if (supplierNameCell != null)
                {
                    supplierNameCell.Value = "Store Branch " + (selectedLocationId ?? "Unknown");
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (locationSelector1 != null && locationSelector1.SelectedValue != null)
            {
                CreateImportOrders createImportOrders = new CreateImportOrders();
                createImportOrders.ShowDialog();

                LoadRecurringImportOrders(new Guid(locationSelector1.SelectedValue.ToString()));
            }
            else
            {
                MessageBox.Show("Please select a location first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
