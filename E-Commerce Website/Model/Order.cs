using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Model
{
    public class Order
    {
        public int id { set; get; }
        public DateTime date { set; get; }


        //relationship with customer 1 ==> M
        public int customerid { set; get; }
        public Customer customer { set ; get; }

        //relatioship with Order_Item 1 ==> M
        public ICollection <Order_Item> items { set; get; }

    }
}
