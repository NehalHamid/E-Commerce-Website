using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Model
{
    public class CustomerLogin
    {
        public string e_mail { set; get; }
        public string password { set; get; }
    }
    public class CustomerRegister
    {
        public string name { set; get; }
        public string e_mail { set; get; }
        public string password { set; get; }
        public string address { set; get; }
        public string phone { set; get; }
    }
  
    public class Customer
    {
        public int id { set; get; }
        public string name { set; get; }
        public string e_mail {set;get;}
        public string password { set; get; }
        public string address { set; get; }
        public string phone { set; get; }

        //relatioship with order 1 ==> M
        public ICollection <Order> orders { set; get; }


    }
}
