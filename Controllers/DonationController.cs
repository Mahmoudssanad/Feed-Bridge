using Microsoft.AspNetCore.Mvc;

namespace FeedBridge_00.Controllers
{
    public class DonationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
