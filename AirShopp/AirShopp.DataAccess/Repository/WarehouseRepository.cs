using System;
using System.Collections.Generic;
using AirShopp.Domain;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class WarehouseRepository : IWarehouseRepository
    {
        public readonly AirShoppContext _context = new AirShoppContext();
        public List<Warehouse> getWarehouseList()
        {
            return _context.Warehouse.ToList();
        }
    }
}
