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
    public partial class AddExistingStock : Form
    {
        public AddExistingStock()
        {
            InitializeComponent();
        }

        private BindingSource goodsBindingSource = new BindingSource();
        private SqlDataAdapter goodsDataAdapter = new SqlDataAdapter();
        private BindingSource suppliersBindingSource = new BindingSource();
        private SqlDataAdapter supplierDataAdapter = new SqlDataAdapter();

        private void AddExistingStock_Load(object sender, EventArgs e)
        {
            populateGoodsComboBox("SELECT Goods.goodID, Goods.goodName FROM Goods INNER JOIN Stocks ON Goods.goodID = Stocks.goodID");
        }

        private void populateGoodsComboBox(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString = DatabaseSingleton.Instance.connetionString;

                // Create a new data adapter based on the specified query.
                goodsDataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(goodsDataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();

                goodsDataAdapter.Fill(table);
                goodsBindingSource.DataSource = table;
                this.goodsComboBox.DisplayMember = "goodName";
                this.goodsComboBox.ValueMember = "goodID";
                goodsComboBox.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void populateSuppliersComboBox(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString = DatabaseSingleton.Instance.connetionString;

                // Create a new data adapter based on the specified query.
                supplierDataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(supplierDataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();

                supplierDataAdapter.Fill(table);
                suppliersBindingSource.DataSource = table;
                this.supplierComboBox.DisplayMember = "supplierName";
                this.supplierComboBox.ValueMember = "supplierID";
                supplierComboBox.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void goodsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateSuppliersComboBox("SELECT supplierID, supplierName FROM Supplier WHERE (supplierID in (SELECT supplierID FROM GoodSupplier WHERE (goodID = " + goodsComboBox.SelectedValue + ")))");
        }

        private void addStockButton_Click(object sender, EventArgs e)
        {

            try
            {
                int goodID = Convert.ToInt32(goodsComboBox.SelectedValue);
                int supplierID = Convert.ToInt32(supplierComboBox.SelectedValue);
                int quantity = Convert.ToInt32(quantityNumericUpDown.Value);
                var currentTime = DateTime.Now;
                int stockID = 0;
                DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
                databaseSingleton.sql = "Update Stocks set quantity=quantity+" + quantity;
                databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.command.ExecuteNonQuery();
                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();
                //////
                databaseSingleton.sql = "SELECT stockID FROM Stocks where goodID = "+goodID;
                databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.dataReader = databaseSingleton.command.ExecuteReader();

                while (databaseSingleton.dataReader.Read())
                {
                    stockID = databaseSingleton.dataReader.GetInt32(0);
                }

                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();


                databaseSingleton.sql = "INSERT INTO Supplies (stockID , supplierID, quantity, date) VALUES ('" + stockID + "','" + supplierID + "','" + quantity + "','" + currentTime + "')";
                databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.command.ExecuteNonQuery();
                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();

                MessageBox.Show("Stock added successfully");

            }
            catch (SqlException ex) {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
