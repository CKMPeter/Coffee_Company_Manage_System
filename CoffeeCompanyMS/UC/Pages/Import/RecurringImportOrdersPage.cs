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
using CoffeeCompanyMS.UI;
using CoffeeCompanyMS.UI.Import;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

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
                LoadRecurringImportOrders();
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

            LoadRecurringImportOrders();
        }

        private void LoadRecurringImportOrders()
        {
            try
            {
                using (SqlConnection conn = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM dbo.GetActiveRecurringImportOrders(@LocationID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LocationID", selectedLocationID);

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
                                    dataGridViewRecurringOrders.Columns["RecurrencePeriod"].HeaderText = "Recurrence Period (days)";
                                    dataGridViewRecurringOrders.Columns["LatestOrderID"].HeaderText = "Latest Order ID";
                                    dataGridViewRecurringOrders.Columns["LatestOrderDate"].HeaderText = "Latest Order Date";
                                    dataGridViewRecurringOrders.Columns["EstimatedNextOrderDate"].HeaderText = "Estimated Next Order Date";
                                }
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
            CreateImportOrders createImportOrders = new CreateImportOrders();
            createImportOrders.ShowDialog();
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
    }
}
