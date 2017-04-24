using AirShopp.Domain;
using System;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AirShoppContext _context = new AirShoppContext();
        public DateTime GetBuyTimeByProductId(long productId)
        {
            DateTime buyTime = DateTime.UtcNow;
            var orderItem = _context.OrderItem.Where(o => o.ProductId == productId).FirstOrDefault();
            if(orderItem != null)
            {
                buyTime = orderItem.OrderDate;
            }
            return buyTime;
        }
    }
}
