using System.Collections.Generic;

namespace AirShopp.Domain
{
    public interface IWarehouseRepository
    {
        List<Warehouse> getWarehouseList();
    }
}
