using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Model
{
    public class Orderdata
    {

        public int productid { set; get; }
        public int qty { get; set; }
        public int orderid { set; get; }
    }
    public class Order_Item
    { 
        public int id { set; get; }
        public int qty { get; set; }


        //relatioship with order 1 ==> M
        public int orderid { set; get; }
        public Order order { set ; get; }

        //relatioship with Product 1 ==> M
        public int productid { set; get; }
        public Product product { set; get; }
    }
}
