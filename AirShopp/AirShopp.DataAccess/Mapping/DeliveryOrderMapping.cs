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
    class DeliveryOrderMapping : EntityTypeConfiguration<DeliveryOrder>
    {
        public DeliveryOrderMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.DeliveryOrderNumber).HasMaxLength(20).IsRequired();
            Property(e => e.DeliveryDate).IsRequired();
            Property(e => e.TotalRMBInChinese).HasMaxLength(50).IsRequired();
            Property(e => e.TotalRMBInNumberic).HasMaxLength(50).IsRequired();
        }
    }
}
