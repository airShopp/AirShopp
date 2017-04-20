using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class HomeViewModel
    {
        public int CartProductAccount { get; set; }
        public List<Category> Categories { get; set; }
        public List<CategoryModel> SecondCategories { get; set; }
        public List<ProductDataModel> HotProducts { get; set; }
        public List<Product> TimeLimitProduct { get; set; }
    }
}