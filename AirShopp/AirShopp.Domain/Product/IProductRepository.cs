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
    }
}
