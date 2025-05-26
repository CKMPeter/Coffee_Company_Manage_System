using CoffeeCompanyMS.Models;
using CoffeeCompanyMS.Patterns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CoffeeCompanyMS.UC.Pages.Import
{
    public partial class ImportOrderDetailsPage : UserControl
    {
        private Guid selectedOrderID;

        public ImportOrderDetailsPage(Guid orderID)
        {
            InitializeComponent();
            this.selectedOrderID = orderID;
        }

        private void ImportOrderDetailsPage_Load(object sender, EventArgs e)
        {
            LoadOrderSummary();
            LoadOrderItems();
        }

        private void LoadOrderSummary()
        {
            try
            {
                var itemDAO = DAOManager.Instance.TransferOrderItemDAO;
                var ingredientDAO = DAOManager.Instance.IngredientDAO;
                var supplierDAO = DAOManager.Instance.SupplierDAO;

                List<TransferOrderItem> items = itemDAO.GetItemsByTransferOrderId(selectedOrderID);
                int itemCount = items.Count;

                string supplierName = "Unknown";

                if (itemCount > 0)
                {
                    Guid ingredientId = items[0].Ingredient.Id;

                    Guid? supplierId = ingredientDAO.GetSupplierIdByIngredientId(ingredientId);
                    if (supplierId.HasValue)
                    {
                        Supplier supplier = supplierDAO.GetSupplierById(supplierId.Value);
                        supplierName = supplier?.Name ?? "Unknown";
                    }
                }

                label2.Text = selectedOrderID.ToString();
                label4.Text = supplierName;
                label6.Text = itemCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting order summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderItems()
        {
            try
            {
                var transferOrderItemDAO = DAOManager.Instance.TransferOrderItemDAO;
                var items = transferOrderItemDAO.GetItemsByTransferOrderId(selectedOrderID);

                var table = new DataTable();
                table.Columns.Add("IngredientName", typeof(string));
                table.Columns.Add("Quantity", typeof(int));
                table.Columns.Add("Unit", typeof(string));
                table.Columns.Add("UnitPrice", typeof(decimal));
                table.Columns.Add("ExpirationDate", typeof(DateTime));

                foreach (var item in items)
                {
                    var ing = item.Ingredient;
                    table.Rows.Add(ing.Name, item.Quantity, ing.Unit, ing.UnitPrice, item.ExpirationDate);
                }

                dataGridViewItems.DataSource = table;

                if (dataGridViewItems.Columns.Count > 0)
                {
                    dataGridViewItems.Columns["IngredientName"].HeaderText = "Ingredient Name";
                    dataGridViewItems.Columns["UnitPrice"].HeaderText = "Unit Price ($)";
                    dataGridViewItems.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting order items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
