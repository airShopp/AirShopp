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
    class InventoryActionMapping : EntityTypeConfiguration<InventoryAction>
    {
        public InventoryActionMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(e => e.Inventory).WithMany(e => e.InventoryActions).HasForeignKey(fk => fk.InventoryId);
        }
    }
}
