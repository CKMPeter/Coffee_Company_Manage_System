using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Navigations;
using CoffeeCompanyMS.UC.Pages.Import;
using CoffeeCompanyMS.UI;
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
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace CoffeeCompanyMS.UC.Pages.Export
{
    public partial class ExportOrdersPage : UserControl
    {
        private string selectedLocationId;
        public Action<string> MoveToDetaisPage { get; set; }

        public ExportOrdersPage()
        {
            InitializeComponent();
            selectedLocationId = "";

            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationId = value;
                LoadExportOrders();
            };       
        }

        private void ExportOrdersPage_Load(object sender, EventArgs e)
        {
            locationSelector1.LoadLocations();
        }

        private void LoadExportOrders()
        {
            try
            {
                using (SqlConnection connection = UserSession.Instance.ConnectionFactory.CreateConnection())
                {
                    connection.Open();

                    string query = "SELECT * FROM dbo.GetExportOrders(@LocationID)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LocationID", selectedLocationId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridViewExportOrder.DataSource = dataTable;

                            if (dataGridViewExportOrder.Columns.Count > 0)
                            {
                                dataGridViewExportOrder.Columns["OrderID"].HeaderText = "Order ID";
                                dataGridViewExportOrder.Columns["RecurrenceID"].HeaderText = "Recurrence ID";
                                dataGridViewExportOrder.Columns["DestinationName"].HeaderText = "Destination Name";
                                dataGridViewExportOrder.Columns["OrderDate"].HeaderText = "Order Date";
                                dataGridViewExportOrder.Columns["EstimatedDeliveryDate"].HeaderText = "Estimated Delivery Date";
                                dataGridViewExportOrder.Columns["ActualDeliveryDate"].HeaderText = "Actual Delivery Date";

                                ReplaceStatusColumnWithComboBox();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading export orders: " + ex.Message);
            }
        }
        private void ReplaceStatusColumnWithComboBox()
        {
            try
            {
                // Remove current Status column with the combobox column
                int statusColumnIndex = dataGridViewExportOrder.Columns["Status"].Index;

                dataGridViewExportOrder.Columns.Remove("Status");

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

                dataGridViewExportOrder.Columns.Insert(statusColumnIndex, comboBoxColumn);

                // Set the selected values for each comboboxes
                foreach (DataGridViewRow row in dataGridViewExportOrder.Rows)
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

        private void dataGridViewExportOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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

        private void UpdateOrderStatus(Guid orderId, string newStatus)
        {
            try
            {
                using (SqlConnection connection = UserSession.Instance.ConnectionFactory.CreateConnection())
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

        private void dataGridViewExportOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewExportOrder.Rows[e.RowIndex];
                string orderID = selectedRow.Cells["OrderID"].Value.ToString();
                NavigationManager.ShowPage(new ExportOrderDetailsPage(orderID));
            }
        }
    }
}
