using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
