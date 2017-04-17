using System;
using System.Collections.Generic;
using AirShopp.Domain;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly AirShoppContext _context = new AirShoppContext();

        public List<Category> GetCategories()
        {
            List<Category> CategoryList = new List<Category>();
            _context.Category.Where(c => c.ParentId == 0).ToList().ForEach(category =>
            {
                CategoryList.Add(new Category
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                });
            });
            return CategoryList;
        }
    }
}
