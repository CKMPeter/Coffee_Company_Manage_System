using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Navigations;
using CoffeeCompanyMS.UC.Pages.Import;
using CoffeeCompanyMS.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.UC.Pages.Export
{
    public partial class ExportOrderDetailsPage : UserControl
    {
        private Guid orderID;

        // Constructor with Order ID parameter
        public ExportOrderDetailsPage(Guid orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
        }

        // Event handler for Load event of the UserControl
        private void ExportOrderDetailsPage_Load(object sender, EventArgs e)
        {
            // Debug: Check if orderID is valid
            if (orderID == Guid.Empty)
            {
                MessageBox.Show("Invalid Order ID provided.");
                return;
            }
            // Load the export order details
            LoadOrderDetails();
        }

        // Function to load the export order details (destination and items)
        private void LoadOrderDetails()
        {
            try
            {
                // Debug: Check if orderID is valid
                MessageBox.Show("Loading details for Order ID: " + orderID);

                using (SqlConnection connection = UserSession.Instance.ConnectionFactory.CreateConnection())
                {
                    connection.Open();

                    // Retrieve destination information using the stored function 'GetExportDestinationInfo'
                    string destinationQuery = "SELECT DestinationName, DestinationAddress FROM dbo.GetExportDestinationInfo(@OrderID)";
                    SqlCommand destinationCommand = new SqlCommand(destinationQuery, connection);
                    destinationCommand.Parameters.AddWithValue("@OrderID", orderID);  // Ensure GUID is used

                    using (SqlDataReader reader = destinationCommand.ExecuteReader())
                    {
                        if (reader.Read())  // Check if data is found
                        {
                            // Debug: Show the retrieved destination
                            MessageBox.Show("Found destination: " + reader["DestinationName"].ToString());
                            lblDestinationName.Text = "Destination: " + reader["DestinationName"].ToString();
                            lblDestinationAddress.Text = "Address: " + reader["DestinationAddress"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No destination information found.");
                        }
                    }

                    // Retrieve the export order items using the stored function 'GetExportItemList'
                    string itemsQuery = "SELECT IngredientName, Quantity, Unit, UnitPrice, ExpirationDate FROM dbo.GetExportItemList(@OrderID)";
                    SqlDataAdapter adapter = new SqlDataAdapter(itemsQuery, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@OrderID", orderID);

                    DataTable itemsTable = new DataTable();
                    adapter.Fill(itemsTable);  // Load data into the DataTable

                    // Debug: Check the number of items
                    if (itemsTable.Rows.Count > 0)
                    {
                        MessageBox.Show("Found " + itemsTable.Rows.Count + " items.");
                    }
                    else
                    {
                        MessageBox.Show("No export items found.");
                    }

                    // Display items in the DataGridView
                    dgvExportItems.DataSource = itemsTable;
                    dgvExportItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvExportItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvExportItems.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message);
            }
        }
    }
}
