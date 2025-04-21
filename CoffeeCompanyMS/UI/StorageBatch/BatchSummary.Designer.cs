namespace CoffeeCompanyMS.UI.StorageBatch
{
    partial class BatchSummary
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.storageNavBar1 = new CoffeeCompanyMS.UC.StorageNavBar();
            this.navBar1 = new CoffeeCompanyMS.navBar();
            this.locationSelector1 = new CoffeeCompanyMS.UC.LocationSelector();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(221, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(766, 437);
            this.dataGridView1.TabIndex = 4;
            // 
            // storageNavBar1
            // 
            this.storageNavBar1.Location = new System.Drawing.Point(0, 92);
            this.storageNavBar1.Name = "storageNavBar1";
            this.storageNavBar1.Size = new System.Drawing.Size(209, 532);
            this.storageNavBar1.TabIndex = 1;
            // 
            // navBar1
            // 
            this.navBar1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.navBar1.Location = new System.Drawing.Point(0, 0);
            this.navBar1.Name = "navBar1";
            this.navBar1.Size = new System.Drawing.Size(1000, 95);
            this.navBar1.TabIndex = 0;
            // 
            // locationSelector1
            // 
            this.locationSelector1.Location = new System.Drawing.Point(221, 101);
            this.locationSelector1.Name = "locationSelector1";
            this.locationSelector1.Size = new System.Drawing.Size(766, 63);
            this.locationSelector1.TabIndex = 5;
            // 
            // BatchSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 619);
            this.Controls.Add(this.locationSelector1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.storageNavBar1);
            this.Controls.Add(this.navBar1);
            this.Name = "BatchSummary";
            this.Text = "BatchSummary";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private navBar navBar1;
        private UC.StorageNavBar storageNavBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private UC.LocationSelector locationSelector1;
    }
}