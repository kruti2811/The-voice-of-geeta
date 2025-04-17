using Microsoft.AspNetCore.Mvc;
using The_voice_of_geeta.Areas.Admin.Models;
using The_voice_of_geeta.DATA;

namespace The_voice_of_geeta.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShlokasController : Controller
    {
        private readonly DataContext _context;

        public ShlokasController(DataContext context)
        {
            _context = context;
        }

        // GET: Display all shlokas
        public IActionResult DailyShlokas()
        {
            var shlokas = _context.Shlokas.ToList();
            return View(shlokas);
        }

        // GET: Show Add form
        public IActionResult AddShlokas()
        {
            return View();
        }

        [HttpPost]
        // Temporarily comment this out for testing if needed
        // [ValidateAntiForgeryToken]
        public IActionResult AddShlokas(Shloka model)
        {
            Console.WriteLine("Form submitted:");
            Console.WriteLine("Adhyay: " + model.AdhyayNumber);
            Console.WriteLine("Shloka: " + model.ShlokaDescription);

            if (ModelState.IsValid)
            {
                _context.Shlokas.Add(model);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Shloka added successfully!";
                return RedirectToAction("DailyShlokas");
            }

            return View(model);
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Show(int id)
        {
            // Hide all shlokas
            var allShlokas = _context.Shlokas.ToList();
            foreach (var s in allShlokas)
            {
                s.IsVisible = false;
            }

            // Show the selected one
            var shloka = _context.Shlokas.Find(id);
            if (shloka != null)
            {
                shloka.IsVisible = true;
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Shloka is now visible.";
            }

            return RedirectToAction("DailyShlokas");
        }


        [HttpPost]
        public IActionResult Hide(int id)
        {
            var shloka = _context.Shlokas.Find(id);
            if (shloka != null)
            {
                shloka.IsVisible = false;
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Shloka is now hidden.";
            }
            return RedirectToAction("DailyShlokas");
        }

    }
}
