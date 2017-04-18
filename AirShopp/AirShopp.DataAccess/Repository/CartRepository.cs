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
        public List<Cart> LoadCartList(long customerId) 
        {
            List<Cart> cartList = new List<Cart>();

            cartList.Add(new Cart()
            {
                CustomerId = 1,
                Quantity = 20,
                ProductId = 1
            });
            cartList.Add(new Cart()
            {
                CustomerId = 1,
                Quantity = 20,
                ProductId = 2
            });
            cartList.Add(new Cart()
            {
                CustomerId = 1,
                Quantity = 20,
                ProductId = 3
            });

            return cartList;
        }
    }
}
