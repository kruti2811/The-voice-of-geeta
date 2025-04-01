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

        // GET: Login Page
        [HttpGet]
        public IActionResult login() => View();

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Store user session
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Dashboard", "Home"); // Redirect to Home Dashboard
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

        // Logout Functionality
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }
}
