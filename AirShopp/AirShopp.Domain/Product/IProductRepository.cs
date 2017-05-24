using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface IProductRepository
    {
        List<Product> Products();
        Product GetProductById(long productId);
        long AddProduct(Product product);
        void UpdateProductInfo(long productId, string productName ,string productUrl, bool isOnSale,decimal price);
        void DeleteProduct(long productId);
    }
}
