using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using The_voice_of_geeta.Models;

namespace The_voice_of_geeta.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
