using System.Collections.Generic;

namespace AirShopp.Domain
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public long Id { get; set; }
        public string CategoryName { get; set; }
        public long ParentId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
