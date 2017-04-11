using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("OrderId")]
        [Required()]
        public virtual Order order { get; set; }

        [ForeignKey("ProductId")]
        [Required()]
        public virtual Product product { get; set; }
    }
}
