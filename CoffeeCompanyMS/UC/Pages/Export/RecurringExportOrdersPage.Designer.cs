namespace CoffeeCompanyMS.UC.Pages.Export
{
    partial class RecurringExportOrdersPage
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.dataGridViewRecurring = new System.Windows.Forms.DataGridView();
            this.locationSelector1 = new CoffeeCompanyMS.UC.LocationSelector();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecurring)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(290, 80);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(138, 49);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dataGridViewRecurring
            // 
            this.dataGridViewRecurring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecurring.Location = new System.Drawing.Point(38, 135);
            this.dataGridViewRecurring.Name = "dataGridViewRecurring";
            this.dataGridViewRecurring.RowHeadersWidth = 51;
            this.dataGridViewRecurring.RowTemplate.Height = 24;
            this.dataGridViewRecurring.Size = new System.Drawing.Size(672, 374);
            this.dataGridViewRecurring.TabIndex = 2;
            // 
            // locationSelector1
            // 
            this.locationSelector1.Location = new System.Drawing.Point(118, 14);
            this.locationSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.locationSelector1.Name = "locationSelector1";
            this.locationSelector1.Size = new System.Drawing.Size(411, 63);
            this.locationSelector1.TabIndex = 3;
            // 
            // RecurringExportOrdersPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locationSelector1);
            this.Controls.Add(this.dataGridViewRecurring);
            this.Controls.Add(this.btnCreate);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RecurringExportOrdersPage";
            this.Size = new System.Drawing.Size(791, 529);
            this.Load += new System.EventHandler(this.RecurringExportOrdersPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecurring)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dataGridViewRecurring;
        private LocationSelector locationSelector1;
    }
}
