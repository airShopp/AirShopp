using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class DeliveryOrderItemRepository : IDeliveryOrderItemRepository
    {
        private AirShoppContext _context = new AirShoppContext();

        public List<DeliveryOrderItem> GetDeliveryOrderItems(long deliveryOrderId)
        {
            return _context.DeliveryOrderItem.Where(x => x.DeliveryOrderId == deliveryOrderId).ToList();
        }

        public void AddDeliveryOrderItem(DeliveryOrderItem deliveryOrderItem)
        {
            _context.DeliveryOrderItem.Add(deliveryOrderItem);
            _context.SaveChanges();
        }
    }
}
