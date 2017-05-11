namespace AirShopp.Domain
{
    public interface ICartItemRepository
    {
        void AddCartItem(CartItem cartItem);
        void UpdateCartItem(long cartItemId);
    }
}
