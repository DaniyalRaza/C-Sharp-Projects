using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wholesale_Management_System
{
    
    public class CurrentUser
    {
        private static CurrentUser instance;

        private CurrentUser() { }

        public static CurrentUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentUser();
                }
                return instance;
            }
        }

         public string username;
        public string role;

    }
}