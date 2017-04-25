using AirShopp.UI.Models.Common;

namespace AirShopp.UI.Models.ViewModel
{
    public class ProductViewModel : PageListBaseModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int DiscountedPricre { get; set; }
        public double Discount { get; set; }
        public string CommentAmount { get; set; } //Comment => Count(productId = ?);
    }
}