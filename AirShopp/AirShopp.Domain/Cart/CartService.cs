using System;
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

        public List<Cart> LoadCartList(long customerId)
        {
            return _cartRepository.LoadCartList(customerId);
        }
        //TODO Cart_Kenneth
        /*
        public int GetProductAmoutByUser(long customerId)
        {
            int cartProductAmount = 0;
            if (customerId > 0)
            {
                cartProductAmount = (from cart in _readFromDb.Carts
                             where cart.CustomerId == customerId
                             select cart.Quantity
                         ).Sum();
            }
            return cartProductAmount;
        }
         * */
    }
}
