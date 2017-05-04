namespace AirShopp.UI.Models
{
    public class ShopCartDataModel
    {
        public long ProductId { get; set; }
        public string PictureUrl { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int ProductAmount { get; set; }
        public int ProductCredit { get; set; }
        public int TotalPrice { get; set; }
    }
}