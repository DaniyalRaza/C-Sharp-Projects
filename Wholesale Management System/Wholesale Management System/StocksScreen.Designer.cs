namespace Wholesale_Management_System
{
    partial class StocksScreen
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
            this.stocksGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.stocksGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // stocksGridView
            // 
            this.stocksGridView.AllowUserToAddRows = false;
            this.stocksGridView.AllowUserToDeleteRows = false;
            this.stocksGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.stocksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stocksGridView.Location = new System.Drawing.Point(12, 28);
            this.stocksGridView.Name = "stocksGridView";
            this.stocksGridView.ReadOnly = true;
            this.stocksGridView.Size = new System.Drawing.Size(560, 324);
            this.stocksGridView.TabIndex = 1;
            // 
            // StocksScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.stocksGridView);
            this.Name = "StocksScreen";
            this.Text = "Stocks Screen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stocksGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView stocksGridView;
    }
}