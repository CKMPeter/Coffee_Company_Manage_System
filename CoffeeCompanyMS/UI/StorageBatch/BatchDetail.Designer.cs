namespace CoffeeCompanyMS.UI.StorageBatch
{
    partial class BatchDetail
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
            this.storageNavBar1 = new CoffeeCompanyMS.UC.StorageNavBar();
            this.navBar1 = new CoffeeCompanyMS.navBar();
            this.labelSelectIngredient = new System.Windows.Forms.Label();
            this.comboBoxSelectIngredient = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // storageNavBar1
            // 
            this.storageNavBar1.Location = new System.Drawing.Point(0, 92);
            this.storageNavBar1.Name = "storageNavBar1";
            this.storageNavBar1.Size = new System.Drawing.Size(209, 532);
            this.storageNavBar1.TabIndex = 0;
            // 
            // navBar1
            // 
            this.navBar1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.navBar1.Location = new System.Drawing.Point(0, 0);
            this.navBar1.Name = "navBar1";
            this.navBar1.Size = new System.Drawing.Size(1000, 95);
            this.navBar1.TabIndex = 1;
            // 
            // labelSelectIngredient
            // 
            this.labelSelectIngredient.AutoSize = true;
            this.labelSelectIngredient.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectIngredient.Location = new System.Drawing.Point(215, 109);
            this.labelSelectIngredient.Name = "labelSelectIngredient";
            this.labelSelectIngredient.Size = new System.Drawing.Size(246, 35);
            this.labelSelectIngredient.TabIndex = 2;
            this.labelSelectIngredient.Text = "Select Ingredient:";
            // 
            // comboBoxSelectIngredient
            // 
            this.comboBoxSelectIngredient.FormattingEnabled = true;
            this.comboBoxSelectIngredient.Location = new System.Drawing.Point(467, 118);
            this.comboBoxSelectIngredient.Name = "comboBoxSelectIngredient";
            this.comboBoxSelectIngredient.Size = new System.Drawing.Size(265, 24);
            this.comboBoxSelectIngredient.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(221, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(768, 446);
            this.dataGridView1.TabIndex = 4;
            // 
            // BatchDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 618);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxSelectIngredient);
            this.Controls.Add(this.labelSelectIngredient);
            this.Controls.Add(this.navBar1);
            this.Controls.Add(this.storageNavBar1);
            this.Name = "BatchDetail";
            this.Text = "BatchDetail";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC.StorageNavBar storageNavBar1;
        private navBar navBar1;
        private System.Windows.Forms.Label labelSelectIngredient;
        private System.Windows.Forms.ComboBox comboBoxSelectIngredient;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}