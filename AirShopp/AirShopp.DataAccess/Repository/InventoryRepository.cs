using AirShopp.Domain;
using System;
using System.Linq;

namespace AirShopp.DataAccess
{
    public class InventoryRepository : IInventoryRepository
    {
        public long AddInventory(Inventory inventory)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                _context.Inventory.Add(inventory);
                _context.SaveChanges();
                return inventory.Id;
            }
                
        }

        public void AddInventoryAction(InventoryAction inventoryAction)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                _context.InventoryAction.Add(inventoryAction);
                _context.SaveChanges();
            }
        }

        public long AddProductInFactory(ProductInFactory productInFactory)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                _context.ProductInFactory.Add(productInFactory);
                _context.SaveChanges();
                return productInFactory.Id;
            }
        }

        public int GetProductAmountByProductId(long productId)
        {
            using (AirShoppContext _context = new AirShoppContext())
            {
                var inventory = _context.Inventory.Where(I => I.ProductId == productId).FirstOrDefault();
                return inventory.Amount;
            }
                
        }
    }
}
