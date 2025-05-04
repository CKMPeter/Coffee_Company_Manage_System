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
        private string selectedOrderID;

        public ImportOrderDetailsPage()
        {
            InitializeComponent();
            selectedOrderID = string.Empty;
        }

        public ImportOrderDetailsPage(string orderID)
        {
            InitializeComponent();
            this.selectedOrderID = orderID;
        }

        private void ImportOrderDetailsPage_Load(object sender, EventArgs e)
        {
            LoadOrderSummary(selectedOrderID);
            LoadOrderItems(selectedOrderID);
        }

        private void LoadOrderSummary(string orderID)
        {
            try
            {
                using (SqlConnection conn = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    conn.Open();
                    string query = @"SELECT * FROM dbo.GetImportOrderSummary(@OrderID)";

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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting order summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderItems(string orderID)
        {
            try
            {
                using (SqlConnection conn = UserSession.Instance.connectionFactory.CreateConnection())
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
                                dataGridViewItems.Columns["IngredientName"].HeaderText = "Ingredient Name";
                                dataGridViewItems.Columns["UnitPrice"].HeaderText = "Unit Price ($)";
                                dataGridViewItems.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting order summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
