using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.TotalAmount).IsOptional();
            Property(e => e.OrderStatus).HasMaxLength(32).IsRequired();
            Property(e => e.SpecialType).HasMaxLength(32).IsOptional();
            HasRequired(e => e.Customer).WithMany(k => k.Orders).HasForeignKey(fk => fk.CustomerId);
            HasRequired(e => e.Address).WithMany(e => e.Orders).HasForeignKey(fk => fk.AddressId);
        }
    }
}
