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
    public partial class GoodsBoughtWindow : Form
    {
        public GoodsBoughtWindow(int saleID)
        {
            InitializeComponent();
            this.saleID = saleID;
        }

        int saleID;

        private BindingSource goodsBindingSource = new BindingSource();
        private SqlDataAdapter goodsDataAdapter = new SqlDataAdapter();

        private void GoodsBoughtWindow_Load(object sender, EventArgs e)
        {
     
            goodsBoughtGridView.DataSource = goodsBindingSource;
            GetData("SELECT GoodsBought.goodBoughtId, Goods.goodName, GoodsBought.quantity, GoodsBought.bill FROM GoodsBought INNER JOIN Goods ON GoodsBought.goodID = Goods.goodID AND GoodsBought.saleID = '"+saleID+"'");
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
                goodsDataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(goodsDataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                goodsDataAdapter.Fill(table);
                goodsBindingSource.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                goodsBoughtGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
