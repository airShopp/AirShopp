using AirShopp.Common.Page;
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
            PageList<Category> CategoryAfterPaging = Pagination.ToPagedList(_readFromDb.Categories.OrderBy(e => e.Id), 2 , 5);
            int t = CategoryAfterPaging.PageIndex;
            int a = CategoryAfterPaging.PageSize;
            return categories;
        }
    }
}
