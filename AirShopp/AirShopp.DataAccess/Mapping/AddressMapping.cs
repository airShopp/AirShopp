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
    class AddressMapping : EntityTypeConfiguration<Address>
    {
        public AddressMapping() 
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.DeliveryAddress).HasMaxLength(128).IsRequired();
            Property(e => e.ReceiverName).HasMaxLength(32).IsRequired();
            Property(e => e.ReceiverPhone).HasMaxLength(11).IsRequired();

            HasRequired(e => e.Area).WithMany(e => e.Addresses).HasForeignKey(e => e.AreaId);
            HasRequired(e => e.Customer).WithMany(e => e.Addresses).HasForeignKey(e => e.CustomerId);
        }
    }
}
