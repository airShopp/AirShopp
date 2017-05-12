using System;
using AirShopp.Domain;

namespace AirShopp.DataAccess
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly AirShoppContext _context = new AirShoppContext();
        public void AddProductDiscount(Discount discount)
        {
            _context.Discount.Add(discount);
            _context.SaveChanges();
        }
    }
}
