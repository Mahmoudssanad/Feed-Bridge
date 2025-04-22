using FeedBridge_00.ViewModels;

namespace FeedBridge_00.Repository
{
    public interface ICartRepository
    {
        void UpdateQuantity(int productId, int quantity);
        void RemoveFromCart(int productId);
        void AddToCart(int Id);
        void SaveCart(List<CartItemVM> cart);
        List<CartItemVM> GetCartItems();

        public void IncreaseQuantity(int productId);
        public void DecreaseQuantity(int productId);
        public void ConfirmOrder();
    }
}
