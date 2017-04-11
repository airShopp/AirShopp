using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class ProductOutMapping : EntityTypeConfiguration<ProductOutFactory>
    {
        public ProductOutMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Amount).IsRequired();
            Property(e => e.OutDate).IsRequired();
        }
    }
}
