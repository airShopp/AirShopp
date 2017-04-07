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
    class DeliveryNoteMapping : EntityTypeConfiguration<DeliveryNote>
    {
        public DeliveryNoteMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.DeliveryNoteNumber).HasMaxLength(20).IsRequired();
            Property(e => e.BarCodeImgURL).HasMaxLength(512).IsRequired();
            Property(e => e.QRCodeImgURL).HasMaxLength(512).IsRequired();
            Property(e => e.Remarks).HasMaxLength(512).IsOptional();

            HasRequired(e => e.Order).WithOptional(e=>e.DeliveryNote);
        }
    }
}
