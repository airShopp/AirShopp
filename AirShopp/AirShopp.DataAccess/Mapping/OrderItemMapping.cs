using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class OrderItemMapping : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(e => e.Order).WithMany(e => e.OrderItems).HasForeignKey(fk => fk.OrderId);

            HasRequired(e => e.Product).WithMany(e => e.OrderItems).HasForeignKey(fk => fk.ProductId);
        }
    }
}
