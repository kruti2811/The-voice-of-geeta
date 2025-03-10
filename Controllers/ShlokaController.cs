using Microsoft.AspNetCore.Mvc;

namespace The_voice_of_geeta.Controllers
{
    public class ShlokaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
