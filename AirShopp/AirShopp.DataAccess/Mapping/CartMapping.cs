using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class CartMapping : EntityTypeConfiguration<Cart>
    {
        public CartMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.UnitPrice).IsRequired();
            Property(e => e.Quantity).IsRequired();
            Property(e => e.IsBuy).IsRequired();
            Property(e => e.ProductTotalAmount).IsRequired();
            HasRequired(e => e.Customer).WithMany(e => e.Carts).HasForeignKey(fk => fk.CustomerId);
            HasRequired(e => e.Product).WithMany(e => e.Carts).HasForeignKey(fk => fk.ProductId);
        }
    }
}
