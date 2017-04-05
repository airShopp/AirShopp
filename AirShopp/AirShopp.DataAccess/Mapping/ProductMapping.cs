using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
          
            Property(e => e.ProductName).HasMaxLength(100).IsRequired();
            Property(e => e.Price).IsRequired();

            HasRequired(e => e.Category).WithMany(e => e.Products).HasForeignKey(fk => fk.CategoryId);
            HasRequired(e => e.Provider).WithMany(e => e.Products).HasForeignKey(fk => fk.ProviderId);
        }
    }
}
