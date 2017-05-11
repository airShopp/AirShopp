using AirShopp.UI.Models.Common;
using System.Collections.Generic;

namespace AirShopp.UI.Models.ViewModel
{
    public class InventoryProductListViewModel : PageListBaseModel
    {
        public List<InventoryProductListDataModel> productList { get; set; }
    }
}