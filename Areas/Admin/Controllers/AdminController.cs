using Microsoft.AspNetCore.Mvc;

namespace The_voice_of_geeta.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashborad()
        {
            return View();
        }public IActionResult ActiveUsers()
        {
            return View();
        }
        public IActionResult DailyShlokas()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
