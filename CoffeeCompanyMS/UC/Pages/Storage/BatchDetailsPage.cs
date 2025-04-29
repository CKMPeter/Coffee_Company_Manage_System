using CoffeeCompanyMS.Forms.Authentication;
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
        private string LocationID;
        private string IngredientName;
        private Guid currentLocationId; // Biến này bạn gán sau khi chọn Location
        public BatchDetailsPage(string LocationID, string IngredientName)
        {
           InitializeComponent();
            this.LocationID = LocationID;
            this.IngredientName = IngredientName;
        }

        public BatchDetailsPage()
        {
            InitializeComponent();
            this.LocationID = "";
            this.IngredientName = "";
            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                if (Guid.TryParse(value, out Guid locationId))
                {
                    LocationID = value; // lưu nếu cần
                    LoadIngredients(locationId); // gọi hàm load ingredients luôn
                }
                else
                {
                    MessageBox.Show("Location ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }
        private void BatchDetailsPage_Load(object sender, EventArgs e)
        {
            LoadLocations();
            if (LocationID == "") return ;
            locationSelector1.SetSelectedLocationId(LocationID);
            if (Guid.TryParse(LocationID, out Guid locationId))
            {
                
                LoadIngredients(locationId); // gọi hàm load ingredients luôn
            }
            else
            {
                MessageBox.Show("Location ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (IngredientName == "") return;
            int index = comboBoxIngredient.Items.IndexOf(IngredientName);
            if (index >= 0 && index < comboBoxIngredient.Items.Count)
            {
                comboBoxIngredient.SelectedIndex = index;
            }
            LoadBatchDetails(IngredientName);
        }

        private void LoadLocations()
        {
            try
            {
                using (SqlConnection conn = SQLConnector.GetSqlConnection())
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


                            locationSelector1.SetLocations(locations, locationids);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Location: " + ex.Message);
            }
        }
        public void SetLocationAndIngredient(Guid locationId, string ingredientName)
        {
            currentLocationId = locationId;

            // Load Ingredients trước
            LoadIngredients(locationId);

            // Sau khi LoadIngredients xong thì set SelectedItem
            if (comboBoxIngredient.Items.Contains(ingredientName))
            {
                comboBoxIngredient.SelectedItem = ingredientName;
            }
            else
            {
                comboBoxIngredient.SelectedIndex = 0; // Nếu không thấy thì chọn đại dòng đầu
            }
        }
        public void LoadIngredients(Guid locationId)
        {
            try
            {
                using (SqlConnection conn = SQLConnector.GetSqlConnection())
                {
                    conn.Open();

                    // Gọi function - CHÚ Ý phải có dấu () sau tên function
                    string query = "SELECT * FROM dbo.GetPresentIngredientNames(@LocationID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@LocationID", SqlDbType.UniqueIdentifier).Value = locationId;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> ingredients = new List<string>();

                            while (reader.Read())
                            {
                                ingredients.Add(reader["Name"].ToString());
                            }

                            comboBoxIngredient.Items.Clear();
                            comboBoxIngredient.Items.AddRange(ingredients.ToArray());

                            if (ingredients.Count > 0)
                                comboBoxIngredient.SelectedIndex = 0; // Chọn sẵn item đầu tiên
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nguyên liệu: " + ex.Message);
            }
        }

        public void LoadBatchDetails(string ingredientName)
        {
            // Kết nối với database
            

            using (SqlConnection connection = SQLConnector.GetSqlConnection())
            {
                // Tạo SqlCommand để gọi function GetBatches
                string query = "SELECT * FROM dbo.GetBatches(@IngredientName)";
                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@IngredientName", ingredientName);

                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Sử dụng SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Nạp dữ liệu vào DataGridView
                    dataGridViewBatchDetails.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void comboBoxIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBoxIngredient.SelectedIndex >= 0)
            {
                IngredientName = comboBoxIngredient.SelectedItem.ToString();
                LoadBatchDetails(IngredientName);
            }
        }
    }
}
