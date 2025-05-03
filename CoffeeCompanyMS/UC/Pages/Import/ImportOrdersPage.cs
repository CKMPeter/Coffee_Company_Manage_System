using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Models;
using CoffeeCompanyMS.Navigations;
using CoffeeCompanyMS.UC.Pages.Storage;
using CoffeeCompanyMS.UI;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace CoffeeCompanyMS.UC.Pages.Import
{
    public partial class ImportOrdersPage : UserControl
    {
        private string selectedLocationID;
        public Action<string> MoveToDetaisPage { get; set; }

        public ImportOrdersPage()
        {
            InitializeComponent();
            selectedLocationID = "";

            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationID = value;
                LoadImportOrders();
            };
        }

        private void ImportOrdersPage_Load(object sender, EventArgs e)
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

            LoadImportOrders();
        }

        private void LoadImportOrders()
        {
            Guid locationId;

            if (!Guid.TryParse(selectedLocationID, out locationId))
            {
                MessageBox.Show("Invalid Location ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    connection.Open();

                    string query = "SELECT * FROM dbo.GetImportOrders(@LocationID)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LocationID", locationId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridViewImportOrder.DataSource = dataTable;

                            if (dataGridViewImportOrder.Columns.Count > 0)
                            {
                                dataGridViewImportOrder.Columns["OrderID"].HeaderText = "Order ID";
                                dataGridViewImportOrder.Columns["RecurrenceID"].HeaderText = "Recurrence ID";
                                dataGridViewImportOrder.Columns["SupplierName"].HeaderText = "Supplier Name";
                                dataGridViewImportOrder.Columns["OrderDate"].HeaderText = "Order Date";
                                dataGridViewImportOrder.Columns["EstimatedDeliveryDate"].HeaderText = "Estimated Delivery";
                                dataGridViewImportOrder.Columns["ActualDeliveryDate"].HeaderText = "Actual Delivery";

                                ReplaceStatusColumnWithComboBox();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading import orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReplaceStatusColumnWithComboBox()
        {
            try
            {
                // Remove current Status column with the combobox column
                int statusColumnIndex = dataGridViewImportOrder.Columns["Status"].Index;

                dataGridViewImportOrder.Columns.Remove("Status");

                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    DataPropertyName = "Status",
                    FlatStyle = FlatStyle.Flat
                };

                comboBoxColumn.Items.AddRange(new object[]
                {
                    "Pending", "Delayed", "Delivered", "Confirmed"
                });

                dataGridViewImportOrder.Columns.Insert(statusColumnIndex, comboBoxColumn);


                // Set the selected values for each comboboxes
                foreach (DataGridViewRow row in dataGridViewImportOrder.Rows)
                {
                    if (row.Cells["Status"] is DataGridViewComboBoxCell cell && row.DataBoundItem != null)
                    {
                        DataRowView dataRowView = row.DataBoundItem as DataRowView;
                        if (dataRowView != null)
                        {
                            string currentStatus = dataRowView["Status"].ToString();
                            if (!string.IsNullOrEmpty(currentStatus))
                            {
                                cell.Value = currentStatus;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting up Status ComboBox: " + ex.Message);
            }
        }

        private void dataGridViewImportOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dgv = sender as DataGridView;
                    string columnName = dgv.Columns[e.ColumnIndex].Name;

                    if (columnName == "Status")
                    {
                        DataGridViewRow row = dgv.Rows[e.RowIndex];

                        object orderIdObj = row.Cells["OrderID"].Value;
                        object newStatusObj = row.Cells["Status"].Value;

                        if (orderIdObj != null && newStatusObj != null)
                        {
                            if (Guid.TryParse(orderIdObj.ToString(), out Guid orderId))
                            {
                                string newStatus = newStatusObj.ToString();
                                UpdateOrderStatus(orderId, newStatus);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while changing status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm cập nhật trạng thái Import Order
        private void UpdateOrderStatus(Guid orderId, string newStatus)
        {
            try
            {
                using (SqlConnection connection = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateTransferOrderStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransferOrderID", orderId);
                        command.Parameters.AddWithValue("@NewStatus", newStatus);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void dataGridViewImportOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewImportOrder.Rows[e.RowIndex];
                string orderID = selectedRow.Cells["OrderID"].Value.ToString();
                MoveToDetaisPage(orderID);
            }
        }
    }
}
