using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class ProductSalesMapping : EntityTypeConfiguration<ProductSales>
    {
        public ProductSalesMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.ProductId).IsRequired();
            Property(e => e.SalesAmount).IsRequired();
            Property(e => e.CreateDate).IsRequired();
            Property(e => e.UpdateDate).IsRequired();
        }
    }
}
