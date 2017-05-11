using System;
using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class ProductOutFactory
    {
        public ProductOutFactory()
        {

        }

        public long Id { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime OutDate { get; set; }
        public long CustomerId { get; set; }
    }
}
