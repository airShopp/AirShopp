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
            _context.Category.Where(e => e.ParentId == 0).ToList().ForEach(category =>
            {
                CategoryList.Add(new Category
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                });
            });
            return CategoryList;
        }

        public string GetCategoryNameByChildcategoryId(long childCategoryid)
        {
            Category category = null;
            string categoryName = null;
            long parentId = 0;
            _context.Category.Where(e => e.Id == childCategoryid).ToList().ForEach(c =>
            {
                category = new Category()
                {
                    Id = c.Id,
                    ParentId = c.ParentId
                };
            });
            _context.Category.Where(e => e.Id == parentId).ToList().ForEach(c =>
            {
                categoryName = c.CategoryName;
            });
            return categoryName;
        }
    }
}
