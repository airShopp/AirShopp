using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface IDeliveryInfoService
    {
        void AddDeliverInfo(DeliveryInfo deliveryInfo);
        List<DeliveryInfo> GetDeliveryInfo(long orderId);
        int GetMaxIndex(long orderId);
    }
}
