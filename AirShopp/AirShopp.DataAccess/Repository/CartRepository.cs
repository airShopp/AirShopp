using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class CartRepository : ICartRepository
    {
        //public readonly AirShoppContext _context = new AirShoppContext();
        public CartRepository()
        {

        }
        public long AddCart(Cart cart)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                long cartId = 0;
                bool isExistCustomer = false;
                foreach (var c in _context.Cart.ToList())
                {
                    if (c.CustomerId == cart.CustomerId)
                    {
                        cartId = c.Id;
                        isExistCustomer = true;
                        break;
                    }
                }
                if (isExistCustomer == false)
                {
                    _context.Cart.Add(cart);
                    _context.SaveChanges();
                    cartId = cart.Id;
                }
                return cartId;
            }
        }

        public void DeleteCartProduct(long cartItemId)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                var cartItem = _context.CartItem.Find(cartItemId);
                if (cartItem != null)
                {
                    _context.CartItem.Remove(cartItem);
                    _context.SaveChanges();
                }
            }
        }
    }
}
