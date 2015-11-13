using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Wholesale_Management_System
{

    public class DatabaseSingleton
    {
        private static DatabaseSingleton instance;

        private DatabaseSingleton() { }

        public static DatabaseSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseSingleton();
                }
                return instance;
            }
        }

        public string connetionString = "Data Source=WIN-VGBVPIFSLG5;Initial Catalog=Wholesale Database;Integrated Security=True;Pooling=False";
        public SqlConnection connection;
        public SqlCommand command;
        public string sql = null;
        public SqlDataReader dataReader;
    }



}
