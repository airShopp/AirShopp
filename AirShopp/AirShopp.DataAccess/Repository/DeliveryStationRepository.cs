using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class DeliveryStationRepository : IDeliveryStationRepository
    {
        public AirShoppContext _context = new AirShoppContext();

        public List<DeliveryStation> GetDeliveryStations(long areaId, int stationLevel)
        {
            return _context.DeliveryStation.Where(x => (x.AreaId == areaId && x.StationLevel == stationLevel)).ToList();
        }

        public List<DeliveryStation> GetInitDeliveryStations()
        {
            return null;
        }

        public List<DeliveryStation> GetDeliveryStation(double lng, double lat)
        {
            return _context.DeliveryStation.Where(x => (x.Longitude == lng && x.Latitude == lat)).ToList();
        }

        public void AddDeliveryStation(DeliveryStation deliveryStation)
        {
            _context.DeliveryStation.Add(deliveryStation);
            _context.SaveChanges();
        }

        public long GetParentDeliveryStation(string name)
        {
            long id = 0;
            List<DeliveryStation> deliveryStationList = _context.DeliveryStation.Where(x => x.Name.Contains(name)).ToList();
            if (deliveryStationList != null || deliveryStationList.Count > 0)
            {
                id = deliveryStationList.FirstOrDefault().Id;
            }

            return id;
        }
        /*
        public void UpdateDeliveryStation(DeliveryStation deliveryStation)
        {
            _context.Entry<DeliveryStation>(deliveryStation).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteDeliveryStation(long deliveryStationId)
        {
            var address = _context.DeliveryStation.Find(deliveryStationId);
            _context.Entry<DeliveryStation>(address).State = EntityState.Deleted;
            _context.SaveChanges();
        }
         * */
    }
}
