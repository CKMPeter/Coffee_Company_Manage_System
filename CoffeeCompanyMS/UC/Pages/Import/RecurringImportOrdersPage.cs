using System;
using System.ComponentModel;
using System.Windows.Forms;
using CoffeeCompanyMS.DTOs;
using CoffeeCompanyMS.Models;
using CoffeeCompanyMS.Patterns;
using CoffeeCompanyMS.UI.Import;

namespace CoffeeCompanyMS.UC.Pages.Import
{
    public partial class RecurringImportOrdersPage : UserControl
    {
        private Guid selectedLocationID;
        public Action<Guid> MoveToDetaisPage { get; set; }

        public RecurringImportOrdersPage()
        {
            InitializeComponent();

            locationSelector1.SelectedItemChanged += (s, value) =>
            {
                selectedLocationID = value;
                LoadRecurringImportOrders();
            };
        }

        private void RecurringImportOrders_Load(object sender, EventArgs e)
        {
            selectedLocationID = locationSelector1.SelectedValue;
            if (selectedLocationID != Guid.Empty)
            {
                LoadRecurringImportOrders();
            }
        }

        private void LoadRecurringImportOrders()
        {
            try
            {
                var transferOrderDAO = DAOManager.Instance.TransferOrderDAO;

                var orders = transferOrderDAO.GetActiveRecurringImportOrders(selectedLocationID);

                dataGridViewRecurringOrders.DataSource = new BindingList<RecurringImportOrderDTO>(orders);

                if (dataGridViewRecurringOrders.Columns.Count > 0)
                {
                    dataGridViewRecurringOrders.Columns["RecurrenceID"].HeaderText = "Recurrence ID";
                    dataGridViewRecurringOrders.Columns["SupplierName"].HeaderText = "Supplier";
                    dataGridViewRecurringOrders.Columns["RecurrencePeriod"].HeaderText = "Recurrence Period (days)";
                    dataGridViewRecurringOrders.Columns["LatestOrderID"].HeaderText = "Latest Order ID";
                    dataGridViewRecurringOrders.Columns["LatestOrderDate"].HeaderText = "Latest Order Date";
                    dataGridViewRecurringOrders.Columns["EstimatedNextOrderDate"].HeaderText = "Estimated Next Order Date";
                    AddCancelBtnColumn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting Recurring Import Orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCancelBtnColumn()
        {
            if (!dataGridViewRecurringOrders.Columns.Contains("Cancel"))
            {
                DataGridViewButtonColumn cancelButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Cancel",
                    HeaderText = "",
                    Text = "Cancel",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewRecurringOrders.Columns.Add(cancelButtonColumn);
            }
        }

        private void dataGridViewRecurringOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewRecurringOrders.Columns["Cancel"].Index)
            {
                var selectedRow = dataGridViewRecurringOrders.Rows[e.RowIndex];
                Guid orderId = Guid.Parse(selectedRow.Cells["LatestOrderID"].Value.ToString());
                if (MessageBox.Show("Are you sure you want to cancel this recurring order?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CancelRecurringOrder(orderId);
                    LoadRecurringImportOrders();
                }
            }
        }

        private void CancelRecurringOrder(Guid orderId)
        {
            try
            {
                var transferOrderDAO = DAOManager.Instance.TransferOrderDAO;

                TransferOrder order = transferOrderDAO.GetTransferOrderById(orderId);

                if (order == null)
                    throw new Exception("Transfer order not found.");

                if (order.Status == "RecurringStopped" || order.Status == "Canceled")
                    throw new Exception("This transfer order is already canceled or recurrence already stopped.");

                order.Status = "RecurringStopped";
                transferOrderDAO.UpdateTransferOrder(order);

                MessageBox.Show("Recurring order cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error canceling recurring order: " + ex.Message, "Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateImportOrder createImportOrder = new CreateImportOrder();
            createImportOrder.ShowDialog();
        }

        private void dataGridViewRecurringOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewRecurringOrders.Rows[e.RowIndex];
                Guid orderID = Guid.Parse(selectedRow.Cells["LatestOrderID"].Value.ToString());
                MoveToDetaisPage(orderID);
            }
        }
    }
}
