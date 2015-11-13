using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace Wholesale_Management_System
{
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            fillChart1();
            fillChart2();
            
        }

        private void fillChart1()  
        {

            chart1.Series.RemoveAt(0);
            chart1.Series.Add("Customers");
            
            //chart1.Series.Add("Buying");
            DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
            databaseSingleton.sql = "SELECT  Customers.customerName, SUM(Sales.totalBill) AS totalBill FROM  Sales INNER JOIN Customers ON Sales.customerID = Customers.customerID GROUP BY Sales.customerID, Customers.customerName";
            databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
            try
            {
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(databaseSingleton.sql, databaseSingleton.connection);


                adapter.Fill(ds);

                DataView datasource = new DataView(ds.Tables[0]);
                chart1.DataSource = datasource;
                chart1.Series[0].XValueMember = "customerName";
                chart1.Series[0].YValueMembers = "totalBill";
                chart1.DataBind();


               
                
                databaseSingleton.connection.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
  
        }

        private void fillChart2()
        {

            chart2.Series.RemoveAt(0);
            chart2.Series.Add("Goods");

            //chart1.Series.Add("Buying");
            DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
            databaseSingleton.sql = "SELECT  Goods.goodName, SUM(GoodsBought.quantity) AS Quantity FROM  GoodsBought INNER JOIN Goods ON GoodsBought.goodID = Goods.goodID GROUP BY GoodsBought.goodID, Goods.goodName";
            databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
            try
            {
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(databaseSingleton.sql, databaseSingleton.connection);


                adapter.Fill(ds);

                DataView datasource = new DataView(ds.Tables[0]);
                chart2.DataSource = datasource;
                chart2.Series[0].XValueMember = "goodName";
                chart2.Series[0].YValueMembers = "Quantity";
                chart2.DataBind();




                databaseSingleton.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }  


    }
}
