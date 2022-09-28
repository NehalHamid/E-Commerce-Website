using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website.Model
{   public class AddCategory
    {
        public string name { set; get; }
        public string ImagePath { set; get; }
    }
    public class Category
    { 
        public int id { set; get; }
        public string name { set; get; } 
        public string ImagePath { set; get; }

        //relatioship with Product 1 ==> M
        public ICollection <Product> products { set; get; }

    }
}
