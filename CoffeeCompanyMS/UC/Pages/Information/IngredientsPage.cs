using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.UI.Information;

namespace CoffeeCompanyMS.UC.Pages.Information
{
    public partial class IngredientsPage : UserControl
    {
        public IngredientsPage()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateIngredient createIngredient = new CreateIngredient();
            createIngredient.ShowDialog();
        }
    }
}
