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
using CoffeeCompanyMS.Navigations;
using CoffeeCompanyMS.UC.Pages.Storage;
using CoffeeCompanyMS.UI;

namespace CoffeeCompanyMS.UC.Pages.Import
{
    public partial class ImportOrdersPage : UserControl
    {
        private string selectedLocationId;

        public ImportOrdersPage()
        {
            InitializeComponent();
            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                if (Guid.TryParse(value, out Guid locationId))
                {
                    selectedLocationId = value;
                    LoadImportOrders(locationId);
                }
                else
                {
                    MessageBox.Show("Location ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            //dataGridViewImportOrder.CellValueChanged += dataGridViewImportOrder_CellValueChanged;
        }

        private void ImportOrdersPage_Load(object sender, EventArgs e)
        {
            LoadLocations();
        }

        private void LoadLocations()
        {
            try
            {
                using (SqlConnection conn = UserSession.Instance.connectionFactory.CreateConnection())
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

                            locationSelector1.SetLocations(locations, locationIds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Location: " + ex.Message);
            }
        }

        private void LoadImportOrders(Guid locationId)
        {
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

                            // Đổi tên các cột
                            if (dataGridViewImportOrder.Columns.Count > 0)
                            {
                                dataGridViewImportOrder.Columns["OrderID"].HeaderText = "Order ID";
                                dataGridViewImportOrder.Columns["RecurrenceID"].HeaderText = "Recurrence ID";
                                dataGridViewImportOrder.Columns["SupplierName"].HeaderText = "Supplier Name";
                                dataGridViewImportOrder.Columns["OrderDate"].HeaderText = "Order Date";
                                dataGridViewImportOrder.Columns["EstimatedDeliveryDate"].HeaderText = "Estimated Delivery";
                                dataGridViewImportOrder.Columns["ActualDeliveryDate"].HeaderText = "Actual Delivery";
                                dataGridViewImportOrder.Columns["Status"].HeaderText = "Status";

                                // Thay thế Status thành ComboBox
                                ReplaceStatusColumnWithComboBox();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading import orders: " + ex.Message);
            }
        }

        private void ReplaceStatusColumnWithComboBox()
        {
            try
            {
                int statusColumnIndex = dataGridViewImportOrder.Columns["Status"].Index;

                // Xóa cột Text cũ
                dataGridViewImportOrder.Columns.Remove("Status");

                // Tạo ComboBoxColumn mới
                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    DataPropertyName = "Status", // để tự động bind data
                    FlatStyle = FlatStyle.Flat // nhìn combo box đẹp hơn
                };

                comboBoxColumn.Items.AddRange(new object[]
                {
                    "Pending", "Delayed", "Delivered", "Confirmed"
                });

                // Thêm lại cột ComboBox vào đúng vị trí
                dataGridViewImportOrder.Columns.Insert(statusColumnIndex, comboBoxColumn);

                // Set giá trị cho từng dòng
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
                SubNavManager.ShowPage(new ImportOrderDetailsPage(orderID));


            }
        }
    }
}
