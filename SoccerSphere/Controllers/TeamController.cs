using Microsoft.AspNetCore.Mvc;

namespace SoccerSphere.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
