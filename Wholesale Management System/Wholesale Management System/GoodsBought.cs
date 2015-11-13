using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wholesale_Management_System
{
    class GoodsBought
    {
        public int goodID;
        public string goodName;
        public int price;
        public int totalPrice;
        public int quantity;

        public GoodsBought(int goodID, string goodName, int price, int totalPrice, int quantity) {
            this.goodID = goodID;
            this.goodName = goodName;
            this.price = price;
            this.totalPrice = totalPrice;
            this.quantity = quantity;
        }

    }
}
