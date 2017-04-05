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
    class CityMapping: EntityTypeConfiguration<City>
    {
        public CityMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.CityId).IsRequired();
            Property(e => e.CityName).HasMaxLength(200).IsRequired();

            HasRequired(e => e.Province).WithMany(k => k.Citys).HasForeignKey(fk => fk.ProvinceId);
        }
    }
}
