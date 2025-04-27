namespace CoffeeCompanyMS.UC.Pages.Export
{
    partial class ExportOrdersPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.locationSelector1 = new CoffeeCompanyMS.UC.LocationSelector();
            this.dataGridViewExportOrder = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // locationSelector1
            // 
            this.locationSelector1.Location = new System.Drawing.Point(106, 59);
            this.locationSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.locationSelector1.Name = "locationSelector1";
            this.locationSelector1.Size = new System.Drawing.Size(411, 63);
            this.locationSelector1.TabIndex = 2;
            // 
            // dataGridViewExportOrder
            // 
            this.dataGridViewExportOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExportOrder.Location = new System.Drawing.Point(67, 125);
            this.dataGridViewExportOrder.Name = "dataGridViewExportOrder";
            this.dataGridViewExportOrder.RowHeadersWidth = 51;
            this.dataGridViewExportOrder.RowTemplate.Height = 24;
            this.dataGridViewExportOrder.Size = new System.Drawing.Size(650, 353);
            this.dataGridViewExportOrder.TabIndex = 3;
            this.dataGridViewExportOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExportOrder_CellDoubleClick);
            this.dataGridViewExportOrder.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExportOrder_CellValueChanged);
            // 
            // ExportOrdersPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewExportOrder);
            this.Controls.Add(this.locationSelector1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ExportOrdersPage";
            this.Size = new System.Drawing.Size(791, 529);
            this.Load += new System.EventHandler(this.ExportOrdersPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LocationSelector locationSelector1;
        private System.Windows.Forms.DataGridView dataGridViewExportOrder;
    }
}
