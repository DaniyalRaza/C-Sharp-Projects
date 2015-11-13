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

        
    }
}
