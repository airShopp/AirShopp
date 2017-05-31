using AirShopp.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class CartService:ICartService
    {
        public ICartRepository _cartRepository;
        public IReadFromDb _readFromDb;
        public CartService(
            ICartRepository cartRepository,
            IReadFromDb readFromDb)
        {
            _cartRepository = cartRepository;
            _readFromDb = readFromDb;
        }

        public IQueryable LoadCartList(long customerId)
        {
            var CartList = (from ci in _readFromDb.CartItems
                            join c in _readFromDb.Carts on ci.CartId equals c.Id
                            join ct in _readFromDb.Customers on c.CustomerId equals ct.Id
                            join p in _readFromDb.Products on ci.ProductId equals p.Id
                            where ct.Id == customerId
                            select new
                            {
                                p.Id,
                                p.ProductName,
                                p.Url,
                                p.Price,
                                ci.Quantity
                            });
            return CartList;
        }
        //TODO Cart_Kenneth

        public int GetProductAmoutByUser(long customerId)
        {
            int cartProductAmount = 0;
            if (customerId > 0)
            {
                cartProductAmount = (from cartItem in _readFromDb.CartItems
                                     join cart in _readFromDb.Carts on cartItem.CartId equals cart.Id
                                     where cart.CustomerId == customerId && cartItem.ItemStatus == Constants.PENDING
                                     select cartItem.Id
                         ).Count();
            }
            return cartProductAmount;
        }
        
    }
}
