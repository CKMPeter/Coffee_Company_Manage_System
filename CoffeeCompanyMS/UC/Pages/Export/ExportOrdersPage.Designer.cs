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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.locationSelector1 = new CoffeeCompanyMS.UC.LocationSelector();
            this.dataGridViewExportOrder = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // locationSelector1
            // 
            this.locationSelector1.Location = new System.Drawing.Point(74, 28);
            this.locationSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.locationSelector1.Name = "locationSelector1";
            this.locationSelector1.Size = new System.Drawing.Size(411, 63);
            this.locationSelector1.TabIndex = 2;
            // 
            // dataGridViewExportOrder
            // 
            this.dataGridViewExportOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExportOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewExportOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewExportOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewExportOrder.Location = new System.Drawing.Point(41, 110);
            this.dataGridViewExportOrder.Name = "dataGridViewExportOrder";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExportOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewExportOrder.RowHeadersWidth = 51;
            this.dataGridViewExportOrder.RowTemplate.Height = 24;
            this.dataGridViewExportOrder.Size = new System.Drawing.Size(704, 384);
            this.dataGridViewExportOrder.TabIndex = 3;
            this.dataGridViewExportOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExportOrder_CellDoubleClick);
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
