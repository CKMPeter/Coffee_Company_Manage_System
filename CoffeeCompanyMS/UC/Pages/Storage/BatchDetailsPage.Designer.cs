namespace CoffeeCompanyMS.UC.Pages.Storage
{
    partial class BatchDetailsPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxIngredient = new System.Windows.Forms.ComboBox();
            this.dataGridViewBatchDetails = new System.Windows.Forms.DataGridView();
            this.locationSelector1 = new CoffeeCompanyMS.UC.LocationSelector();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatchDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Ingredient:";
            // 
            // comboBoxIngredient
            // 
            this.comboBoxIngredient.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxIngredient.FormattingEnabled = true;
            this.comboBoxIngredient.Location = new System.Drawing.Point(284, 112);
            this.comboBoxIngredient.Name = "comboBoxIngredient";
            this.comboBoxIngredient.Size = new System.Drawing.Size(263, 30);
            this.comboBoxIngredient.TabIndex = 5;
            this.comboBoxIngredient.SelectedIndexChanged += new System.EventHandler(this.comboBoxIngredient_SelectedIndexChanged);
            // 
            // dataGridViewBatchDetails
            // 
            this.dataGridViewBatchDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBatchDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewBatchDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBatchDetails.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewBatchDetails.Location = new System.Drawing.Point(18, 159);
            this.dataGridViewBatchDetails.Name = "dataGridViewBatchDetails";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBatchDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewBatchDetails.RowHeadersWidth = 51;
            this.dataGridViewBatchDetails.RowTemplate.Height = 24;
            this.dataGridViewBatchDetails.Size = new System.Drawing.Size(753, 341);
            this.dataGridViewBatchDetails.TabIndex = 6;
            // 
            // locationSelector1
            // 
            this.locationSelector1.Location = new System.Drawing.Point(18, 30);
            this.locationSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.locationSelector1.Name = "locationSelector1";
            this.locationSelector1.Size = new System.Drawing.Size(411, 63);
            this.locationSelector1.TabIndex = 7;
            // 
            // BatchDetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locationSelector1);
            this.Controls.Add(this.dataGridViewBatchDetails);
            this.Controls.Add(this.comboBoxIngredient);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BatchDetailsPage";
            this.Size = new System.Drawing.Size(791, 529);
            this.Load += new System.EventHandler(this.BatchDetailsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatchDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxIngredient;
        private System.Windows.Forms.DataGridView dataGridViewBatchDetails;
        private LocationSelector locationSelector1;
    }
}
