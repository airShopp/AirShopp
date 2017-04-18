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
            Property(e => e.CustomerId).IsRequired();
            Property(e => e.DeliveryAddress).IsRequired();
            Property(e => e.ReceiverName).IsRequired();
            Property(e => e.ReceiverPhone).IsRequired();
        }
    }
}
