namespace CoffeeCompanyMS.UC.Pages.Import
{
    partial class RecurringImportOrdersPage
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
            this.dataGridViewRecurringOrders = new System.Windows.Forms.DataGridView();
            this.locationSelector1 = new CoffeeCompanyMS.UC.LocationSelector();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecurringOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(325, 115);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(138, 49);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dataGridViewRecurringOrders
            // 
            this.dataGridViewRecurringOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecurringOrders.Location = new System.Drawing.Point(43, 199);
            this.dataGridViewRecurringOrders.Name = "dataGridViewRecurringOrders";
            this.dataGridViewRecurringOrders.RowHeadersWidth = 51;
            this.dataGridViewRecurringOrders.RowTemplate.Height = 24;
            this.dataGridViewRecurringOrders.Size = new System.Drawing.Size(712, 304);
            this.dataGridViewRecurringOrders.TabIndex = 4;
            // 
            // locationSelector1
            // 
            this.locationSelector1.Location = new System.Drawing.Point(207, 20);
            this.locationSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.locationSelector1.Name = "locationSelector1";
            this.locationSelector1.Size = new System.Drawing.Size(411, 63);
            this.locationSelector1.TabIndex = 5;
            // 
            // RecurringImportOrdersPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locationSelector1);
            this.Controls.Add(this.dataGridViewRecurringOrders);
            this.Controls.Add(this.btnCreate);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RecurringImportOrdersPage";
            this.Size = new System.Drawing.Size(791, 529);
            this.Load += new System.EventHandler(this.RecurringImportOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecurringOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dataGridViewRecurringOrders;
        private LocationSelector locationSelector1;
    }
}
