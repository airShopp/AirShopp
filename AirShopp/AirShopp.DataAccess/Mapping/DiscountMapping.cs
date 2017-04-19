using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class DiscountMapping : EntityTypeConfiguration<Discount>
    {
        public DiscountMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(e => e.Product).WithMany(e => e.Discounts).HasForeignKey(fk => fk.ProductId);
            Property(e => e.Discounts).IsRequired();
            Property(e => e.StartTime).IsRequired();
            Property(e => e.EndTime).IsRequired();
            Property(e => e.IsUsed).IsRequired();
        }
    }
}
