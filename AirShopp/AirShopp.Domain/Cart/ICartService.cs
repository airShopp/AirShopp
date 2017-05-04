using System.Linq;

namespace AirShopp.Domain
{
    public interface ICartService
    {
        IQueryable LoadCartList(long CustomerId);
        //TODO Cart_Kenneth
        int GetProductAmoutByUser(long customerId);
    }
}
