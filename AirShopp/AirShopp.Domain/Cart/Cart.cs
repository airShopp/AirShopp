using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    [Table("Cart")]
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
