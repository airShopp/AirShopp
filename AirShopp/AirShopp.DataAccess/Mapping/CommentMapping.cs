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
    class CommentMapping : EntityTypeConfiguration<Comment>
    {
        public CommentMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.OrderId).IsRequired();
            Property(e => e.ProductId).IsRequired();
            Property(e => e.Comments).HasMaxLength(256).IsRequired();

            HasRequired(e => e.Product).WithMany(e => e.Comment).HasForeignKey(fk => fk.ProductId);
            HasRequired(e => e.Order).WithMany(e => e.Comment).HasForeignKey(fk => fk.OrderId);
        }
    }
}
