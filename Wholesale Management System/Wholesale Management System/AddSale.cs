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
    public partial class AddSale : Form
    {
        public AddSale()
        {
            InitializeComponent();
        }

        List<GoodsBought> items = new List<GoodsBought>();
        List<Good> goodsList = new List<Good>();

        private BindingSource goodsBindingSource = new BindingSource();
        private SqlDataAdapter goodsDataAdapter = new SqlDataAdapter();
        private BindingSource customerBindingSource = new BindingSource();
        private SqlDataAdapter customerDataAdapter = new SqlDataAdapter();

        DataTable table = new DataTable();
        int selectedGoodPrice;
        int totalAmount;

        private void AddSale_Load(object sender, EventArgs e)
        {
            populateGoodsComboBox("SELECT Goods.goodID, Goods.goodName,Goods.price,Stocks.quantity FROM Goods INNER JOIN Stocks ON Stocks.goodID = Goods.goodID");
            populateCustomersComboBox("Select customerID,CustomerName from Customers");
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
               

                goodsDataAdapter.Fill(table);
                goodsBindingSource.DataSource = table;
                this.goodsComboBox.DisplayMember = "goodName";
                this.goodsComboBox.ValueMember = "goodID";
                goodsComboBox.DataSource = table;
                for (int i = 0; i < table.Rows.Count; i++) {
                    Good good = new Good(Convert.ToInt32(table.Rows[i]["goodID"]), table.Rows[i]["goodName"].ToString(), Convert.ToInt32(table.Rows[i]["price"]), Convert.ToInt32(table.Rows[i]["quantity"]));
                    goodsList.Add(good);
                }
               
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
                this.customerComboBox.DisplayMember = "customerName";
                this.customerComboBox.ValueMember = "customerID";
                customerComboBox.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void goodsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int quantity=Convert.ToInt32(table.Rows[goodsComboBox.SelectedIndex]["quantity"]);
            int price=Convert.ToInt32(table.Rows[goodsComboBox.SelectedIndex]["price"]);
            selectedGoodPrice = price;
            quantityNumericUpDown.Maximum = quantity;
            totalTextBox.Text = (quantityNumericUpDown.Value * price).ToString();
        }

        private void quantityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(table.Rows[goodsComboBox.SelectedIndex]["price"]);
            totalTextBox.Text = (price * quantityNumericUpDown.Value).ToString();

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (quantityNumericUpDown.Value == 0) {
                MessageBox.Show("Not enough quantity to add");
                return;
            }

            

            GoodsBought goodBought=new GoodsBought(Convert.ToInt32(goodsComboBox.SelectedValue), goodsComboBox.Text,selectedGoodPrice,Convert.ToInt32(selectedGoodPrice * quantityNumericUpDown.Value),Convert.ToInt32(quantityNumericUpDown.Value));

            this.goodsListGridView.Rows.Add(goodBought.goodID,goodBought.goodName,goodBought.price,goodBought.quantity,goodBought.totalPrice);

            table.Rows[goodsComboBox.SelectedIndex]["quantity"] = Convert.ToInt32(table.Rows[goodsComboBox.SelectedIndex]["quantity"]) - goodBought.quantity;
            quantityNumericUpDown.Maximum = Convert.ToInt32(table.Rows[goodsComboBox.SelectedIndex]["quantity"]);
            totalAmount += goodBought.totalPrice;
            totalAmountLabel.Text = totalAmount.ToString();
        }

        private void confirmSaleButton_Click(object sender, EventArgs e)
        {


            if (goodsListGridView.RowCount == 0) {
                MessageBox.Show("No item is selected to buy");
                return;
            }


            int customerID = Convert.ToInt32(customerComboBox.SelectedValue);
            int totalBill = totalAmount;
            bool paymentMade = paymentCheckBox.Checked;
            DateTime saleDate = DateTime.Now;

            try
            {
                DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
                databaseSingleton.sql = "INSERT INTO Sales (customerID, totalBill, paymentMade,saleDate) VALUES ('" + customerID + "','" + totalBill + "','" + paymentMade + "','" + saleDate + "')";
                databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.command.ExecuteNonQuery();
                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();

                if (paymentMade == false) {
                    databaseSingleton.sql = "Update Customers set dueAmount=dueAmount+" + totalBill+" where customerID='"+customerID+"'";
                    databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                    databaseSingleton.connection.Open();
                    databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                    databaseSingleton.command.ExecuteNonQuery();
                    databaseSingleton.command.Dispose();
                    databaseSingleton.connection.Close();
                }


                for (int i = 0; i < goodsListGridView.Rows.Count; i++) {

                    int goodID = Convert.ToInt32(goodsListGridView.Rows[i].Cells[0].Value);
                    int quantity = Convert.ToInt32(goodsListGridView.Rows[i].Cells[3].Value);
                    int bill = Convert.ToInt32(goodsListGridView.Rows[i].Cells[4].Value);
                    
                    int saleID=0;
                    databaseSingleton.sql = "SELECT TOP 1 saleID FROM Sales ORDER BY saleID DESC";
                    databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                    databaseSingleton.connection.Open();
                    databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                    databaseSingleton.dataReader = databaseSingleton.command.ExecuteReader();

                    while (databaseSingleton.dataReader.Read())
                    {
                        saleID = databaseSingleton.dataReader.GetInt32(0);
                    }

                    databaseSingleton.command.Dispose();
                    databaseSingleton.connection.Close();

                    databaseSingleton.sql = "INSERT INTO GoodsBought (goodID, saleID, quantity,bill) VALUES ('" + goodID + "','" + saleID + "','" + quantity + "','" + bill + "')";
                    databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                    databaseSingleton.connection.Open();
                    databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                    databaseSingleton.command.ExecuteNonQuery();
                    databaseSingleton.command.Dispose();
                    databaseSingleton.connection.Close();
                }


                for (int i = 0; i<goodsListGridView.Rows.Count;i++){
                    int goodID = Convert.ToInt32(goodsListGridView.Rows[i].Cells[0].Value);
                    int quantity = Convert.ToInt32(goodsListGridView.Rows[i].Cells[3].Value);
                    databaseSingleton.sql = "Update Stocks set quantity=quantity-" + quantity + " where goodID='" + goodID + "'";
                    databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
                    databaseSingleton.connection.Open();
                    databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                    databaseSingleton.command.ExecuteNonQuery();
                    databaseSingleton.command.Dispose();
                    databaseSingleton.connection.Close();

                }


                    MessageBox.Show("Sales added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

     
        
        

       
    }
}
