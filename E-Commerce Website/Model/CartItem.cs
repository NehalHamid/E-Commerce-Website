using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Model
{
    public class CartItem
    {
        public int id { set; get; }
        //Relationship with product 1 ==> 1
        public int PId { get; set; }
        [ForeignKey("PId")]
        public Product Product { set; get; }
        public int Qty { get; set; }
    }


    //ده اللي هتعامل معاه 
    public class OrderDTO
    {
        public int customerId { get; set; }

        public List<CartItem> list { get; set; }
    }
}
