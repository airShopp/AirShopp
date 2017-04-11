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
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public List<Cart> LoadCartList(long customerId)
        {
            return _cartRepository.LoadCartList(customerId);
        }
    }
}
