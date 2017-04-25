using AirShopp.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AirShopp.DataAccess.Mapping
{
    class ReturnMapping : EntityTypeConfiguration<Return>
    {
        public ReturnMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.ReturnReason).IsRequired().HasMaxLength(256);
            Property(e => e.ReturnStatus).HasMaxLength(32).IsRequired();
            Property(e => e.CustomerName).HasMaxLength(32).IsRequired();

            HasRequired(e => e.Order).WithMany(e => e.Returns).HasForeignKey(fk => fk.OrderId);

            HasRequired(e => e.OrderItem).WithOptional(e => e.Return);
        }
    }
}
