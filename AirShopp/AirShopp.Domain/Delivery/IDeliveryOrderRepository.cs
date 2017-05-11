using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface IDeliveryOrderRepository
    {
        List<DeliveryOrder> GetDeliveryOrders();
        long AddDeliveryOrder(DeliveryOrder deliveryOrder);
        long GetMaxDeliveryOrderId();
        string GetMaxDeliveryOrderNumber(string beginSerialNumber);
        DeliveryOrder GetDeliveryOrderByPK(long deliveryOrderId);
    }
}
