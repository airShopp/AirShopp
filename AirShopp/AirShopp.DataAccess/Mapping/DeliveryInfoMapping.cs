using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess.Mapping
{
    class DeliveryInfoMapping : EntityTypeConfiguration<DeliveryInfo>
    {
        public DeliveryInfoMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Description).HasMaxLength(512).IsRequired();
            Property(e => e.CurrentLocation).HasMaxLength(64).IsRequired();
            Property(e => e.UpdateTime).IsRequired();

            HasRequired(e => e.Order).WithMany(e => e.DeliveryInfos).HasForeignKey(fk => fk.OrderId);
        }
    }
}
