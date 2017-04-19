using System.Linq;
using AirShopp.Domain;

namespace AirShopp.DataAccess
{
    public class ReadFromDb : IReadFromDb
    {
        public AirShoppContext _context = new AirShoppContext();

        // public IQueryable<Category> Categories => _context.Category;

        public IQueryable<Category> Categories
        {
            get { return _context.Category; }
        }
    }
}
