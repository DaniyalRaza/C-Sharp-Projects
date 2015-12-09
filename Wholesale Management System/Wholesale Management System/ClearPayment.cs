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
    public partial class ClearPayment : Form
    {
        public ClearPayment()
        {
            InitializeComponent();
        }

        private BindingSource customerBindingSource = new BindingSource();
        private SqlDataAdapter customerDataAdapter = new SqlDataAdapter();
        private BindingSource paymentBindingSource = new BindingSource();
        private SqlDataAdapter paymentDataAdapter = new SqlDataAdapter();

        private void customersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString = DatabaseSingleton.Instance.connetionString;

                // Create a new data adapter based on the specified query.
                string selectCommand = "Select saleID,totalBill from Sales where paymentMade=0 AND customerID="+customersComboBox.SelectedValue;
                paymentDataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(paymentDataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();

                paymentDataAdapter.Fill(table);
                paymentBindingSource.DataSource = table;

                ((ListBox)this.paymentCheckedListBox).DataSource = table;
                ((ListBox)this.paymentCheckedListBox).DisplayMember = "totalBill";
                ((ListBox)this.paymentCheckedListBox).ValueMember = "saleID";





            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void populateCustomersComboBox(string selectCommand)
        {
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
                customerBindingSource.DataSource = table;
                this.customersComboBox.DisplayMember = "customerName";
                this.customersComboBox.ValueMember = "customerID";
                customersComboBox.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearPayment_Load(object sender, EventArgs e)
        {
            populateCustomersComboBox("Select customerID,CustomerName from Customers");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int totalClearedPayment=0;

            DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
            foreach (DataRowView item in paymentCheckedListBox.CheckedItems) {
                totalClearedPayment += Convert.ToInt32(item["totalBill"]);

               
                
                databaseSingleton.sql = "Update Sales set paymentMade=1 where saleID=" + item["saleID"];
                databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.command.ExecuteNonQuery();
                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();

            }


            databaseSingleton.sql = "Update Customers set dueAmount=dueAmount-" + totalClearedPayment + " where customerID=" + customersComboBox.SelectedValue;
            databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
            databaseSingleton.connection.Open();
            databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
            databaseSingleton.command.ExecuteNonQuery();
            databaseSingleton.command.Dispose();
            databaseSingleton.connection.Close();


            paymentCheckedListBox.Refresh();
            MessageBox.Show("Payments cleared successfully");
        }




    }
}
