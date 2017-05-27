namespace AirShopp.Domain
{
    public interface IInventoryRepository
    {
        int GetProductAmountByProductId(long productId);
        long AddInventory(Inventory inventory);
        long AddProductInFactory(ProductInFactory productInFactory);
        void AddInventoryAction(InventoryAction inventoryAction);
    }
}
