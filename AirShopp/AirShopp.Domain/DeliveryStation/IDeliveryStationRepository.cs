using System.Collections.Generic;

namespace AirShopp.Domain
{
    public interface IDeliveryStationRepository
    {
        DeliveryStation GetDeliveryStation(long deliveryStationId);
        List<DeliveryStation> GetDeliveryStations(long areaId, int stationLevel);
        List<DeliveryStation> GetDeliveryStation(double lng, double lat);
        void AddDeliveryStation(DeliveryStation deliveryStation);
        long GetParentDeliveryStation(string name);
    }
}
