namespace AirShopp.Domain
{
    public class Discount
    {
        public long Id { get; set; }
        public string CustomerLevel { get; set; }
        public decimal Discounts { get; set; }
        public string ScoreRequire { get; set; }
    }
}
