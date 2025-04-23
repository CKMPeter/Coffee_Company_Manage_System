namespace CoffeeCompanyMS
{
    partial class WarehouseNavBar
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
            this.lbMode = new System.Windows.Forms.Label();
            this.pbExport = new System.Windows.Forms.PictureBox();
            this.pbLogOut = new System.Windows.Forms.PictureBox();
            this.pbImport = new System.Windows.Forms.PictureBox();
            this.pbStorage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStorage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.BackColor = System.Drawing.Color.Transparent;
            this.lbMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.Location = new System.Drawing.Point(3, 10);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(367, 76);
            this.lbMode.TabIndex = 3;
            this.lbMode.Text = "STORAGE";
            // 
            // pbExport
            // 
            this.pbExport.Image = global::CoffeeCompanyMS.Properties.Resources.cargo_truck;
            this.pbExport.Location = new System.Drawing.Point(876, 23);
            this.pbExport.Name = "pbExport";
            this.pbExport.Size = new System.Drawing.Size(50, 50);
            this.pbExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbExport.TabIndex = 4;
            this.pbExport.TabStop = false;
            this.pbExport.Click += new System.EventHandler(this.pbExport_Click);
            // 
            // pbLogOut
            // 
            this.pbLogOut.Image = global::CoffeeCompanyMS.Properties.Resources.logout;
            this.pbLogOut.Location = new System.Drawing.Point(932, 23);
            this.pbLogOut.Name = "pbLogOut";
            this.pbLogOut.Size = new System.Drawing.Size(50, 50);
            this.pbLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogOut.TabIndex = 2;
            this.pbLogOut.TabStop = false;
            this.pbLogOut.Click += new System.EventHandler(this.pbLogOut_Click);
            // 
            // pbImport
            // 
            this.pbImport.Image = global::CoffeeCompanyMS.Properties.Resources.booking;
            this.pbImport.Location = new System.Drawing.Point(820, 23);
            this.pbImport.Name = "pbImport";
            this.pbImport.Size = new System.Drawing.Size(50, 50);
            this.pbImport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImport.TabIndex = 1;
            this.pbImport.TabStop = false;
            this.pbImport.Click += new System.EventHandler(this.pbImport_Click);
            // 
            // pbStorage
            // 
            this.pbStorage.Image = global::CoffeeCompanyMS.Properties.Resources.warehouse;
            this.pbStorage.Location = new System.Drawing.Point(764, 23);
            this.pbStorage.Name = "pbStorage";
            this.pbStorage.Size = new System.Drawing.Size(50, 50);
            this.pbStorage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStorage.TabIndex = 0;
            this.pbStorage.TabStop = false;
            this.pbStorage.Click += new System.EventHandler(this.pbStorage_Click);
            // 
            // WarehouseNavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pbExport);
            this.Controls.Add(this.lbMode);
            this.Controls.Add(this.pbLogOut);
            this.Controls.Add(this.pbImport);
            this.Controls.Add(this.pbStorage);
            this.Name = "WarehouseNavBar";
            this.Size = new System.Drawing.Size(998, 91);
            this.Load += new System.EventHandler(this.navBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStorage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbStorage;
        private System.Windows.Forms.PictureBox pbImport;
        private System.Windows.Forms.PictureBox pbLogOut;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.PictureBox pbExport;
    }
}
