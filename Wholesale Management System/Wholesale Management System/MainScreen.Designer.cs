namespace Wholesale_Management_System
{
    partial class MainScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToExistingStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outOfStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stocksListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGoodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.stocksToolStripMenuItem,
            this.suppliersToolStripMenuItem,
            this.customersToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.goodsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(399, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // qToolStripMenuItem
            // 
            this.qToolStripMenuItem.Name = "qToolStripMenuItem";
            this.qToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.qToolStripMenuItem.Text = "Quit";
            this.qToolStripMenuItem.Click += new System.EventHandler(this.qToolStripMenuItem_Click);
            // 
            // stocksToolStripMenuItem
            // 
            this.stocksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStockToolStripMenuItem,
            this.outOfStockToolStripMenuItem,
            this.stocksListToolStripMenuItem});
            this.stocksToolStripMenuItem.Name = "stocksToolStripMenuItem";
            this.stocksToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.stocksToolStripMenuItem.Text = "Stocks";
            // 
            // addStockToolStripMenuItem
            // 
            this.addStockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newStockToolStripMenuItem,
            this.addToExistingStockToolStripMenuItem});
            this.addStockToolStripMenuItem.Name = "addStockToolStripMenuItem";
            this.addStockToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addStockToolStripMenuItem.Text = "Add Stock";
            // 
            // newStockToolStripMenuItem
            // 
            this.newStockToolStripMenuItem.Name = "newStockToolStripMenuItem";
            this.newStockToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newStockToolStripMenuItem.Text = "New Stock";
            this.newStockToolStripMenuItem.Click += new System.EventHandler(this.newStockToolStripMenuItem_Click);
            // 
            // addToExistingStockToolStripMenuItem
            // 
            this.addToExistingStockToolStripMenuItem.Name = "addToExistingStockToolStripMenuItem";
            this.addToExistingStockToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.addToExistingStockToolStripMenuItem.Text = "Add to Existing Stock";
            this.addToExistingStockToolStripMenuItem.Click += new System.EventHandler(this.addToExistingStockToolStripMenuItem_Click);
            // 
            // outOfStockToolStripMenuItem
            // 
            this.outOfStockToolStripMenuItem.Name = "outOfStockToolStripMenuItem";
            this.outOfStockToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.outOfStockToolStripMenuItem.Text = "Out of Stock";
            this.outOfStockToolStripMenuItem.Click += new System.EventHandler(this.outOfStockToolStripMenuItem_Click);
            // 
            // stocksListToolStripMenuItem
            // 
            this.stocksListToolStripMenuItem.Name = "stocksListToolStripMenuItem";
            this.stocksListToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.stocksListToolStripMenuItem.Text = "Stocks List";
            this.stocksListToolStripMenuItem.Click += new System.EventHandler(this.stocksListToolStripMenuItem_Click);
            // 
            // suppliersToolStripMenuItem
            // 
            this.suppliersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suppliersListToolStripMenuItem,
            this.addSupplierToolStripMenuItem});
            this.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.suppliersToolStripMenuItem.Text = "Suppliers";
            // 
            // suppliersListToolStripMenuItem
            // 
            this.suppliersListToolStripMenuItem.Name = "suppliersListToolStripMenuItem";
            this.suppliersListToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.suppliersListToolStripMenuItem.Text = "Suppliers List";
            this.suppliersListToolStripMenuItem.Click += new System.EventHandler(this.suppliersListToolStripMenuItem_Click);
            // 
            // addSupplierToolStripMenuItem
            // 
            this.addSupplierToolStripMenuItem.Name = "addSupplierToolStripMenuItem";
            this.addSupplierToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addSupplierToolStripMenuItem.Text = "Add Supplier";
            this.addSupplierToolStripMenuItem.Click += new System.EventHandler(this.addSupplierToolStripMenuItem_Click);
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customersListToolStripMenuItem,
            this.addCustomerToolStripMenuItem,
            this.defaultersToolStripMenuItem,
            this.updateCustomerToolStripMenuItem});
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.customersToolStripMenuItem.Text = "Customers";
            // 
            // customersListToolStripMenuItem
            // 
            this.customersListToolStripMenuItem.Name = "customersListToolStripMenuItem";
            this.customersListToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.customersListToolStripMenuItem.Text = "Customers List";
            this.customersListToolStripMenuItem.Click += new System.EventHandler(this.customersListToolStripMenuItem_Click);
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addCustomerToolStripMenuItem.Text = "Add Customer";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click);
            // 
            // defaultersToolStripMenuItem
            // 
            this.defaultersToolStripMenuItem.Name = "defaultersToolStripMenuItem";
            this.defaultersToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.defaultersToolStripMenuItem.Text = "Defaulters";
            this.defaultersToolStripMenuItem.Click += new System.EventHandler(this.defaultersToolStripMenuItem_Click);
            // 
            // updateCustomerToolStripMenuItem
            // 
            this.updateCustomerToolStripMenuItem.Name = "updateCustomerToolStripMenuItem";
            this.updateCustomerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.updateCustomerToolStripMenuItem.Text = "Update Customer";
            this.updateCustomerToolStripMenuItem.Click += new System.EventHandler(this.updateCustomerToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSaleToolStripMenuItem,
            this.salesRecordToolStripMenuItem,
            this.salesReportToolStripMenuItem,
            this.clearPaymentsToolStripMenuItem});
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // addSaleToolStripMenuItem
            // 
            this.addSaleToolStripMenuItem.Name = "addSaleToolStripMenuItem";
            this.addSaleToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addSaleToolStripMenuItem.Text = "Add Sale";
            this.addSaleToolStripMenuItem.Click += new System.EventHandler(this.addSaleToolStripMenuItem_Click);
            // 
            // salesRecordToolStripMenuItem
            // 
            this.salesRecordToolStripMenuItem.Name = "salesRecordToolStripMenuItem";
            this.salesRecordToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.salesRecordToolStripMenuItem.Text = "Sales Record";
            this.salesRecordToolStripMenuItem.Click += new System.EventHandler(this.salesRecordToolStripMenuItem_Click);
            // 
            // salesReportToolStripMenuItem
            // 
            this.salesReportToolStripMenuItem.Name = "salesReportToolStripMenuItem";
            this.salesReportToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.salesReportToolStripMenuItem.Text = "Sales Report";
            this.salesReportToolStripMenuItem.Click += new System.EventHandler(this.salesReportToolStripMenuItem_Click);
            // 
            // goodsToolStripMenuItem
            // 
            this.goodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGoodsToolStripMenuItem,
            this.goodsListToolStripMenuItem});
            this.goodsToolStripMenuItem.Name = "goodsToolStripMenuItem";
            this.goodsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.goodsToolStripMenuItem.Text = "Goods";
            // 
            // addGoodsToolStripMenuItem
            // 
            this.addGoodsToolStripMenuItem.Name = "addGoodsToolStripMenuItem";
            this.addGoodsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addGoodsToolStripMenuItem.Text = "Add Goods";
            this.addGoodsToolStripMenuItem.Click += new System.EventHandler(this.addGoodsToolStripMenuItem_Click);
            // 
            // goodsListToolStripMenuItem
            // 
            this.goodsListToolStripMenuItem.Name = "goodsListToolStripMenuItem";
            this.goodsListToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.goodsListToolStripMenuItem.Text = "Goods List";
            this.goodsListToolStripMenuItem.Click += new System.EventHandler(this.goodsListToolStripMenuItem_Click);
            // 
            // clearPaymentsToolStripMenuItem
            // 
            this.clearPaymentsToolStripMenuItem.Name = "clearPaymentsToolStripMenuItem";
            this.clearPaymentsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.clearPaymentsToolStripMenuItem.Text = "Clear Payments";
            this.clearPaymentsToolStripMenuItem.Click += new System.EventHandler(this.clearPaymentsToolStripMenuItem_Click_1);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToExistingStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outOfStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGoodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stocksListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearPaymentsToolStripMenuItem;
    }
}