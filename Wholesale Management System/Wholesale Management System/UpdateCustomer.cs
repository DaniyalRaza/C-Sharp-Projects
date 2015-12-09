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
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private BindingSource customersBindingSource = new BindingSource();
        private SqlDataAdapter customerDataAdapter = new SqlDataAdapter();

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            populateCustomersComboBox("Select customerID,customerName from Customers");
        }

        void populateCustomersComboBox(string selectCommand) {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString = DatabaseSingleton.Instance.connetionString;

                // Create a new data adapter based on the specified query.
                customerDataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(customerDataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();

                customerDataAdapter.Fill(table);
                customersBindingSource.DataSource = table;
                this.customerComboBox.DisplayMember = "customerName";
                this.customerComboBox.ValueMember = "customerID";
                customerComboBox.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
            databaseSingleton.sql = "Select contact,address from Customers WHERE customerID="+customerComboBox.SelectedValue;
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
                        contactTextBox.Text = databaseSingleton.dataReader.GetString(0);
                        addressTextBox.Text = databaseSingleton.dataReader.GetString(1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();
            }
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            if (contactTextBox.Text == "" || addressTextBox.Text == "")
            {
                MessageBox.Show("please fill all the fields");
            }
            else {
                try
                {
                    string contact = contactTextBox.Text;
                    string address = addressTextBox.Text;
                    DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
                    databaseSingleton.sql = "Update Customers set contact='" + contact + "', address='" + address + "' where customerID='" + customerComboBox.SelectedValue+"'";
                    databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                    databaseSingleton.connection.Open();
                    databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                    databaseSingleton.command.ExecuteNonQuery();
                    databaseSingleton.command.Dispose();
                    databaseSingleton.connection.Close();
                    MessageBox.Show("Customer updated successfully");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
