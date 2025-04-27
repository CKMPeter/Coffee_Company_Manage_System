namespace CoffeeCompanyMS.UC.Pages.Export
{
    partial class ExportOrderDetailsPage
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
            this.lblDestinationName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDestinationAddress = new System.Windows.Forms.Label();
            this.dgvExportItems = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDestinationName
            // 
            this.lblDestinationName.AutoSize = true;
            this.lblDestinationName.Location = new System.Drawing.Point(54, 18);
            this.lblDestinationName.Name = "lblDestinationName";
            this.lblDestinationName.Size = new System.Drawing.Size(114, 16);
            this.lblDestinationName.TabIndex = 0;
            this.lblDestinationName.Text = "Destination Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDestinationAddress);
            this.panel1.Controls.Add(this.lblDestinationName);
            this.panel1.Location = new System.Drawing.Point(67, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 136);
            this.panel1.TabIndex = 2;
            // 
            // lblDestinationAddress
            // 
            this.lblDestinationAddress.AutoSize = true;
            this.lblDestinationAddress.Location = new System.Drawing.Point(54, 48);
            this.lblDestinationAddress.Name = "lblDestinationAddress";
            this.lblDestinationAddress.Size = new System.Drawing.Size(128, 16);
            this.lblDestinationAddress.TabIndex = 2;
            this.lblDestinationAddress.Text = "Destination Address\t";
            // 
            // dgvExportItems
            // 
            this.dgvExportItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExportItems.Location = new System.Drawing.Point(67, 179);
            this.dgvExportItems.Name = "dgvExportItems";
            this.dgvExportItems.RowHeadersWidth = 51;
            this.dgvExportItems.RowTemplate.Height = 24;
            this.dgvExportItems.Size = new System.Drawing.Size(656, 313);
            this.dgvExportItems.TabIndex = 3;
            // 
            // ExportOrderDetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvExportItems);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ExportOrderDetailsPage";
            this.Size = new System.Drawing.Size(791, 529);
            this.Load += new System.EventHandler(this.ExportOrderDetailsPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDestinationName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDestinationAddress;
        private System.Windows.Forms.DataGridView dgvExportItems;
    }
}
