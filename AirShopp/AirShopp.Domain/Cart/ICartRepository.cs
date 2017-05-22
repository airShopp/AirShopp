namespace AirShopp.Domain
{
    public interface ICartRepository
    {
        long AddCart(Cart cart);
        void DeleteCartProduct(long cartId);
    }
}
