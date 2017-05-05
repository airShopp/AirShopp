using AirShopp.Domain;
using AirShopp.UI.Models.Common;
using System.Collections.Generic;

namespace AirShopp.UI.Models.ViewModel
{
    public class ShopCartViewModel : PageListBaseModel
    {
        public List<ShopCartDataModel> ShopCart { get; set; }
    }
}