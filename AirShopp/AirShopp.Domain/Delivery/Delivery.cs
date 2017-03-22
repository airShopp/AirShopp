using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    public class Delivery
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string CustomerName { get; set; }

        [ForeignKey("OrderId")]
        [Required()]
        public virtual Order order { get; set; }

        [ForeignKey("ProductId")]
        [Required()]
        public virtual Product product { get; set; }
    }
}
