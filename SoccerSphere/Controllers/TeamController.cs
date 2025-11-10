using Microsoft.AspNetCore.Mvc;
using SoccerSphere.Models;

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
