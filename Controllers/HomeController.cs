using Microsoft.AspNetCore.Mvc;
using The_voice_of_geeta.DATA;
using System.Linq;
using The_voice_of_geeta.Models;

namespace The_voice_of_geeta.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.DailyShloka = _context.Shlokas.FirstOrDefault(s => s.IsVisible == true);

            var latestVisibleShloka = _context.Shlokas
        .Where(s => s.IsVisible)
        .OrderByDescending(s => s.Id) // You can also use CreatedDate if available
        .FirstOrDefault();

            ViewBag.DailyShloka = latestVisibleShloka;

            return View();
        }

        public IActionResult Adhyay()
        {
            return View();
        }

        public IActionResult ShlokaList(int id)
        {
            ViewBag.AdhyayId = id;
            return View();
        }

        public IActionResult Vedas()
        {
            return View();
        }

        public IActionResult Teachings()
        {
            return View();
        }

        public IActionResult Editprofile()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetVisibleShloka()
        {
            var shloka = _context.Shlokas.FirstOrDefault(s => s.IsVisible == true);

            if (shloka != null)
            {
                return Json(new
                {
                    success = true,
                    adhyay = shloka.AdhyayNumber,
                    description = shloka.ShlokaDescription
                });
            }

            return Json(new { success = false });
        }

    }
}