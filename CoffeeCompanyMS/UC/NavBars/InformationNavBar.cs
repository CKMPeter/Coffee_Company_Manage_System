using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.Navigations;
using CoffeeCompanyMS.UC.NavBars;
using CoffeeCompanyMS.UC.Pages.Information;

namespace CoffeeCompanyMS.UC
{
    public partial class InformationNavBar : UserControl
    {
        private Button[] _buttons;
        private SuppliersPage _suppliersPage;
        private IngredientsPage _ingredientsPage;
        private LocationsPage _locationsPage;

        public InformationNavBar()
        {
            InitializeComponent();
            _buttons = new Button[] {
                btnSuppliers,
                btnIngredients,
                btnLocations
            };
            _suppliersPage = new SuppliersPage();
            _ingredientsPage = new IngredientsPage();
            _locationsPage = new LocationsPage();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnSuppliers);
            SubNavManager.ShowPage(_suppliersPage);
        }

        private void btnIngredients_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnIngredients);
            SubNavManager.ShowPage(_ingredientsPage);
        }

        private void btnLocations_Click(object sender, EventArgs e)
        {
            resetStyle();
            NavButtonStyleUtils.SetChosenButtonStyle(btnLocations);
            SubNavManager.ShowPage(_locationsPage);
        }

        private void resetStyle()
        {
            NavButtonStyleUtils.ResetButtonsStyle(_buttons);
        }

        private void pbReload_Click(object sender, EventArgs e)
        {
            _suppliersPage = new SuppliersPage();
            _ingredientsPage = new IngredientsPage();
            _locationsPage = new LocationsPage();
        }
    }
}
