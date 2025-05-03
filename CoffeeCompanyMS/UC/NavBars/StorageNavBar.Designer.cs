namespace CoffeeCompanyMS.UC
{
    partial class StorageNavBar
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
            this.btnStorageHistory = new System.Windows.Forms.Button();
            this.pbReload = new System.Windows.Forms.PictureBox();
            this.btnBatchDetails = new System.Windows.Forms.Button();
            this.btnBatchSummary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStorageHistory
            // 
            this.btnStorageHistory.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStorageHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStorageHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageHistory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStorageHistory.Location = new System.Drawing.Point(12, 220);
            this.btnStorageHistory.Name = "btnStorageHistory";
            this.btnStorageHistory.Size = new System.Drawing.Size(183, 85);
            this.btnStorageHistory.TabIndex = 3;
            this.btnStorageHistory.Text = "Storage History";
            this.btnStorageHistory.UseVisualStyleBackColor = false;
            this.btnStorageHistory.Click += new System.EventHandler(this.btnStorageHistory_Click);
            // 
            // pbReload
            // 
            this.pbReload.Image = global::CoffeeCompanyMS.Properties.Resources.refresh;
            this.pbReload.Location = new System.Drawing.Point(145, 466);
            this.pbReload.Name = "pbReload";
            this.pbReload.Size = new System.Drawing.Size(50, 50);
            this.pbReload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReload.TabIndex = 2;
            this.pbReload.TabStop = false;
            this.pbReload.Click += new System.EventHandler(this.pbReload_Click);
            // 
            // btnBatchDetails
            // 
            this.btnBatchDetails.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBatchDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatchDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBatchDetails.Location = new System.Drawing.Point(12, 118);
            this.btnBatchDetails.Name = "btnBatchDetails";
            this.btnBatchDetails.Size = new System.Drawing.Size(183, 85);
            this.btnBatchDetails.TabIndex = 1;
            this.btnBatchDetails.Text = "Batch Details";
            this.btnBatchDetails.UseVisualStyleBackColor = false;
            this.btnBatchDetails.Click += new System.EventHandler(this.btnBatchDetails_Click);
            // 
            // btnBatchSummary
            // 
            this.btnBatchSummary.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBatchSummary.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnBatchSummary.FlatAppearance.BorderSize = 5;
            this.btnBatchSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatchSummary.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBatchSummary.Location = new System.Drawing.Point(12, 17);
            this.btnBatchSummary.Name = "btnBatchSummary";
            this.btnBatchSummary.Size = new System.Drawing.Size(183, 85);
            this.btnBatchSummary.TabIndex = 0;
            this.btnBatchSummary.Text = "Batch Summary";
            this.btnBatchSummary.UseVisualStyleBackColor = false;
            this.btnBatchSummary.Click += new System.EventHandler(this.btnBatchSummary_Click);
            // 
            // StorageNavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbReload);
            this.Controls.Add(this.btnStorageHistory);
            this.Controls.Add(this.btnBatchSummary);
            this.Controls.Add(this.btnBatchDetails);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "StorageNavBar";
            this.Size = new System.Drawing.Size(207, 529);
            this.Load += new System.EventHandler(this.StorageNavBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStorageHistory;
        private System.Windows.Forms.PictureBox pbReload;
        private System.Windows.Forms.Button btnBatchDetails;
        private System.Windows.Forms.Button btnBatchSummary;
    }
}
