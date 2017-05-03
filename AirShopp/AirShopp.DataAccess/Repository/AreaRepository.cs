using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirShopp.DataAccess
{
    public class AreaRepository : IAreaRepository
    {
        public AirShoppContext _context = new AirShoppContext();

        public List<Area> GetArea()
        {
            return _context.Area.ToList();
        }

        public Area GetAreaById(long areaId)
        {
            return _context.Area.Where(x => x.Id == areaId).ToList().FirstOrDefault();
        }
    }
}
