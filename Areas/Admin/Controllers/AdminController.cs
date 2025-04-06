using Microsoft.AspNetCore.Mvc;

namespace The_voice_of_geeta.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            // You can fetch actual user data from session/database if needed
            return View();
        }


    }
}
