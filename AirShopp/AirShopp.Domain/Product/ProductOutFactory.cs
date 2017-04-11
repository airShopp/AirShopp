using System;
using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class ProductOutFactory
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public DateTime OutDate { get; set; }
        public string ProductName { get; set; }

        public ICollection<InventoryAction> InventoryActions { get; set; }
    }
}
