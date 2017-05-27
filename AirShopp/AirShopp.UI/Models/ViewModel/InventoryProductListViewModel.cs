using AirShopp.Domain;
using AirShopp.UI.Models.Common;
using System.Collections;
using System.Collections.Generic;

namespace AirShopp.UI.Models.ViewModel
{
    public class InventoryProductListViewModel : PageListBaseModel
    {
        public List<InventoryProductListDataModel> productList { get; set; }
        public List<Provider> providerList { get; set; }
        public List<Warehouse> warehouseList { get; set; }
        public List<CategoryModel> categoryList { get; set; }
    }
}