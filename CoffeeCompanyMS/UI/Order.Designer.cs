namespace CoffeeCompanyMS.UI
{
    partial class Order
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
            this.navBar1 = new CoffeeCompanyMS.navBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbReload = new System.Windows.Forms.PictureBox();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.dgvStrorage = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrorage)).BeginInit();
            this.SuspendLayout();
            // 
            // navBar1
            // 
            this.navBar1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.navBar1.Location = new System.Drawing.Point(-9, 0);
            this.navBar1.Name = "navBar1";
            this.navBar1.Size = new System.Drawing.Size(998, 91);
            this.navBar1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.pbReload);
            this.panel1.Controls.Add(this.btnHistory);
            this.panel1.Controls.Add(this.btnStock);
            this.panel1.Location = new System.Drawing.Point(19, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 529);
            this.panel1.TabIndex = 4;
            // 
            // pbReload
            // 
            this.pbReload.Image = global::CoffeeCompanyMS.Properties.Resources.refresh;
            this.pbReload.Location = new System.Drawing.Point(154, 476);
            this.pbReload.Name = "pbReload";
            this.pbReload.Size = new System.Drawing.Size(50, 50);
            this.pbReload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReload.TabIndex = 2;
            this.pbReload.TabStop = false;
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHistory.Location = new System.Drawing.Point(12, 95);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(183, 75);
            this.btnHistory.TabIndex = 1;
            this.btnHistory.Text = "HISTORY";
            this.btnHistory.UseVisualStyleBackColor = false;
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStock.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnStock.FlatAppearance.BorderSize = 5;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStock.Location = new System.Drawing.Point(12, 14);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(183, 75);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "STOCK";
            this.btnStock.UseVisualStyleBackColor = false;
            // 
            // dgvStrorage
            // 
            this.dgvStrorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStrorage.Location = new System.Drawing.Point(242, 97);
            this.dgvStrorage.Name = "dgvStrorage";
            this.dgvStrorage.RowHeadersWidth = 51;
            this.dgvStrorage.RowTemplate.Height = 24;
            this.dgvStrorage.Size = new System.Drawing.Size(728, 529);
            this.dgvStrorage.TabIndex = 3;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvStrorage);
            this.Controls.Add(this.navBar1);
            this.Name = "Order";
            this.Text = "Order";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrorage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private navBar navBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbReload;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.DataGridView dgvStrorage;
    }
}