using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Model
{ 
    public class AdminLogin
    {
        public string e_mail { set; get; }
        public string password { set; get; }
    }
    public class Administrator
    {
        public int id { set; get; }
        public string name { set; get; }
        public string e_mail { set; get; }
        public string password { set; get; }

       
       
    }
}
