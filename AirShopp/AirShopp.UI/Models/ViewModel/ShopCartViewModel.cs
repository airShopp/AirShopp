using AirShopp.Domain;
using AirShopp.UI.Models.Common;
using System.Collections.Generic;

namespace AirShopp.UI.Models.ViewModel
{
    public class ShopCartViewModel : PageListBaseModel
    {
        public Product Product { get; set; }
        public int ProductAmount { get; set; }
        public int TotalPrice { get; set; }
    }
}