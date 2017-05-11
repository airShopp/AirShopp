using AirShopp.UI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class ProductOutFactoryViewModel : PageListBaseModel
    {
        public List<ProductOutDataModel> outList { get; set; }
    }
}