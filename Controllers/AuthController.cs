using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_voice_of_geeta.DATA;
using The_voice_of_geeta.Models;
using Microsoft.AspNetCore.Http;

namespace The_voice_of_geeta.Controllers
{
    public class AuthController : Controller
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        // GET: Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            // 🔐 1. Admin Shortcut Login
            if (username == "Kruti28" && password == "KrutiPatel")
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            // 🔐 2. Regular User Login via Database
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user != null && user.Password == password) // ⚠️ Use Hashing in Production
            {
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "Home"); // Redirect to User Dashboard
            }

            ViewBag.Error = "Invalid username or password!";
            return View();
        }

        // GET: Register Page
        [HttpGet]
        public IActionResult Register() => View();

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Usermodel model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(model);
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: Edit Profile
        [HttpGet]
        public IActionResult EditProfile()
        {
            string username = HttpContext.Session.GetString("Username");
            if (username == null)
            {
                return RedirectToAction("Login");
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Save Profile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfile(Usermodel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == model.UserId);
                if (user == null)
                {
                    return NotFound();
                }

                user.Username = model.Username;
                user.Email = model.Email;
                user.Password = model.Password; // ⚠️ Hash in production

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToAction("EditProfile");
            }

            return View(model);
        }
    }
}
