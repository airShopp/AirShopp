using System;
using AirShopp.Domain;
using System.Data.Entity;
using AirShopp.Common;

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

        public void UpdateCartItem(long cartItemId)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                CartItem cartItem = _context.CartItem.Find(cartItemId);
                cartItem.ItemStatus = Constants.BOUGHT;
                _context.Entry<CartItem>(cartItem).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
