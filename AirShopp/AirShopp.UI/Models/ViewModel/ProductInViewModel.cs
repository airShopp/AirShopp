using AirShopp.UI.Models.Common;
using System.Collections.Generic;

namespace AirShopp.UI.Models.ViewModel
{
    public class ProductInViewModel : PageListBaseModel
    {
        public List<ProductInDataModel> ProductDataList { get; set; }
    }
}