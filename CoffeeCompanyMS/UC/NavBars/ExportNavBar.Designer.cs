namespace CoffeeCompanyMS.UC
{
    partial class ExportNavBar
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
            this.pbReload = new System.Windows.Forms.PictureBox();
            this.btnRecurringOrders = new System.Windows.Forms.Button();
            this.btnExportOrders = new System.Windows.Forms.Button();
            this.btnOrderDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).BeginInit();
            this.SuspendLayout();
            // 
            // pbReload
            // 
            this.pbReload.Image = global::CoffeeCompanyMS.Properties.Resources.refresh;
            this.pbReload.Location = new System.Drawing.Point(145, 464);
            this.pbReload.Name = "pbReload";
            this.pbReload.Size = new System.Drawing.Size(50, 50);
            this.pbReload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReload.TabIndex = 6;
            this.pbReload.TabStop = false;
            this.pbReload.Click += new System.EventHandler(this.pbReload_Click);
            // 
            // btnRecurringOrders
            // 
            this.btnRecurringOrders.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRecurringOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecurringOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecurringOrders.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRecurringOrders.Location = new System.Drawing.Point(12, 218);
            this.btnRecurringOrders.Name = "btnRecurringOrders";
            this.btnRecurringOrders.Size = new System.Drawing.Size(183, 85);
            this.btnRecurringOrders.TabIndex = 7;
            this.btnRecurringOrders.Text = "Recurring Orders";
            this.btnRecurringOrders.UseVisualStyleBackColor = false;
            this.btnRecurringOrders.Click += new System.EventHandler(this.btnRecurringOrders_Click);
            // 
            // btnExportOrders
            // 
            this.btnExportOrders.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportOrders.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnExportOrders.FlatAppearance.BorderSize = 5;
            this.btnExportOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportOrders.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExportOrders.Location = new System.Drawing.Point(12, 15);
            this.btnExportOrders.Name = "btnExportOrders";
            this.btnExportOrders.Size = new System.Drawing.Size(183, 85);
            this.btnExportOrders.TabIndex = 4;
            this.btnExportOrders.Text = "Export Orders";
            this.btnExportOrders.UseVisualStyleBackColor = false;
            this.btnExportOrders.Click += new System.EventHandler(this.btnExportOrders_Click);
            // 
            // btnOrderDetails
            // 
            this.btnOrderDetails.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOrderDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOrderDetails.Location = new System.Drawing.Point(12, 116);
            this.btnOrderDetails.Name = "btnOrderDetails";
            this.btnOrderDetails.Size = new System.Drawing.Size(183, 85);
            this.btnOrderDetails.TabIndex = 5;
            this.btnOrderDetails.Text = "Order Details";
            this.btnOrderDetails.UseVisualStyleBackColor = false;
            this.btnOrderDetails.Click += new System.EventHandler(this.btnOrderDetails_Click);
            // 
            // ExportNavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pbReload);
            this.Controls.Add(this.btnRecurringOrders);
            this.Controls.Add(this.btnExportOrders);
            this.Controls.Add(this.btnOrderDetails);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ExportNavBar";
            this.Size = new System.Drawing.Size(207, 529);
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbReload;
        private System.Windows.Forms.Button btnRecurringOrders;
        private System.Windows.Forms.Button btnExportOrders;
        private System.Windows.Forms.Button btnOrderDetails;
    }
}
