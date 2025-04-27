namespace CoffeeCompanyMS.UC.Pages.Storage
{
    partial class StorageHistoryPage
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
            this.dataGridViewStorageHistory = new System.Windows.Forms.DataGridView();
            this.locationSelector1 = new CoffeeCompanyMS.UC.LocationSelector();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStorageHistory
            // 
            this.dataGridViewStorageHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStorageHistory.Location = new System.Drawing.Point(17, 62);
            this.dataGridViewStorageHistory.Name = "dataGridViewStorageHistory";
            this.dataGridViewStorageHistory.RowHeadersWidth = 51;
            this.dataGridViewStorageHistory.RowTemplate.Height = 24;
            this.dataGridViewStorageHistory.Size = new System.Drawing.Size(755, 453);
            this.dataGridViewStorageHistory.TabIndex = 1;
            // 
            // locationSelector1
            // 
            this.locationSelector1.Location = new System.Drawing.Point(0, 0);
            this.locationSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.locationSelector1.Name = "locationSelector1";
            this.locationSelector1.Size = new System.Drawing.Size(411, 63);
            this.locationSelector1.TabIndex = 0;
            // 
            // StorageHistoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewStorageHistory);
            this.Controls.Add(this.locationSelector1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "StorageHistoryPage";
            this.Size = new System.Drawing.Size(791, 529);
            this.Load += new System.EventHandler(this.StorageHistoryPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LocationSelector locationSelector1;
        private System.Windows.Forms.DataGridView dataGridViewStorageHistory;
    }
}
