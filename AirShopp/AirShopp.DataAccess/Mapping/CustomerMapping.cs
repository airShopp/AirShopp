using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class CustomerMapping : EntityTypeConfiguration<Customer> 
    {
        public CustomerMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Account).HasMaxLength(32).IsRequired();
            Property(e => e.Password).HasMaxLength(32).IsRequired();
            Property(e => e.CustomerName).HasMaxLength(32).IsOptional();
            Property(e => e.ZipCode).HasMaxLength(6).IsOptional();
            Property(e => e.TelephoneNo).HasMaxLength(11).IsOptional();
        }
    }
}
