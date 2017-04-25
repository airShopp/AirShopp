using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    public class OrderItem
    {
        public OrderItem()
        {

        }

        public long Id { get; set; }
        
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Quantity { get; set; }

        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Return Return { get; set; }
    }
}
