using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS
{
    public partial class Storage : Form
    {
        public Storage()
        {
            InitializeComponent();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            resetSize();
            btnStock.FlatAppearance.BorderSize = 5;
            btnStock.FlatAppearance.BorderColor = Color.Navy;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            resetSize();
            btnHistory.FlatAppearance.BorderSize = 5;
            btnHistory.FlatAppearance.BorderColor = Color.Navy;
        }

        private void resetSize()
        {
            btnStock.FlatAppearance.BorderSize = 1;
            btnHistory.FlatAppearance.BorderSize = 1;
            btnStock.FlatAppearance.BorderColor = Color.Black;
            btnHistory.FlatAppearance.BorderColor = Color.Black;
        }
    }
}
