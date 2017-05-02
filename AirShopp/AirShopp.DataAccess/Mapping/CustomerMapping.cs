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
            Property(e => e.CustomerName).HasMaxLength(32).IsRequired();
            Property(e => e.TelephoneNo).HasMaxLength(11).IsRequired();

            Property(e => e.QuestionA).HasMaxLength(64).IsRequired();
            Property(e => e.QuestionB).HasMaxLength(64).IsRequired();
            Property(e => e.AnswerA).HasMaxLength(64).IsRequired();
            Property(e => e.AnswerB).HasMaxLength(64).IsRequired();
            Property(e => e.LastSignInIpAddr).HasMaxLength(64).IsRequired();
        }
    }
}
