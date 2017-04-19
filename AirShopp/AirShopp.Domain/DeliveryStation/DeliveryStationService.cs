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

        public List<DeliveryStation> GetDeliveryStation(long areaId, int stationLevel)
        {
            return _deliveryStationRepository.GetDeliveryStation(areaId, stationLevel);
        }
    }
}
