using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class AdminMapping : EntityTypeConfiguration<Admin>
    {
        public AdminMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Account).HasMaxLength(20).IsRequired();
            Property(e => e.Password).HasMaxLength(32).IsRequired();
        }
    }
}
