using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Models;
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

namespace CoffeeCompanyMS.UC.Pages.Storage
{
    public partial class StorageHistoryPage : UserControl
    {
        private string selectedLocationID;

        public StorageHistoryPage()
        {
            InitializeComponent();
            selectedLocationID = "";

            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationID = value;
                LoadStorageHistory(selectedLocationID);
            };
        }

        private void StorageHistoryPage_Load(object sender, EventArgs e)
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

            LoadStorageHistory(selectedLocationID);
        }

        private void LoadStorageHistory(string locationID)
        {
            try
            {
                using (SqlConnection conn = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("GetIngredientEvents", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LocationID", locationID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridViewStorageHistory.DataSource = dataTable;

                            dataGridViewStorageHistory.Columns["EventType"].HeaderText = "Event Type";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Storage History: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }



}

