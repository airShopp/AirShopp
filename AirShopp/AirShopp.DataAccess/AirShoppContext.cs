using AirShopp.DataAccess.Mapping;
using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        public DbSet<Address> Address { get; set; }
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

        public DbSet<ProductInFactory> ProductInFactory { get; set; }
        public DbSet<ProductOutFactory> ProductOutFactory { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryAction> InventoryAction { get; set; }

        public DbSet<Province> Province { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<DeliveryInfo> DeliveryInfo { get; set; }
        public DbSet<DeliveryNote> DeliveryNote { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrder { get; set; }
        public DbSet<DeliveryOrderItem> DeliveryOrderItem { get; set; }
        public DbSet<DeliveryStation> DeliveryStation { get; set; }
        public DbSet<Courier> Courier { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CustomerMapping());
            modelBuilder.Configurations.Add(new AddressMapping());
            modelBuilder.Configurations.Add(new DiscountMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new ProviderMapping());
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new CartMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new DeliveryMapping());
            modelBuilder.Configurations.Add(new OrderItemMapping());
            modelBuilder.Configurations.Add(new ReturnMapping());
            modelBuilder.Configurations.Add(new AdminMapping());

            modelBuilder.Configurations.Add(new ProductInMapping());
            modelBuilder.Configurations.Add(new ProductOutMapping());
            modelBuilder.Configurations.Add(new WarehouseMapping());
            modelBuilder.Configurations.Add(new InventoryMapping());
            modelBuilder.Configurations.Add(new InventoryActionMapping());

            modelBuilder.Configurations.Add(new ProvinceMapping());
            modelBuilder.Configurations.Add(new CityMapping());
            modelBuilder.Configurations.Add(new AreaMapping());
            modelBuilder.Configurations.Add(new DeliveryInfoMapping());
            modelBuilder.Configurations.Add(new DeliveryNoteMapping());
            modelBuilder.Configurations.Add(new DeliveryOrderMapping());
            modelBuilder.Configurations.Add(new DeliveryOrderItemMapping());
            modelBuilder.Configurations.Add(new CourierMapping());
            modelBuilder.Configurations.Add(new DeliveryStationMapping());
        }
    }
}
