using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface IDeliveryStationService
    {
        List<DeliveryStation> GetDeliveryStations(long areaId, int stationLevel);
        DeliveryStation GetDeliveryStation(double lng, double lat);
    }
}
