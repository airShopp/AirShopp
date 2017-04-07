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
    class DeliveryStationMapping : EntityTypeConfiguration<DeliveryStation>
    {
        public DeliveryStationMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name).HasMaxLength(32).IsRequired();
            Property(e => e.Address).HasMaxLength(64).IsRequired();
            Property(e => e.Latitude).IsRequired();
            Property(e => e.Longitude).IsRequired();
            Property(e => e.StationLevel).IsRequired();

            HasRequired(e => e.ParentDeliveryStation).WithMany(e=>e.DeliveryStations).HasForeignKey(fk => fk.ParentStationId);
        }
    }
}
