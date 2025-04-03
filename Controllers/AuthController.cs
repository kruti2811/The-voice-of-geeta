using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_voice_of_geeta.DATA;
using The_voice_of_geeta.Models;

namespace The_voice_of_geeta.Controllers
{
    public class AuthController : Controller
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user != null && user.Password == password) // ⚠️ Use Hashing in Production
            {
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "Home"); // Redirect to Dashboard
            }
            else
            {
                ViewBag.Error = "Invalid username or password.";
                return View();
            }
        }

        // GET: Register Page
        [HttpGet]
        public IActionResult register() => View();

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult register(Usermodel model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges();

                // Redirect to login page after successful registration
                return RedirectToAction("login");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear user session
            return RedirectToAction("login"); // Redirect to login page
        }
    }
}
