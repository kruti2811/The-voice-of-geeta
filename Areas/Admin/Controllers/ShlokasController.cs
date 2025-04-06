using Microsoft.AspNetCore.Mvc;
using The_voice_of_geeta.Areas.Admin.Models;
using The_voice_of_geeta.DATA;

namespace The_voice_of_geeta.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShlokasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly DataContext _context;

        public ShlokasController(DataContext context)
        {
            _context = context;
        }

        public IActionResult DailyShlokas()
        {
            //var shlokas = _context.Shlokas.ToList();
            //return View(shlokas);
            return View();
        }

        public IActionResult AddShlokas()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddShlokas(Shloka model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Shlokas.Add(model);
        //        _context.SaveChanges();
        //        return RedirectToAction("DailyShlokas");
        //    }
        //    return View(model);
        //}
    }
}
