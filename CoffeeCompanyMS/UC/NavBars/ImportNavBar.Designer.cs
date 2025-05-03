namespace CoffeeCompanyMS.UC
{
    partial class ImportNavBar
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
            this.btnImportOrders = new System.Windows.Forms.Button();
            this.btnOrderDetails = new System.Windows.Forms.Button();
            this.btnRecurringOrders = new System.Windows.Forms.Button();
            this.pbReload = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportOrders
            // 
            this.btnImportOrders.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImportOrders.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnImportOrders.FlatAppearance.BorderSize = 5;
            this.btnImportOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportOrders.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImportOrders.Location = new System.Drawing.Point(12, 17);
            this.btnImportOrders.Name = "btnImportOrders";
            this.btnImportOrders.Size = new System.Drawing.Size(183, 85);
            this.btnImportOrders.TabIndex = 1;
            this.btnImportOrders.Text = "Import Orders";
            this.btnImportOrders.UseVisualStyleBackColor = false;
            this.btnImportOrders.Click += new System.EventHandler(this.btnImportOrders_Click);
            // 
            // btnOrderDetails
            // 
            this.btnOrderDetails.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOrderDetails.Enabled = false;
            this.btnOrderDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOrderDetails.Location = new System.Drawing.Point(12, 230);
            this.btnOrderDetails.Name = "btnOrderDetails";
            this.btnOrderDetails.Size = new System.Drawing.Size(183, 85);
            this.btnOrderDetails.TabIndex = 2;
            this.btnOrderDetails.Text = "Order Details";
            this.btnOrderDetails.UseVisualStyleBackColor = false;
            // 
            // btnRecurringOrders
            // 
            this.btnRecurringOrders.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRecurringOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecurringOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecurringOrders.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRecurringOrders.Location = new System.Drawing.Point(12, 122);
            this.btnRecurringOrders.Name = "btnRecurringOrders";
            this.btnRecurringOrders.Size = new System.Drawing.Size(183, 85);
            this.btnRecurringOrders.TabIndex = 4;
            this.btnRecurringOrders.Text = "Recurring Orders";
            this.btnRecurringOrders.UseVisualStyleBackColor = false;
            this.btnRecurringOrders.Click += new System.EventHandler(this.btnRecurringOrders_Click);
            // 
            // pbReload
            // 
            this.pbReload.Image = global::CoffeeCompanyMS.Properties.Resources.refresh;
            this.pbReload.Location = new System.Drawing.Point(145, 466);
            this.pbReload.Name = "pbReload";
            this.pbReload.Size = new System.Drawing.Size(50, 50);
            this.pbReload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReload.TabIndex = 5;
            this.pbReload.TabStop = false;
            this.pbReload.Click += new System.EventHandler(this.pbReload_Click);
            // 
            // ImportNavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pbReload);
            this.Controls.Add(this.btnRecurringOrders);
            this.Controls.Add(this.btnOrderDetails);
            this.Controls.Add(this.btnImportOrders);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ImportNavBar";
            this.Size = new System.Drawing.Size(207, 529);
            this.Load += new System.EventHandler(this.ImportNavBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportOrders;
        private System.Windows.Forms.Button btnOrderDetails;
        private System.Windows.Forms.Button btnRecurringOrders;
        private System.Windows.Forms.PictureBox pbReload;
    }
}
