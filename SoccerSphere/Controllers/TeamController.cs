using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerSphere.Data;
using SoccerSphere.Models;

namespace SoccerSphere.Controllers
{
    public class TeamController : Controller
    {
        private TeamContext _context;
        public TeamController(TeamContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Players");
        }

        public IActionResult Players()
        {
            var players = _context.players.Include(p => p.Team).
             Where(p => p.Team.TeamId == p.TeamId).OrderByDescending(p => p.Goals).ToList();

            var model = new PlayerTeamViewModel
            {
                Players = players
            };

            return View(model);
        }


    }
}
