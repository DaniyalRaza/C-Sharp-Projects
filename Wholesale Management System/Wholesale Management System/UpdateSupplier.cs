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
    public partial class UpdateSupplier : Form
    {
        public UpdateSupplier()
        {
            InitializeComponent();
        }

         private BindingSource suppliersBindingSource = new BindingSource();
         private SqlDataAdapter supplierDataAdapter = new SqlDataAdapter();
         private BindingSource goodsBindingSource = new BindingSource();
         private SqlDataAdapter goodsDataAdapter = new SqlDataAdapter();

        private void UpdateSupplier_Load(object sender, EventArgs e)
        {
            populateSuppliersComboBox("Select supplierID,supplierName from Supplier");
            
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

        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
            databaseSingleton.sql = "Select phone,address from Supplier WHERE supplierID=" + supplierComboBox.SelectedValue;
            databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
            try
            {
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.dataReader = databaseSingleton.command.ExecuteReader();
                if (databaseSingleton.dataReader.HasRows)
                {
                    while (databaseSingleton.dataReader.Read())
                    {
                        phoneTextBox.Text = databaseSingleton.dataReader.GetString(0);
                        addressTextBox.Text = databaseSingleton.dataReader.GetString(1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();
            }


            populateGoodsCheckList("Select goodID,goodName from Goods");

        }



        private void populateGoodsCheckList(string selectCommand){

            for (int i = 0; i < goodsCheckedListBox.Items.Count; i++) {
                goodsCheckedListBox.SetItemChecked(i, false);
            }




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

            DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
            databaseSingleton.sql = "Select goodID from GoodSupplier WHERE supplierID=" + supplierComboBox.SelectedValue;
            databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
            try
            {
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.dataReader = databaseSingleton.command.ExecuteReader();
                if (databaseSingleton.dataReader.HasRows)
                {
                    while (databaseSingleton.dataReader.Read())
                    {
                        int goodID = databaseSingleton.dataReader.GetInt32(0);
                        for (int i=0;i<goodsCheckedListBox.Items.Count;i++) {
                            if (goodID == Convert.ToInt32(((DataRowView)(goodsCheckedListBox.Items[i]))["goodID"])) {
                                goodsCheckedListBox.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();
            }







        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (phoneTextBox.Text == "" || addressTextBox.Text == "")
            {
                MessageBox.Show("please fill all the fields");
            }
            else
            {
                try
                {
                    string phone = phoneTextBox.Text;
                    string address = addressTextBox.Text;
                    DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
                    databaseSingleton.sql = "Update Supplier set phone='" + phone + "', address='" + address + "' where supplierID='" + supplierComboBox.SelectedValue + "'";
                    databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                    databaseSingleton.connection.Open();
                    databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                    databaseSingleton.command.ExecuteNonQuery();
                    databaseSingleton.command.Dispose();
                    databaseSingleton.connection.Close();



                    databaseSingleton.sql = "Delete from GoodSupplier where supplierID='" + supplierComboBox.SelectedValue + "'";
                    databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                    databaseSingleton.connection.Open();
                    databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                    databaseSingleton.command.ExecuteNonQuery();
                    databaseSingleton.command.Dispose();
                    databaseSingleton.connection.Close();



                    foreach (DataRowView item in goodsCheckedListBox.CheckedItems)
                    {

                        databaseSingleton.sql = "INSERT INTO GoodSupplier (goodID , supplierID) VALUES ('" + Convert.ToInt32(item["goodID"]) + "','" + supplierComboBox.SelectedValue + "')";
                        databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                        databaseSingleton.connection.Open();
                        databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                        databaseSingleton.command.ExecuteNonQuery();
                        databaseSingleton.command.Dispose();
                        databaseSingleton.connection.Close();
                    }

                    MessageBox.Show("Supplier updated successfully");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



    }
}
