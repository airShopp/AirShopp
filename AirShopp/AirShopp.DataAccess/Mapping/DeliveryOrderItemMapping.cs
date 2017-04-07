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
    class DeliveryOrderItemMapping : EntityTypeConfiguration<DeliveryOrderItem>
    {
        public DeliveryOrderItemMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.ProductName).HasMaxLength(256).IsRequired();
            Property(e => e.Unit).HasMaxLength(8).IsRequired();
            Property(e => e.OutNumber).IsRequired();
            Property(e => e.PricePerProduct).IsRequired();
            Property(e => e.TotalPrice).IsRequired();
            Property(e => e.Remarks).HasMaxLength(512).IsOptional();

            HasRequired(e => e.DeliveryOder).WithMany(e => e.DeliveryOrderItems).HasForeignKey(fk => fk.DeliveryOrderId);
        }
    }
}
