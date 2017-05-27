using System;
using AirShopp.Domain;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly AirShoppContext _context = new AirShoppContext();
        public void AddProductDiscount(Discount discount)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                _context.Discount.Add(discount);
                _context.SaveChanges();
            }
        }

        public void UpdateProductDiscount(long productId, decimal discounts)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                var d = _context.Discount.Where(dt => dt.ProductId == productId).FirstOrDefault();
                if (d != null)
                {
                    d.Discounts = discounts;
                    _context.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }
    }
}
