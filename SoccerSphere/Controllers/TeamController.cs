using Microsoft.AspNetCore.Mvc;
using SoccerSphere.Models;

namespace SoccerSphere.Controllers
{
    public class TeamController : Controller
    {
        private TeamContext ctx;
        public TeamController(TeamContext teamContext)
        {
            ctx = teamContext;
        }
        public IActionResult Index()
        {
            var teams = ctx.teams.ToList();

            return View(teams);
        }
    }
}
