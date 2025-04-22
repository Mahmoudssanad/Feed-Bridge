using Microsoft.AspNetCore.Mvc;

namespace FeedBridge_00.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
