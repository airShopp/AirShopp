using System.Collections.Generic;

namespace AirShopp.Domain
{
    public interface IDeliveryStationRepository
    {
        List<DeliveryStation> GetDeliveryStation(long areaId, int stationLevel);
    }
}
