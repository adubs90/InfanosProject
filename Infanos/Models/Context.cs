using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Infanos.Models
{
    public class Context : DbContext
    {
        public Context() : base("Infanos")
        {

        }
        public DbSet<Consoles> Consoles { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}