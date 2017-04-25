using System;
namespace AirShopp.Domain
{
    public interface IOrderItemRepository
    {
        DateTime GetBuyTimeByProductId (long productId);
    }
}
