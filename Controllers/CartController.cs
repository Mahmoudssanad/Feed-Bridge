using FeedBridge_00.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;

namespace FeedBridge_00.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [Authorize]
        public IActionResult Show()
        {
            var cartItems = _cartRepository.GetCartItems();
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            try
            {
                // أضف المنتج إلى السلة
                _cartRepository.AddToCart(productId);

                // أرجاع استجابة ناجحة
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // إذا حدث استثناء
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Update(int productId, int quantity)
        {
            _cartRepository.UpdateQuantity(productId, quantity);
            return RedirectToAction("Show");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            _cartRepository.RemoveFromCart(productId);
            return RedirectToAction("Show", "Cart");
        }

        [HttpPost]
        public IActionResult IncreaseQuantity(int productId)
        {
            _cartRepository.IncreaseQuantity(productId);
            return RedirectToAction("Show");
        }

        [HttpPost]
        public IActionResult DecreaseQuantity(int productId)
        {
            _cartRepository.DecreaseQuantity(productId);
            return RedirectToAction("Show");
        }

        [HttpPost]
        public IActionResult ConfirmOrder()
        {
            var cartItems = _cartRepository.GetCartItems();

            // تحقق مما إذا كانت السلة فارغة
            if (cartItems == null || !cartItems.Any())
            {
                // إرجاع رسالة تفيد بأنه لا يوجد أي منتجات في السلة
                TempData["ErrorMessage"] = "لا يوجد طلبات في السلة. من فضلك أضف بعض المنتجات إلى السلة.";
                return RedirectToAction("AllProducts", "Product");  // العودة إلى صفحة المنتجات أو السلة
            }

            // تأكيد الطلب
            try
            {
                _cartRepository.ConfirmOrder();  // يقوم بتأكيد الطلب وتفريغ السلة
                TempData["SuccessMessage"] = "تم تأكيد طلبك بنجاح!";
                return RedirectToAction("OrderSuccess");  // التوجه إلى صفحة تأكيد الطلب
            }
            catch (Exception ex)
            {
                // في حال حدوث أي خطأ أثناء تأكيد الطلب
                TempData["ErrorMessage"] = "حدث خطأ أثناء تأكيد الطلب. من فضلك حاول مرة أخرى.";
                return RedirectToAction("AllProducts", "Product");
            }
        }

        public IActionResult OrderSuccess()
        {
            return View();
        }

    }
}
