using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    class CartItemMapping : EntityTypeConfiguration<CartItem>
    {
        public CartItemMapping()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Quantity).IsRequired();
            Property(e => e.PricePerProduct).IsRequired();
            Property(e => e.ItemStatus).HasMaxLength(16).IsRequired();

            HasRequired(e => e.Cart).WithMany(e => e.CartItems).HasForeignKey(fk => fk.CartId);
            HasRequired(e => e.Product).WithMany(e => e.CartItems).HasForeignKey(e => e.ProductId);
        }
    }
}
