using System;
using System.Linq;
using AirShopp.Domain;

namespace AirShopp.DataAccess
{
    public class ReadFromDb : IReadFromDb
    {
        public AirShoppContext _context = new AirShoppContext();

        public IQueryable<Cart> Carts
        {
            get
            {
                return _context.Cart;
            }
        }

        // public IQueryable<Category> Categories => _context.Category;

        public IQueryable<Category> Categories
        {
            get { return _context.Category; }
        }

        public IQueryable<Discount> Discounts
        {
            get
            {
                return _context.Discount;
            }
        }

        public IQueryable<Inventory> Inventories
        {
            get
            {
                return _context.Inventory;
            }
        }

        public IQueryable<InventoryAction> InventoryActions
        {
            get
            {
                return _context.InventoryAction;
            }
        }

        public IQueryable<ProductOutFactory> ProductOutFactories
        {
            get
            {
                return _context.ProductOutFactory;
            }
        }

        public IQueryable<Product> Products
        {
            get
            {
                return _context.Product;
            }
        }
    }
}
