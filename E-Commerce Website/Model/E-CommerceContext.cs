using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Model
{
    public class E_CommerceContext :DbContext
    {
        public DbSet <Customer> Customers { set; get; }
        public DbSet <Product> Products { set; get; }
        public DbSet <Category> Categories { set; get; }
        public DbSet <Order> Orders { set; get; }
        public DbSet <Order_Item> Order_Items { set; get; }
        public DbSet <Administrator> Administrators { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                          Data Source=SQL8001.site4now.net;
                          Initial Catalog=db_a8d18f_nehalhamid;
                          User Id=db_a8d18f_nehalhamid_admin;
                          Password=NaNaJK223");
        }

    }
}

