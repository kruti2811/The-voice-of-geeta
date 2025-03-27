using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using The_voice_of_geeta.Models;

namespace The_voice_of_geeta.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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
    }
}
