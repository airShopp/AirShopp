using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class ProductInMapping :EntityTypeConfiguration<ProductIn>
    {
        public ProductInMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Amount).IsRequired();
            Property(e => e.Price).IsRequired();
            Property(e => e.InDate).IsRequired();
        }
    }
}
