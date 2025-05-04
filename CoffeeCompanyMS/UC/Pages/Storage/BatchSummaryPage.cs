using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Navigations;
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
using CoffeeCompanyMS.Models;
using Google.Protobuf.WellKnownTypes;

namespace CoffeeCompanyMS.UC.Pages.Storage
{
    public partial class BatchSummaryPage : UserControl
    {
        public string selectedLocationID;
        public Action<string, string> MoveToDetaisPage {  get; set; }

        public BatchSummaryPage()
        {
            InitializeComponent();
            selectedLocationID = "";

            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationID = value;
                LoadIngredients(selectedLocationID);
            };
        }

        private void BatchSummaryPage_Load(object sender, EventArgs e)
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

            LoadIngredients(selectedLocationID);
        }

        private void LoadIngredients(string locationID)
        {
            try
            {
                using (SqlConnection conn = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("GetIngredients", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LocationID", locationID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dataGridViewBatchSummary.DataSource = dt;

                            if (dataGridViewBatchSummary.Columns.Count > 0)
                            {
                                dataGridViewBatchSummary.Columns["IngredientName"].HeaderText = "Ingredient Name";
                                dataGridViewBatchSummary.Columns["NumberOfBatches"].HeaderText = "Number Of Batches";
                                dataGridViewBatchSummary.Columns["TotalQuantity"].HeaderText = "Total Quantity";
                                dataGridViewBatchSummary.Columns["ClosestExpirationDate"].HeaderText = "Closest Expiration Date";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting Ingredients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewBatchSummary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewBatchSummary.Rows[e.RowIndex];
                string ingredientName = selectedRow.Cells["IngredientName"].Value.ToString();
                MoveToDetaisPage(selectedLocationID, ingredientName);
            }
        }
    }
}
