using Microsoft.AspNetCore.Mvc;
using The_voice_of_geeta.DATA;
using The_voice_of_geeta.Models;

namespace The_voice_of_geeta.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // ✅ Display Active Users
        //public IActionResult ActiveUsers()
        //{
        //    var activeUsers = _context.Users.Where(u => u.IsActive).ToList();
        //    return View(activeUsers);
        //}

        public IActionResult ActiveUsers()
        {
            return View();
        }
        // ✅ Add New User (GET)
        //[HttpGet]
        //public IActionResult AddUser()
        //{
        //    return View();
        //}

        // ✅ Add New User (POST)
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddUser(Usermodel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.IsActive = true;  // Default to Active
        //        _context.Users.Add(model);
        //        _context.SaveChanges();
        //        return RedirectToAction("ActiveUsers");
        //    }
        //    return View(model);
        //}

        // ✅ Edit User (GET)
        //[HttpGet]
        //public IActionResult EditUser(int id)
        //{
        //    var user = _context.Users.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}

        // ✅ Edit User (POST)
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditUser(Usermodel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Users.Update(model);
        //        _context.SaveChanges();
        //        return RedirectToAction("ActiveUsers");
        //    }
        //    return View(model);
        //}

        // ✅ Delete User
        //[HttpPost]
        //public IActionResult DeleteUser(int id)
        //{
        //    var user = _context.Users.Find(id);
        //    if (user != null)
        //    {
        //        _context.Users.Remove(user);
        //        _context.SaveChanges();
        //    }
        //    return RedirectToAction("ActiveUsers");
        //}
    }
}
