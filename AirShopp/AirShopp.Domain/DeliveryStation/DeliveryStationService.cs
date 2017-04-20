using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class DeliveryStationService : IDeliveryStationService
    {
        public IDeliveryStationRepository _deliveryStationRepository;
        public DeliveryStationService(IDeliveryStationRepository deliveryStationRepository)
        {
            _deliveryStationRepository = deliveryStationRepository;
        }

        public List<DeliveryStation> GetDeliveryStations(long areaId, int stationLevel)
        {
            return _deliveryStationRepository.GetDeliveryStations(areaId, stationLevel);
        }

        public DeliveryStation GetDeliveryStation(double lng, double lat)
        {
            DeliveryStation deliveryStation = null;
            List<DeliveryStation> deliveryStationList =  _deliveryStationRepository.GetDeliveryStation(lng, lat);
            if (deliveryStationList != null)
            {
                deliveryStation = deliveryStationList.FirstOrDefault();
            }
            return deliveryStation;
        }
    }
}
