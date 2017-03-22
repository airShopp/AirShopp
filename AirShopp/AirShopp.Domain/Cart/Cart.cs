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
        public decimal ProductTotalAmount { get; set; }

        [ForeignKey("CustomerId")]
        [Required()]
        public virtual Customer customer { get; set; }

        [ForeignKey("ProductId")]
        [Required()]
        public virtual Product product { get; set; }
    }
}
