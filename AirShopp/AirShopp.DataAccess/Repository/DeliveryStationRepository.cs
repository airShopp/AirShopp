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

        public List<DeliveryStation> GetDeliveryStation(long areaId)
        {
            return _context.DeliveryStation.Where(x => x.AreaId == areaId).ToList();
        }
        /*
        public void AddDeliveryStation(DeliveryStation deliveryStation)
        {
            _context.DeliveryStation.Add(deliveryStation);
            _context.SaveChanges();
        }

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
