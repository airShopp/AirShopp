using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface IReadFromDb
    {
        IQueryable<Category> Categories { get; }
        IQueryable<Cart> Carts { get; }
        IQueryable<InventoryAction> InventoryActions { get; }
        IQueryable<Inventory> Inventories { get; }
        IQueryable<Product> Products { get; }
        IQueryable<Discount> Discounts { get; }
        IQueryable<ProductOutFactory> ProductOutFactories { get; }
        IQueryable<ProductSales> ProductSales { get; }
        IQueryable<Comment> Comments { get; }
        IQueryable<Order> Orders { get; }
        IQueryable<CartItem> CartItems { get; }
        IQueryable<Customer> Customers { get; }

    }
}
