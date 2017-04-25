using System.Collections.Generic;

namespace AirShopp.Domain
{
    public interface IDeliveryStationRepository
    {
        List<DeliveryStation> GetDeliveryStations(long areaId, int stationLevel);
        List<DeliveryStation> GetDeliveryStation(double lng, double lat);
    }
}
