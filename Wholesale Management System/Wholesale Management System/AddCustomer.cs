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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string customerName = nameTextBox.Text;
            string contact = contactTextBox.Text;
            string address = addressTextBox.Text;


            try
            {
                DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
                databaseSingleton.sql = "INSERT INTO Customers (customerName , contact, Address, dueAmount) VALUES ('" + customerName + "','" + contact + "','" + address + "','" + 0 + "')";
                databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.command.ExecuteNonQuery();
                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();

                MessageBox.Show("Customer Added Successfully");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
