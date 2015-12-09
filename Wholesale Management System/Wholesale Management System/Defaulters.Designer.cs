namespace Wholesale_Management_System
{
    partial class Defaulters
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
            this.defaultersGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.defaultersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultersGridView
            // 
            this.defaultersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.defaultersGridView.Location = new System.Drawing.Point(13, 13);
            this.defaultersGridView.Name = "defaultersGridView";
            this.defaultersGridView.Size = new System.Drawing.Size(453, 150);
            this.defaultersGridView.TabIndex = 0;
            // 
            // Defaulters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 185);
            this.Controls.Add(this.defaultersGridView);
            this.Name = "Defaulters";
            this.Text = "Defaulters";
            this.Load += new System.EventHandler(this.Defaulters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.defaultersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView defaultersGridView;
    }
}