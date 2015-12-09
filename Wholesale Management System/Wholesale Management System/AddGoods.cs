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
    public partial class AddGoods : Form
    {
        public AddGoods()
        {
            InitializeComponent();
        }

        private BindingSource suppliersBindingSource = new BindingSource();
        private SqlDataAdapter supplierDataAdapter = new SqlDataAdapter();

        private void AddGoods_Load(object sender, EventArgs e)
        {
            populateSuppliersCheckList("Select supplierID,supplierName from Supplier");
        }

        private void populateSuppliersCheckList(string selectCommand)
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

                ((ListBox)this.suppliersListBox).DataSource = table;
                ((ListBox)this.suppliersListBox).DisplayMember = "supplierName";
                ((ListBox)this.suppliersListBox).ValueMember = "supplierID";


               
                
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int enteredGoodID = 0;

                string goodName = goodNameTextBox.Text;
                int price = Convert.ToInt32(priceNumericUpDown.Value);
                DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
                databaseSingleton.sql = "INSERT INTO Goods (goodName , price) VALUES ('" + goodName + "','" + price + "')";
                databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.command.ExecuteNonQuery();
                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();
                //////
                databaseSingleton.sql = "SELECT TOP 1 goodID FROM Goods ORDER BY goodID DESC";
                databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.dataReader = databaseSingleton.command.ExecuteReader();

                while (databaseSingleton.dataReader.Read())
                {
                    enteredGoodID = databaseSingleton.dataReader.GetInt32(0);
                }

                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();

                


                foreach(DataRowView item in suppliersListBox.CheckedItems){
         
                    databaseSingleton.sql = "INSERT INTO GoodSupplier (goodID , supplierID) VALUES ('" + enteredGoodID + "','" + Convert.ToInt32(item["supplierID"]) + "')";
                    databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                    databaseSingleton.connection.Open();
                    databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                    databaseSingleton.command.ExecuteNonQuery();
                    databaseSingleton.command.Dispose();
                    databaseSingleton.connection.Close();
                }
               
                MessageBox.Show("Goods added successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
