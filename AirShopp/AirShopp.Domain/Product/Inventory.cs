using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class Inventory
    {
        public Inventory()
        {
            InventoryActions = new List<InventoryAction>();
        }

        public long Id { get; set; }
        public long ProductId { get; set; }
        public long WarehouseId { get; set; }
        public int Amount { get; set; }

        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
        public ICollection<InventoryAction> InventoryActions { get; set; }
    }
}
