using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.UI;

namespace CoffeeCompanyMS.UC
{
    public partial class LocationSelector : UserControl
    {
        public event EventHandler<string> SelectedItemChanged;
        private string[] locationids;

        public LocationSelector()
        {
            InitializeComponent();
        }

        private void LocationSelector_Load(object sender, EventArgs e)
        {
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

    }
}
