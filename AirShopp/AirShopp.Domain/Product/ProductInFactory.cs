using System;
using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class ProductInFactory
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public string Price { get; set; }
        public DateTime InDate { get; set; }
        public string ProductName { get; set; }

        public ICollection<InventoryAction> InventoryActions { get; set; }
    }
}
