namespace CoffeeCompanyMS.UC
{
    partial class InformationNavBar
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
            this.btnLocations = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnIngredients = new System.Windows.Forms.Button();
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
            this.pbReload.TabIndex = 10;
            this.pbReload.TabStop = false;
            this.pbReload.Click += new System.EventHandler(this.pbReload_Click);
            // 
            // btnLocations
            // 
            this.btnLocations.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLocations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocations.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLocations.Location = new System.Drawing.Point(12, 218);
            this.btnLocations.Name = "btnLocations";
            this.btnLocations.Size = new System.Drawing.Size(183, 85);
            this.btnLocations.TabIndex = 11;
            this.btnLocations.Text = "Locations";
            this.btnLocations.UseVisualStyleBackColor = false;
            this.btnLocations.Click += new System.EventHandler(this.btnLocations_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSuppliers.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnSuppliers.FlatAppearance.BorderSize = 5;
            this.btnSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuppliers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSuppliers.Location = new System.Drawing.Point(12, 15);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(183, 85);
            this.btnSuppliers.TabIndex = 8;
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.UseVisualStyleBackColor = false;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnIngredients
            // 
            this.btnIngredients.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngredients.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIngredients.Location = new System.Drawing.Point(12, 116);
            this.btnIngredients.Name = "btnIngredients";
            this.btnIngredients.Size = new System.Drawing.Size(183, 85);
            this.btnIngredients.TabIndex = 9;
            this.btnIngredients.Text = "Ingredients";
            this.btnIngredients.UseVisualStyleBackColor = false;
            this.btnIngredients.Click += new System.EventHandler(this.btnIngredients_Click);
            // 
            // InformationNavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbReload);
            this.Controls.Add(this.btnLocations);
            this.Controls.Add(this.btnSuppliers);
            this.Controls.Add(this.btnIngredients);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InformationNavBar";
            this.Size = new System.Drawing.Size(207, 529);
            this.Load += new System.EventHandler(this.InformationNavBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbReload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbReload;
        private System.Windows.Forms.Button btnLocations;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnIngredients;
    }
}
