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

namespace CoffeeCompanyMS.UC.Pages.Storage
{
    public partial class StorageHistoryPage : UserControl
    {
        private string selectedLocationId;
        private string connectionString = Main.connectionstring;
        public StorageHistoryPage()
        {
            InitializeComponent();
            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                if (Guid.TryParse(value, out Guid locationId))
                {
                    selectedLocationId = value;
                    LoadStorageHistory(locationId);
                }
                else
                {
                    MessageBox.Show("Location ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        private void StorageHistoryPage_Load(object sender, EventArgs e)
        {
            LoadLocations();
        }

        private void LoadLocations()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
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

        private void LoadStorageHistory(Guid locationId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "EXEC GetIngredientEvents @LocationID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@LocationID", SqlDbType.UniqueIdentifier).Value = locationId;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridViewStorageHistory.DataSource = dataTable;

                            dataGridViewStorageHistory.Columns["Date"].HeaderText = "Date";
                            dataGridViewStorageHistory.Columns["EventType"].HeaderText = "EventType";
                            dataGridViewStorageHistory.Columns["Ingredient"].HeaderText = "Ingredient";
                            dataGridViewStorageHistory.Columns["Quantity"].HeaderText = "Quantity";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử kho: " + ex.Message);
            }
        }
    }



}

