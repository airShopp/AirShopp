using System;
using System.Collections.Generic;
using AirShopp.Domain;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public readonly AirShoppContext _context = new AirShoppContext();

        public List<Product> Products()
        {
            List<Product> products = new List<Product>();
            _context.Product.OrderBy(x =>Guid.NewGuid()).Take(10).ToList().ForEach(product => {
                products.Add(new Product() {
                      Id = product.Id,
                      Price = product.Price,
                      KeepDate = product.KeepDate,
                      ProductionDate = product.ProductionDate,
                      ProductName = product.ProductName
                });
            });
            return products;
        }
    }
}
