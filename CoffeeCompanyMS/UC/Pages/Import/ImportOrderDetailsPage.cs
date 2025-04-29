using CoffeeCompanyMS.Forms.Authentication;
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

namespace CoffeeCompanyMS.UC.Pages.Import
{
    public partial class ImportOrderDetailsPage : UserControl
    {
        private string orderID;

        public ImportOrderDetailsPage()
        {
            InitializeComponent();
            orderID = string.Empty;
        }

        public ImportOrderDetailsPage(string orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
            LoadOrderSummary();
            LoadOrderItems();
        }

        private void LoadOrderSummary()
        {
            try
            {
                using (SqlConnection conn = SQLConnector.GetSqlConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            t.ID AS OrderID,
                            dbo.GetImportSupplierName(t.ID) AS SupplierName,
                            dbo.GetOrderItemCount(t.ID) AS ItemCount
                        FROM TransferOrder t
                        WHERE t.ID = @OrderID
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                label2.Text = reader["OrderID"].ToString();
                                label4.Text = reader["SupplierName"].ToString();
                                label6.Text = reader["ItemCount"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy đơn nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderItems()
        {
            try
            {
                using (SqlConnection conn = SQLConnector.GetSqlConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM dbo.GetImportItemList(@OrderID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dataGridViewItems.DataSource = table;

                            if (dataGridViewItems.Columns.Count > 0)
                            {
                                dataGridViewItems.Columns["IngredientName"].HeaderText = "Nguyên liệu";
                                dataGridViewItems.Columns["Quantity"].HeaderText = "Số lượng";
                                dataGridViewItems.Columns["Unit"].HeaderText = "Đơn vị";
                                dataGridViewItems.Columns["UnitPrice"].HeaderText = "Giá nhập";
                                dataGridViewItems.Columns["ExpirationDate"].HeaderText = "Hạn sử dụng";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
