using System;
using System.Collections.Generic;
using AirShopp.Domain;
using System.Linq;
using System.Web;

namespace AirShopp.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public long AddProduct(Product product)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                _context.Product.Add(product);
                _context.SaveChanges();
                return product.Id;
            }
        }

        public void DeleteProduct(long productId)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                try
                {
                   
                    var productSales = _context.ProductSales.Where(ps => ps.ProductId == productId).FirstOrDefault();
                    if (productSales != null)
                    {
                        _context.ProductSales.Remove(productSales);
                        _context.SaveChanges();
                    }

                    var inventory = _context.Inventory.Where(i => i.ProductId == productId).FirstOrDefault();
                    if (inventory != null)
                    {
                        _context.Inventory.Remove(inventory);
                        _context.SaveChanges();
                    }
                    var orderItem = _context.OrderItem.Where(oi => oi.ProductId == productId).FirstOrDefault();
                    if (orderItem != null)
                    {
                        _context.OrderItem.Remove(orderItem);
                        _context.SaveChanges();
                    }
                    var discount = _context.Discount.Where(d => d.ProductId == productId).FirstOrDefault();
                    if (discount != null)
                    {
                        _context.Discount.Remove(discount);
                        _context.SaveChanges();
                    }
                    var comment = _context.Comments.Where(c => c.ProductId == productId).FirstOrDefault();
                    if (comment != null)
                    {
                        _context.Comments.Remove(comment);
                        _context.SaveChanges();
                    }
                    var cartItem = _context.CartItem.Where(ci => ci.ProductId == productId).FirstOrDefault();

                    var product = _context.Product.Where(p => p.Id == productId).FirstOrDefault();
                    if (product != null)
                    {
                        _context.Product.Remove(product);
                        _context.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public Product GetProductById(long productId)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                Product product = null;
                product = _context.Product.FirstOrDefault(x => x.Id == productId);
                return product;
            }
        }

        public List<Product> Products()
        {
            string path = HttpRuntime.AppDomainAppPath.ToString() + "\\Content\\Images\\HomePage\\p1.jpg";
            string imgPath = path.Substring(path.IndexOf("\\Content"));
            string RealPath = imgPath.Replace("\\","/");

           
            using (AirShoppContext _context = new AirShoppContext())
            {
                List<Product> products = new List<Product>();
                _context.Product.OrderBy(x => Guid.NewGuid()).Take(10).ToList().ForEach(product =>
                {
                    products.Add(new Product()
                    {
                        Id = product.Id,
                        Price = product.Price,
                        KeepDate = product.KeepDate,
                        ProductionDate = product.ProductionDate,
                        ProductName = product.ProductName,
                        Description = product.Description,
                        Url = RealPath
                    });
                });
                return products;
            }
        }

        public void UpdateProductInfo(long productId, string productName, string productUrl, bool isOnSale, decimal price)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                try
                {
                    var product = _context.Product.Where(p => p.Id == productId).FirstOrDefault();
                    if (product != null)
                    {
                        product.ProductName = productName;
                        if (productUrl != null)
                        {
                            product.Url = productUrl;
                        }
                        product.IsOnSale = isOnSale;
                        product.Price = price;
                        _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                        _context.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
