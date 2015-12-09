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
    public partial class AddSupplier : Form
    {
        public AddSupplier()
        {
            InitializeComponent();
        }

        private BindingSource goodsBindingSource = new BindingSource();
        private SqlDataAdapter goodsDataAdapter = new SqlDataAdapter();

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            populateGoodsCheckList("Select goodID,goodName from Goods");
        }

        private void populateGoodsCheckList(string selectCommand)
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

                ((ListBox)this.goodsCheckedListBox).DataSource = table;
                ((ListBox)this.goodsCheckedListBox).DisplayMember = "goodName";
                ((ListBox)this.goodsCheckedListBox).ValueMember = "goodID";

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "" || phoneTextBox.Text == "" || addressTextBox.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else {
                try
                {
                    int enteredSupplierID = 0;

                    string supplierName = nameTextBox.Text;
                    string phone = phoneTextBox.Text;
                    string address = addressTextBox.Text;
                    DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
                    databaseSingleton.sql = "INSERT INTO Supplier (supplierName , phone,address) VALUES ('" + supplierName + "','" + phone + "','"+address+"')";
                    databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                    databaseSingleton.connection.Open();
                    databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                    databaseSingleton.command.ExecuteNonQuery();
                    databaseSingleton.command.Dispose();
                    databaseSingleton.connection.Close();
                    //////
                    databaseSingleton.sql = "SELECT TOP 1 supplierID FROM Supplier ORDER BY supplierID DESC";
                    databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                    databaseSingleton.connection.Open();
                    databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                    databaseSingleton.dataReader = databaseSingleton.command.ExecuteReader();

                    while (databaseSingleton.dataReader.Read())
                    {
                        enteredSupplierID = databaseSingleton.dataReader.GetInt32(0);
                    }

                    databaseSingleton.command.Dispose();
                    databaseSingleton.connection.Close();




                    foreach (DataRowView item in goodsCheckedListBox.CheckedItems)
                    {

                        databaseSingleton.sql = "INSERT INTO GoodSupplier (goodID , supplierID) VALUES ('" + Convert.ToInt32(item["goodID"]) + "','" + enteredSupplierID+"')";
                        databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                        databaseSingleton.connection.Open();
                        databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                        databaseSingleton.command.ExecuteNonQuery();
                        databaseSingleton.command.Dispose();
                        databaseSingleton.connection.Close();
                    }

                    MessageBox.Show("Supplier added successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

    }
}
