using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class CourierRepository : ICourierRepository
    {
        public AirShoppContext _context = new AirShoppContext();

        public List<Courier> GetCouriers(long deliveryStationId)
        {
            return _context.Courier.Where(x => x.DeliveryStationId == deliveryStationId).ToList();
        }

        public void AddCourier(Courier courier)
        {
            _context.Courier.Add(courier);
            _context.SaveChanges();
        }

        public void DeleteCourier(long courierId)
        {
            Courier courier = _context.Courier.Where(x => x.Id == courierId).ToList().FirstOrDefault();
            _context.Entry<Courier>(courier).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
