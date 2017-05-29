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

        public IQueryable<Comment> Comments
        {
            get
            {
                return _context.Comments;
            }
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

        public IQueryable<ProductSales> ProductSales
        {
            get
            {
                return _context.ProductSales;
            }
        }

        public IQueryable<Order> Orders
        {
            get
            {
                return _context.Order;
            }
        }
        public IQueryable<OrderItem> OrderItems
        {
            get
            {
                return _context.OrderItem;
            }
        }

        public IQueryable<CartItem> CartItems
        {
            get
            {
                return _context.CartItem;
            }
        }

        public IQueryable<Address> Address
        {
            get
            {
                return _context.Address;
            }
        }
        public IQueryable<Customer> Customers
        {
            get
            {
                return _context.Customer;
            }
        }

        public IQueryable<Province> Provinces
        {
            get
            {
                return _context.Province;
            }
        }

        public IQueryable<Area> Areas
        {
            get
            {
                return _context.Area;
            }
        }

        public IQueryable<City> Cities
        {
            get
            {
                return _context.City;
            }
        }

        public IQueryable<DeliveryStation> DeliveryStations
        {
            get
            {
                return _context.DeliveryStation;
            }
        }

        public IQueryable<DeliveryOrder> DeliveryOrders
        {
            get
            {
                return _context.DeliveryOrder;
            }
        }

        public IQueryable<DeliveryNote> DeliveryNotes
        {
            get
            {
                return _context.DeliveryNote;
            }
        }
        public IQueryable<Warehouse> Warehouses
        {
            get
            {
                return _context.Warehouse;
            }
        }

        public IQueryable<Provider> Providers
        {
            get
            {
                return _context.Provider;
            }
        }

        public IQueryable<Return> Returns
        {
            get
            {
                return _context.Return;
            }
        }

        public IQueryable<ProductInFactory> ProductInFactories
        {
            get
            {
                return _context.ProductInFactory;
            }
        }
        public IQueryable<Admin> Admins
        {
            get
            {
                return _context.Admin;
            }
        }
    }
}
