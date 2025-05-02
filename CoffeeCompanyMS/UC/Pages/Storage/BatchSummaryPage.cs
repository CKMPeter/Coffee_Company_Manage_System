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

namespace CoffeeCompanyMS.UC.Pages.Storage
{
    public partial class BatchSummaryPage : UserControl
    {
        public string selectedLocationId;

        public BatchSummaryPage()
        {
            InitializeComponent();
            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                if (Guid.TryParse(value, out Guid locationId))
                {
                    selectedLocationId = value; // lưu nếu cần
                    LoadIngredients(locationId); // gọi hàm load ingredients luôn
                }
                else
                {
                    MessageBox.Show("Location ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            dataGridViewBatchSummary.CellDoubleClick += dataGridViewBatchSummary_CellDoubleClick;
        }

        private void BatchSummaryPage_Load(object sender, EventArgs e)
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
                            List<string> locationids = new List<string>();
                            while (reader.Read())
                            {
                                locations.Add(reader["LocationName"].ToString());
                                locationids.Add(reader["LocationID"].ToString());
                            }

                           
                            locationSelector1.SetLocations(locations,locationids);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Location: " + ex.Message);
            }
        }

        private void LoadIngredients(Guid locationId)
        {
            try
            {
                using (SqlConnection conn = UserSession.Instance.connectionFactory.CreateConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("GetIngredients", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // THAY ĐOẠN NÀY
                        cmd.Parameters.Add("@LocationID", SqlDbType.UniqueIdentifier).Value = locationId;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dataGridViewBatchSummary.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nguyên liệu: " + ex.Message);
            }
        }

        private void dataGridViewBatchSummary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewBatchSummary.Rows[e.RowIndex];
                string ingredientName = selectedRow.Cells["IngredientName"].Value.ToString();
                SubNavManager.ShowPage(new BatchDetailsPage(selectedLocationId, ingredientName));
                
                
            }

        }
    }
}
