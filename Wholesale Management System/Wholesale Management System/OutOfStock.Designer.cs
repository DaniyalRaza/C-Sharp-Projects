namespace Wholesale_Management_System
{
    partial class OutOfStock
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
            this.outOfStocksGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.outOfStocksGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // outOfStocksGridView
            // 
            this.outOfStocksGridView.AllowUserToAddRows = false;
            this.outOfStocksGridView.AllowUserToDeleteRows = false;
            this.outOfStocksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outOfStocksGridView.Location = new System.Drawing.Point(12, 11);
            this.outOfStocksGridView.Name = "outOfStocksGridView";
            this.outOfStocksGridView.ReadOnly = true;
            this.outOfStocksGridView.Size = new System.Drawing.Size(360, 338);
            this.outOfStocksGridView.TabIndex = 0;
            // 
            // OutOfStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.outOfStocksGridView);
            this.Name = "OutOfStock";
            this.Text = "OutOfStock";
            this.Load += new System.EventHandler(this.OutOfStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outOfStocksGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView outOfStocksGridView;
    }
}