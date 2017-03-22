using AirShopp.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class ProviderMapping : EntityTypeConfiguration<Provider>
    {
        public ProviderMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(e => e.ProviderName).IsRequired();
        }
    }
}
