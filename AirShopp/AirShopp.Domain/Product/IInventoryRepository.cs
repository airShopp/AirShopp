namespace AirShopp.Domain
{
    public interface IInventoryRepository
    {
        int GetProductAmountByProductId(long productId);
    }
}
