using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class InventoryMapping : EntityTypeConfiguration<Inventory>
    {
        public InventoryMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Amount).IsRequired();
            HasRequired(e => e.Product).WithMany(e => e.Inventories).HasForeignKey(fk => fk.ProductId);
            HasRequired(e => e.Factory).WithMany(e => e.Inventories).HasForeignKey(fk => fk.FactoryId);
        }
    }
}
