using AirShopp.UI.Models.Common;
using System.Collections.Generic;

namespace AirShopp.UI.Models.ViewModel
{
    public class ProductListViewModel : PageListBaseModel
    {
        public long CategoryId { get; set; }
        public List<ProductListDataModel> productList { get; set; }
    }
}