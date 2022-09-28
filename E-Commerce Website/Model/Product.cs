using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Model
{
    public class AddProduct
    {
       
        public string name { set; get; }
        public float price { set; get; }
        public int quantity { set; get; }
        public string ImagePath { set; get; }
    }
    public class Product
    {
        public int id { set; get; }
        public string name { set; get; }
        public double price { set; get; }
        public int quantity { set; get; }
        public string ImagePath { set; get; }

        //relationship with Order_Item  1 ==> M
        public ICollection<Order_Item> items { set; get; }
       

        //relationship with Category  1 ==> M
        public int categoryid { set; get; }
        public Category category  { set; get; }

        //Relationship with cartItem 1 ==> 1
        public int? cart_item { set; get; }
        [ForeignKey("cart_item")]
        public CartItem? cartItem { set; get; }

    }
}
