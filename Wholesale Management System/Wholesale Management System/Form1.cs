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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
            databaseSingleton.sql = "Select userName,role from Authentication WHERE userName='"+userName+"' AND password='"+password+"'";
            databaseSingleton.connection = new SqlConnection(databaseSingleton.connetionString);
            try
            {
                databaseSingleton.connection.Open();
                databaseSingleton.command = new SqlCommand(databaseSingleton.sql, databaseSingleton.connection);
                databaseSingleton.dataReader = databaseSingleton.command.ExecuteReader();
                
                if(databaseSingleton.dataReader.HasRows){
                    CurrentUser currentUser = CurrentUser.Instance;
                    while (databaseSingleton.dataReader.Read()){
                        currentUser.username = databaseSingleton.dataReader.GetValue(0).ToString();
                        currentUser.role = databaseSingleton.dataReader.GetValue(1).ToString();
                        MainScreen mainScreen = new MainScreen();
                        mainScreen.Show();
                    }
                }
                else{
                    MessageBox.Show("Username or Password is incorrect");
                }
                
                
                databaseSingleton.dataReader.Close();
                databaseSingleton.command.Dispose();
                databaseSingleton.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! "+ex.Message);
            }
        }
    }
}
