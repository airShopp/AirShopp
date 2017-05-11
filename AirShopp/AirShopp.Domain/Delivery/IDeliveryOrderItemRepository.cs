using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface IDeliveryOrderItemRepository
    {
        List<DeliveryOrderItem> GetDeliveryOrderItems(long deliveryOrderId);
        void AddDeliveryOrderItem(DeliveryOrderItem deliveryOrderItems);
    }
}
