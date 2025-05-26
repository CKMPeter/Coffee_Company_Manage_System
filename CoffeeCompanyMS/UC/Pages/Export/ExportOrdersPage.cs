using CoffeeCompanyMS.DAOs;
using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.Navigations;
using CoffeeCompanyMS.Patterns;
using CoffeeCompanyMS.UC.Pages.Import;
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
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace CoffeeCompanyMS.UC.Pages.Export
{
    public partial class ExportOrdersPage : UserControl
    {
        private Guid selectedLocationId;
        public Action<Guid> MoveToDetaisPage { get; set; }

        public ExportOrdersPage()
        {
            InitializeComponent();

            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationId = value;
                LoadExportOrders();
            };       
        }

        private void ExportOrdersPage_Load(object sender, EventArgs e)
        {
            selectedLocationId = locationSelector1.SelectedValue;
            if (selectedLocationId != Guid.Empty)
            {
                LoadExportOrders();
            }
        }

        private void LoadExportOrders()
        {
            try
            {
                var transferOrderDAO = DAOManager.Instance.TransferOrderDAO;
                var exportOrders = transferOrderDAO.GetExportOrderSummariesByLocationId(selectedLocationId);

                dataGridViewExportOrder.DataSource = exportOrders;

                if (dataGridViewExportOrder.Columns.Count > 0)
                {
                    dataGridViewExportOrder.Columns["OrderID"].HeaderText = "Order ID";
                    dataGridViewExportOrder.Columns["RecurrenceID"].HeaderText = "Recurrence ID";
                    dataGridViewExportOrder.Columns["DestinationName"].HeaderText = "Destination Name";
                    dataGridViewExportOrder.Columns["OrderDate"].HeaderText = "Order Date";
                    dataGridViewExportOrder.Columns["EstimatedDeliveryDate"].HeaderText = "Estimated Delivery Date";
                    dataGridViewExportOrder.Columns["ActualDeliveryDate"].HeaderText = "Actual Delivery Date";
                    dataGridViewExportOrder.Columns["Status"].HeaderText = "Status";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading export orders: " + ex.Message);
            }
        }


        private void dataGridViewExportOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewExportOrder.Rows[e.RowIndex];
                Guid orderID = Guid.Parse(selectedRow.Cells["OrderID"].Value.ToString());
                MoveToDetaisPage(orderID);
            }
        }
    }
}
