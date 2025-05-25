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
using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.UI;

namespace CoffeeCompanyMS.UC
{
    public partial class LocationSelector : UserControl
    {
        public event EventHandler<string> SelectedItemChanged;
        private string[] locationids;

        public byte[] SelectedValue { get; internal set; }

        public LocationSelector()
        {
            InitializeComponent();
        }

        public void LoadLocations()
        {
            try
            {
                using (SqlConnection conn = UserSession.Instance.ConnectionFactory.CreateConnection())
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
                            SetLocations(locations, locationids);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting Locations: " + ex.Message);
            }
        }

        private void cbbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLocation.SelectedIndex >= 0 && locationids != null && locationids.Length > cbbLocation.SelectedIndex)
            {
                string selectedLocationId = locationids[cbbLocation.SelectedIndex];
                SelectedItemChanged?.Invoke(this, selectedLocationId);
            }
        }

        public void SetLocations(IEnumerable<string> locations, IEnumerable<string> locationids)
        {
            cbbLocation.Items.Clear();
            cbbLocation.Items.AddRange(locations.ToArray());
            this.locationids = locationids.ToArray();
        }

        public void SetSelectedLocationId(string locationId)
        {
            if (locationids != null)
            {
                int index = Array.IndexOf(locationids, locationId);
                if (index >= 0 && index < cbbLocation.Items.Count)
                {
                    cbbLocation.SelectedIndex = index;
                }
            }
        }

        public void Disable()
        {
            cbbLocation.Enabled = false;
        }
    }
}
