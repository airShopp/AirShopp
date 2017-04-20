using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    public class Cart
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsBuy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }

}
