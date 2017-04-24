using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class Warehouse
    {
        public Warehouse()
        {
            Inventories = new List<Inventory>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsUsed { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
    }
}
