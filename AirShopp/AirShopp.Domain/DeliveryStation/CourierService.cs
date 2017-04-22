using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public class CourierService : ICourierService
    {
        private ICourierRepository _courierRepository;
        public CourierService(ICourierRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }

        public Courier GetCourier(long deliveryStationId)
        {
            Courier courier = null;
            List<Courier> courierList = _courierRepository.GetCouriers(deliveryStationId);
            if (courierList != null)
            {
                courier = courierList[(new Random()).Next(courierList.Count)];
            }
            return courier;
        }
    }
}
