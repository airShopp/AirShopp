using System.Collections.Generic;

namespace AirShopp.Domain
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        string GetCategoryNameByChildcategoryId(long childCategoryid);
        string GetCategoryNameByProductId(long productId);
    }
}
