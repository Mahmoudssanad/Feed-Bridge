using FeedBridge_00.Models;
using FeedBridge_00.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace FeedBridge_00.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;
        private readonly ISession _session;

        private const string CartSessionKey = "Cart";

        public CartRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;
        }

        public void AddToCart(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) return;

            var cart = GetCartItems();

            var existingItem = cart.FirstOrDefault(x => x.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItemVM
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Image = product.Image,
                    Quantity = 1
                });
            }

            SaveCart(cart);
        }

        public List<CartItemVM> GetCartItems()
        {
            var json = _session.GetString(CartSessionKey);
            return string.IsNullOrEmpty(json)
                ? new List<CartItemVM>()
                : JsonSerializer.Deserialize<List<CartItemVM>>(json);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
        }

        public void SaveCart(List<CartItemVM> cart)
        {
            var json = JsonSerializer.Serialize(cart);
            _session.SetString(CartSessionKey, json);
        }

        public void UpdateQuantity(int productId, int newQuantity)
        {
            var cart = GetCartItems();

            var item = cart.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                if (newQuantity <= 0)
                {
                    cart.Remove(item); // لو الكمية أقل من أو تساوي صفر، احذف المنتج
                }
                else
                {
                    item.Quantity = newQuantity; // حدث الكمية
                }

                SaveCart(cart); // خزن التحديثات في Session
            }
        }

        public void IncreaseQuantity(int productId)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                item.Quantity++;
                SaveCart(cart);
            }
        }

        public void DecreaseQuantity(int productId)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                item.Quantity--;
                if (item.Quantity <= 0)
                {
                    cart.Remove(item); // احذف المنتج لو الكمية 0 أو أقل
                }
                SaveCart(cart);
            }
        }

        public void ConfirmOrder()
        {
            var cart = GetCartItems();

            if (cart.Any())
            {
                // ممكن هنا تنقل البيانات إلى جدول الطلبات في الداتابيز لو حابب
                // مثلاً: _context.Orders.Add(...);

                _session.Remove(CartSessionKey); // امسح السلة بعد التأكيد
            }
        }
    

    }
}

