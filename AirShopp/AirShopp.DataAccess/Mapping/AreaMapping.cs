﻿using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess.Mapping
{
    class AreaMapping : EntityTypeConfiguration<Area>
    {
        public AreaMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.AreaId).IsRequired();
            Property(e => e.AreaName).HasMaxLength(256).IsRequired();
        }
    }
}
