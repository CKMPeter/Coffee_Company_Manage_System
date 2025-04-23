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

        public LocationSelector()
        {
            InitializeComponent();
        }

        private void LocationSelector_Load(object sender, EventArgs e)
        {
        }

        private void cbbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLocation.SelectedItem != null)
            {
                SelectedItemChanged?.Invoke(this, cbbLocation.SelectedItem.ToString());
            }
        }

        public void SetLocations(IEnumerable<string> locations)
        {
            cbbLocation.Items.Clear();
            cbbLocation.Items.AddRange(locations.ToArray());
        }

    }
}
