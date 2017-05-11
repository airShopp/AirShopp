﻿using System.Collections.Generic;

namespace AirShopp.Domain
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        string GetCategoryNameByChildcategoryId(long childCategoryid);
    }
}
