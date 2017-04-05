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
    class ProvinceMapping : EntityTypeConfiguration<Province>
    {
        public ProvinceMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.ProvinceId).IsRequired();
            Property(e => e.ProvinceName).HasMaxLength(200).IsRequired();
        }
    }
}