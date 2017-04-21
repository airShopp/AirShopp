using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class DeliveryInfoService : IDeliveryInfoService
    {
        private IDeliveryInfoRepository _deliveryInfoRepository;
        public DeliveryInfoService(IDeliveryInfoRepository deliveryInfoRepository)
        {
            _deliveryInfoRepository = deliveryInfoRepository;
        }

        public void AddDeliverInfo(DeliveryInfo deliveryInfo)
        {
            _deliveryInfoRepository.AddDeliverInfo(deliveryInfo);
        }

        public List<DeliveryInfo> GetDeliveryInfo(long orderId)
        {
            return _deliveryInfoRepository.GetDeliveryInfo(orderId);
        }

        public List<DeliveryInfo> GetDeliveryInfoInRange(long orderId, int beginIndex)
        {
            return _deliveryInfoRepository.GetDeliveryInfoInRange(orderId, beginIndex);
        }

        public int GetMaxIndex(long orderId)
        {
            return _deliveryInfoRepository.GetMaxIndex(orderId);
        }
    }
}
