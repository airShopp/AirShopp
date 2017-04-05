using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirShopp.Domain
{
    public class Order
    {

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Customer Customer { get; set; }
    }
}
