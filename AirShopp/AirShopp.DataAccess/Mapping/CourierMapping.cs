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
    class CourierMapping : EntityTypeConfiguration<Courier>
    {
        public CourierMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Name).HasMaxLength(32).IsRequired();
            Property(e => e.Phone).HasMaxLength(11).IsRequired();

            HasRequired(e => e.DeliveryStation).WithMany(e => e.Couriers).HasForeignKey(fk => fk.DeliveryStationId);
        }
    }
}
