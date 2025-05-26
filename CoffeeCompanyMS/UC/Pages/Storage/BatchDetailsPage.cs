using CoffeeCompanyMS.DAOs;
using CoffeeCompanyMS.DTOs;
using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using CoffeeCompanyMS.Patterns;

namespace CoffeeCompanyMS.UC.Pages.Storage
{
    public partial class BatchDetailsPage : UserControl
    {
        private Guid selectedLocationID;
        private string selectedIngredientName;

        public BatchDetailsPage(Guid locationID, string ingredientName)
        {
            InitializeComponent();
            this.selectedLocationID = locationID;
            this.selectedIngredientName = ingredientName;

            // Subscribe to the SelectedItemChanged event of the location selector
            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationID = value;

                // Reload comboBoxIngredient and batch details when the location changes
                comboBoxIngredient.SelectedIndex = -1; // Reset selection
                selectedIngredientName = "";
                LoadIngredients();
                LoadBatchDetails();
            };
        }

        public BatchDetailsPage()
        {
            InitializeComponent();
            this.selectedLocationID = Guid.Empty;
            this.selectedIngredientName = "";

            // Subscribe to the SelectedItemChanged event of the location selector
            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationID = value;

                // Reload comboBoxIngredient and batch details when the location changes
                comboBoxIngredient.SelectedIndex = -1; // Reset selection
                selectedIngredientName = "";
                LoadIngredients();
                LoadBatchDetails();
            };
        }

        private void comboBoxIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxIngredient.SelectedIndex >= 0)
            {
                selectedIngredientName = comboBoxIngredient.SelectedItem.ToString();
                LoadBatchDetails();
            }
        }

        private void BatchDetailsPage_Load(object sender, EventArgs e)
        {
            // Load ingredients for the selected location when the page loads
            // If a specific location ID was provided, set it in the location selector
            if (selectedLocationID != Guid.Empty)
            {
                locationSelector1.SetSelectedLocationId(selectedLocationID);
                LoadIngredients();
            }
            else
            {
                // If no location ID was provided, use the logged-in user's location
                selectedLocationID = locationSelector1.SelectedValue;
                if (selectedLocationID != Guid.Empty) LoadIngredients();
            }

            // If an ingredient name was provided, select it in the combo box
            if (selectedIngredientName == "") return;
            comboBoxIngredient.SelectedValue = selectedIngredientName;

            // Load batch details for the selected ingredient
            LoadBatchDetails();
        }

        public void LoadIngredients()
        {
            try
            {
                var batchDAO = DAOManager.Instance.BatchDAO;
                List<BatchSummaryDTO> summaries = batchDAO.GetIngredientSummariesByLocation(selectedLocationID);

                List<string> ingredients = summaries.Select(s => s.IngredientName).ToList();

                comboBoxIngredient.Items.Clear();
                comboBoxIngredient.Items.AddRange(ingredients.ToArray());

                if (ingredients.Count > 0)
                    comboBoxIngredient.SelectedIndex = 0;
                else
                {
                    comboBoxIngredient.SelectedIndex = -1; // No ingredients available
                    selectedIngredientName = String.Empty; // Reset selected ingredient name
                    MessageBox.Show("No ingredients found for the selected location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting Ingredients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadBatchDetails()
        {
            try
            {
                if (selectedLocationID == Guid.Empty || selectedIngredientName == String.Empty)
                {
                    dataGridViewBatchDetails.DataSource = new List<BatchDetailsDTO>();
                }
                else
                {
                    var batchDAO = DAOManager.Instance.BatchDAO;
                    List<BatchDetailsDTO> batchViews = batchDAO.GetBatchViewsByIngredientName(selectedIngredientName);
                    dataGridViewBatchDetails.DataSource = batchViews;
                }

                dataGridViewBatchDetails.Columns["BatchID"].HeaderText = "Batch ID";
                dataGridViewBatchDetails.Columns["IngredientName"].HeaderText = "Ingredient Name";
                dataGridViewBatchDetails.Columns["ReceiptDate"].HeaderText = "Receipt Date";
                dataGridViewBatchDetails.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                dataGridViewBatchDetails.Columns["Status"].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading batch details: " + ex.Message);
            }
        }

    }
}
