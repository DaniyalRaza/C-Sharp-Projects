using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wholesale_Management_System
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            
        }

        private void newStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewStock addNewStock = new AddNewStock();
            addNewStock.Show();
        }

        private void addToExistingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddExistingStock addExistingStock = new AddExistingStock();
            addExistingStock.Show();
        }

        private void outOfStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutOfStock outofStock = new OutOfStock();
            outofStock.Show();
        }

        private void customersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersScreen customersScreen = new CustomersScreen();
            customersScreen.Show();
        }

        private void suppliersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            suppliers.Show();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
        }

        private void salesRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesRecord salesRecord = new SalesRecord();
            salesRecord.Show();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReport salesReport = new SalesReport();
            salesReport.Show();
        }

        private void qToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

           
            
        }

        private void addSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSale addSale = new AddSale();
            addSale.Show();
        }

        private void defaultersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Defaulters defaulters = new Defaulters();
            defaulters.Show();
        }

        private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer();
            updateCustomer.Show();
        }

        private void addGoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGoods addGoods = new AddGoods();
            addGoods.Show();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplier addSupplier = new AddSupplier();
            addSupplier.Show();
        }

        private void goodsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Goods_List goodsList = new Goods_List();
            goodsList.Show();
        }

        private void stocksListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StocksScreen stocksScreen = new StocksScreen();
            stocksScreen.Show();
        }

        

        private void clearPaymentsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClearPayment clearPayment = new ClearPayment();
            clearPayment.Show();
        }

        

        
    }
}
