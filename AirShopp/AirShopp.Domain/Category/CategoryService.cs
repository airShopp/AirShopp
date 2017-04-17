using System.Linq;

namespace AirShopp.Domain
{
    public class CategoryService : ICategoryService
    {
        public IReadFromDb _readFromDb;
        public CategoryService(IReadFromDb readFromDb)
        {
            _readFromDb = readFromDb;
        }
        public IQueryable<Category> Categories()
        {
            var categories = (from category in _readFromDb.Categories
                              select category);
            return categories;
        }
    }
}
