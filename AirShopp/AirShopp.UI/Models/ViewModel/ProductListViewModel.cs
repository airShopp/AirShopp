using System.Collections.Generic;

namespace AirShopp.UI.Models.ViewModel
{
    public class ProductListViewModel
    {
        public int Index { get; set; }
        public int PageCount { get; set; }
        public long CategoryId { get; set; }
        public List<ProductListDataModel> productList { get; set; }
    }
}