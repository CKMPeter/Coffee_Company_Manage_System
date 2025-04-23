namespace CoffeeCompanyMS.UI
{
    partial class Main
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
            this.subNavPanel = new System.Windows.Forms.Panel();
            this.pageAreaPanel = new System.Windows.Forms.Panel();
            this.navBarPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // subNavPanel
            // 
            this.subNavPanel.Location = new System.Drawing.Point(0, 91);
            this.subNavPanel.Margin = new System.Windows.Forms.Padding(0);
            this.subNavPanel.Name = "subNavPanel";
            this.subNavPanel.Size = new System.Drawing.Size(207, 529);
            this.subNavPanel.TabIndex = 3;
            // 
            // pageAreaPanel
            // 
            this.pageAreaPanel.Location = new System.Drawing.Point(207, 91);
            this.pageAreaPanel.Margin = new System.Windows.Forms.Padding(0);
            this.pageAreaPanel.Name = "pageAreaPanel";
            this.pageAreaPanel.Size = new System.Drawing.Size(791, 529);
            this.pageAreaPanel.TabIndex = 4;
            // 
            // navBarPanel
            // 
            this.navBarPanel.Location = new System.Drawing.Point(0, 0);
            this.navBarPanel.Margin = new System.Windows.Forms.Padding(0);
            this.navBarPanel.Name = "navBarPanel";
            this.navBarPanel.Size = new System.Drawing.Size(998, 91);
            this.navBarPanel.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 621);
            this.Controls.Add(this.navBarPanel);
            this.Controls.Add(this.pageAreaPanel);
            this.Controls.Add(this.subNavPanel);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel subNavPanel;
        private System.Windows.Forms.Panel pageAreaPanel;
        private System.Windows.Forms.Panel navBarPanel;
    }
}