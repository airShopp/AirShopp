using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class FactoryMapping : EntityTypeConfiguration<Factory>
    {
        public FactoryMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Name).HasMaxLength(100).IsRequired();
            Property(e => e.IsUsed).IsRequired();

        }
    }
}
