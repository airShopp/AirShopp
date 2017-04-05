using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class Factory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsUsed { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
    }
}
