using System;
using System.Collections.Generic;
using AirShopp.Domain;
using System.Linq;
using System.Web;

namespace AirShopp.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public readonly AirShoppContext _context = new AirShoppContext();

        public List<Product> Products()
        {
            string path = HttpRuntime.AppDomainAppPath.ToString() + "\\Content\\Images\\HomePage\\p1.jpg";
            string imgPath = path.Substring(path.IndexOf("Content"));
            string RealPath = imgPath.Replace("\\","/");

            List<Product> products = new List<Product>();
            _context.Product.OrderBy(x => Guid.NewGuid()).Take(10).ToList().ForEach(product => {
                products.Add(new Product() {
                      Id = product.Id,
                      Price = product.Price,
                      KeepDate = product.KeepDate,
                      ProductionDate = product.ProductionDate,
                      ProductName = product.ProductName,
                      Description = product.Description,
                      url = RealPath
                });
            });
            return products;
        }
    }
}
