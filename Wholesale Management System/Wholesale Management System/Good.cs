using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wholesale_Management_System
{
    class Good
    {
        public int goodID;
        public string goodName;
        public int quantity;
        public int price;

       public Good(int goodID,string goodName,int price,int quantity) {
            this.goodID = goodID;
            this.goodName=goodName;
            this.price = price;
            this.quantity = quantity;
        }

    }
}
