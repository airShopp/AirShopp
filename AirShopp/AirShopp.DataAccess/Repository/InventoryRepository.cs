using AirShopp.Domain;
using System;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AirShoppContext _context = new AirShoppContext();

        public long AddInventory(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            _context.SaveChanges();
            return inventory.Id;
        }

        public int GetProductAmountByProductId(long productId)
        {
            var inventory = _context.Inventory.Where(I => I.ProductId == productId).FirstOrDefault();
            return inventory.Amount;
        }
    }
}
