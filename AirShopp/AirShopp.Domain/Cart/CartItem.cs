using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class CartItem
    {
        public CartItem()
        {

        }

        public long Id { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerProduct { get; set; }
        public string ItemStatus { get; set; } //PENDING DELETE BOUGHT

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public long CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
