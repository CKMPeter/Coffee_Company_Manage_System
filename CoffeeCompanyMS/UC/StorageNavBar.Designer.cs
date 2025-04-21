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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbReload = new System.Windows.Forms.PictureBox();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pbReload);
            this.panel1.Controls.Add(this.btnHistory);
            this.panel1.Controls.Add(this.btnStock);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 529);
            this.panel1.TabIndex = 3;
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
            this.btnHistory.Text = "Batch Details";
            this.btnHistory.UseVisualStyleBackColor = false;
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStock.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnStock.FlatAppearance.BorderSize = 5;
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStock.Location = new System.Drawing.Point(12, 14);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(183, 75);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "Batch Summary";
            this.btnStock.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(12, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 75);
            this.button1.TabIndex = 3;
            this.button1.Text = "Storage History";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // StorageNavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "StorageNavBar";
            this.Size = new System.Drawing.Size(209, 532);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbReload;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnStock;
    }
}
