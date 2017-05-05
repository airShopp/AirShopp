using System;
using AirShopp.Domain;

namespace AirShopp.DataAccess
{
    public class CartItemRepository : ICartItemRepository
    {
        public void AddCartItem(CartItem cartItem)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                _context.CartItem.Add(cartItem);
                _context.SaveChanges();
            }
        }
    }
}
