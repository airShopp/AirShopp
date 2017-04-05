using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class Provider
    {
        public Provider()
        {
            Products = new List<Product>();
        }

        public long Id { get; set; }
        public string ProviderName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
