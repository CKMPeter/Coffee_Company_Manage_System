﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeCompanyMS.UI.Import
{
    public partial class CreateImportOrder : Form
    {
        public bool isRecurrence;
        public string deliveryDate;
        public DataTable ingredientTable;

        public CreateImportOrder()
        {
            InitializeComponent();
        }

        private void DTPDeliveryDate_ValueChanged(object sender, EventArgs e)
        {
            labeldate.Text = DTPDeliveryDate.Value.ToString("yyyy-MM-dd");
        }
    }
}
