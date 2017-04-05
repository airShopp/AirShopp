using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class InventoryAction
    {
        public long Id { get; set; }
        public long ProductInFactoryId { get; set; }
        public long ProductOutFactoryId { get; set; }

        public ProductInFactory ProductInFactory { get; set; }
        public ProductOutFactory ProductOutFactory { get; set; }
    }
}
