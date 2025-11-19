using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerSphere.Models;

namespace SoccerSphere.Controllers
{
    public class TeamController : Controller
    {
        private TeamContext _ctx;
        public TeamController(TeamContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            var players = _ctx.players.Include(p=>p.Team).ToList();
            return View(players);
        }
        [HttpGet]
        public IActionResult AddPlayer()
        {
            var teams = _ctx.teams.OrderBy(t => t.TeamName).ToList();
            ViewBag.Teams = new SelectList(teams, "TeamId", "TeamName");
            return View(new Player());
        }
        [HttpPost]
        public IActionResult AddPlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                _ctx.players.Add(player);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            var teams = _ctx.teams.OrderBy(t => t.TeamName).ToList();
            ViewBag.Teams = new SelectList(teams, "TeamId", "TeamName");

            return View(player);
        }
    }
}
