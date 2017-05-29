using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.Domain
{
    public interface ICourierRepository
    {
        List<Courier> GetCouriers(long deliveryStationId);
        void AddCourier(Courier courier);
        void DeleteCourier(long courierId);
    }
}
