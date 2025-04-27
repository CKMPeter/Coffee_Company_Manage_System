namespace CoffeeCompanyMS.UC.Pages.Storage
{
    partial class BatchSummaryPage
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
            this.dataGridViewBatchSummary = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatchSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // locationSelector1
            // 
            this.locationSelector1.Location = new System.Drawing.Point(20, 17);
            this.locationSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.locationSelector1.Name = "locationSelector1";
            this.locationSelector1.Size = new System.Drawing.Size(411, 63);
            this.locationSelector1.TabIndex = 5;
            // 
            // dataGridViewBatchSummary
            // 
            this.dataGridViewBatchSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBatchSummary.Location = new System.Drawing.Point(20, 83);
            this.dataGridViewBatchSummary.Name = "dataGridViewBatchSummary";
            this.dataGridViewBatchSummary.RowHeadersWidth = 51;
            this.dataGridViewBatchSummary.RowTemplate.Height = 24;
            this.dataGridViewBatchSummary.Size = new System.Drawing.Size(756, 419);
            this.dataGridViewBatchSummary.TabIndex = 6;
            this.dataGridViewBatchSummary.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBatchSummary_CellDoubleClick);
            // 
            // BatchSummaryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewBatchSummary);
            this.Controls.Add(this.locationSelector1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BatchSummaryPage";
            this.Size = new System.Drawing.Size(791, 529);
            this.Load += new System.EventHandler(this.BatchSummaryPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatchSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private LocationSelector locationSelector1;
        private System.Windows.Forms.DataGridView dataGridViewBatchSummary;
    }
}
