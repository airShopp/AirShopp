using AirShopp.Domain;
using System;
using System.Collections.Generic;
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
    }
}
