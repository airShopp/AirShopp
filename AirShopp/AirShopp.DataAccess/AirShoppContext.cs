using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class AirShoppContext :DbContext
    {
        public AirShoppContext() : base("name = AirContext")
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Return> Return { get; set; }

        public DbSet<Admin> Admin { get; set; }
    }
}
