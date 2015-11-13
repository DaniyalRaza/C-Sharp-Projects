using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Wholesale_Management_System
{
    public partial class SalesRecord : Form
    {
        public SalesRecord()
        {
            InitializeComponent();
        }

        private BindingSource salesBindingSource = new BindingSource();
        private SqlDataAdapter salesDataAdapter = new SqlDataAdapter();

        private void SalesRecord_Load(object sender, EventArgs e)
        {
            salesDataGridView.DataSource = salesBindingSource;
            GetData("Select saleID,customerName,totalBill,paymentMade,saleDate from Sales inner join Customers on Sales.customerID = Customers.customerID");
        }

        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString = DatabaseSingleton.Instance.connetionString;

                // Create a new data adapter based on the specified query.
                salesDataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(salesDataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                salesDataAdapter.Fill(table);
                salesBindingSource.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                salesDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            int saleID = Convert.ToInt32(salesDataGridView.Rows[e.RowIndex].Cells[0].Value);
            if (e.RowIndex != -1)
            {
                GoodsBoughtWindow goodBoughtWindow = new GoodsBoughtWindow(saleID);
                goodBoughtWindow.Show();
            }
        }

        



    }
}
