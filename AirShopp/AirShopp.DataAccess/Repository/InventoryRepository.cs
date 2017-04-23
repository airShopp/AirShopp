using AirShopp.Domain;
using System;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AirShoppContext _context = new AirShoppContext();

        public int GetProductAmountByProductId(long productId)
        {
            var inventory = _context.Inventory.Where(I => I.ProductId == productId).FirstOrDefault();
            return inventory.Amount;
        }
    }
}
