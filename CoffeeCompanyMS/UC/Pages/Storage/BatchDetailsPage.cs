using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Models;
using CoffeeCompanyMS.UI;
using Google.Protobuf.WellKnownTypes;
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

namespace CoffeeCompanyMS.UC.Pages.Storage
{
    public partial class BatchDetailsPage : UserControl
    {
        private string selectedLocationID;
        private string selectedIngredientName;

        public BatchDetailsPage(string locationID, string ingredientName)
        {
            InitializeComponent();
            this.selectedLocationID = locationID;
            this.selectedIngredientName = ingredientName;
        }

        public BatchDetailsPage()
        {
            InitializeComponent();
            this.selectedLocationID = "";
            this.selectedIngredientName = "";
            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationID = value;
                LoadIngredients(selectedLocationID);
            };
        }

        private void comboBoxIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxIngredient.SelectedIndex >= 0)
            {
                selectedIngredientName = comboBoxIngredient.SelectedItem.ToString();
                LoadBatchDetails(selectedIngredientName);
            }
        }

        private void BatchDetailsPage_Load(object sender, EventArgs e)
        {
            locationSelector1.LoadLocations();

            User user = UserSession.Instance.loggedInUser;

            // Check whether the logged-in user is a Warehouse Manager
            if (user != null && user.LocationID != String.Empty)
            {
                selectedLocationID = user.LocationID;
                locationSelector1.Disable();
            }

            if (selectedLocationID == "") return;
            locationSelector1.SetSelectedLocationId(selectedLocationID);

            LoadIngredients(selectedLocationID);

            if (selectedIngredientName == "") return;
            comboBoxIngredient.SelectedValue = selectedIngredientName;

            LoadBatchDetails(selectedIngredientName);
        }

        public void LoadIngredients(string locationID)
        {
            try
            {
                using (SqlConnection conn = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("GetIngredients", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LocationID", locationID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> ingredients = new List<string>();

                            while (reader.Read())
                            {
                                ingredients.Add(reader["IngredientName"].ToString());
                            }

                            comboBoxIngredient.Items.Clear();
                            comboBoxIngredient.Items.AddRange(ingredients.ToArray());

                            if (ingredients.Count > 0)
                                comboBoxIngredient.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting Ingredients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadBatchDetails(string ingredientName)
        {
            using (SqlConnection conn = UserSession.Instance.connectionFactory.CreateConnection())
            {
                string query = "SELECT * FROM dbo.GetBatches(@IngredientName)";
                SqlCommand command = new SqlCommand(query, conn);
                
                command.Parameters.AddWithValue("@IngredientName", ingredientName);

                try
                {
                    conn.Open();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();

                        dataAdapter.Fill(dataTable);
                        dataGridViewBatchDetails.DataSource = dataTable;

                        dataGridViewBatchDetails.Columns["BatchID"].HeaderText = "Batch ID";
                        dataGridViewBatchDetails.Columns["IngredientName"].HeaderText = "Ingredient Name";
                        dataGridViewBatchDetails.Columns["ReceiptDate"].HeaderText = "Receipt Date";
                        dataGridViewBatchDetails.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
