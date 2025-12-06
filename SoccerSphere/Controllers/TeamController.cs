using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Route("[controller]/Players/{id?}")]
        public IActionResult Players(int? id = null, string sortOrder = "")
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewData["GoalsSortParam"] = sortOrder == "goals_asc" ? "goals_desc" : "goals_asc";
            ViewData["AssistsSortParam"] = sortOrder == "assists_asc" ? "assists_desc" : "assists_asc";
            ViewData["TeamSortParam"] = sortOrder == "team_asc" ? "team_desc" : "team_asc";

            var players = _context.players.Include(p => p.Team).AsQueryable();

            if (id.HasValue && id > 0)
            {
                players = players.Where(p => p.TeamId == id);
            }

            players = ApplyPlayerSorting(players, sortOrder);

            var model = new PlayerTeamViewModel
            {
                Players = players.ToList(),
                CurrentTeam = id.HasValue && id > 0
                    ? _context.teams.FirstOrDefault(t => t.TeamId == id)
                    : null
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var teams = _context.teams.OrderBy(t => t.TeamName).ToList();
            ViewBag.Teams = new SelectList(teams, "TeamId", "TeamName");
            return View(new PlayerTeamViewModel
            {
                CurrentPlayer = new Player()
            });
        }
        [HttpPost]
        public IActionResult Add(PlayerTeamViewModel player)
        {
            if (ModelState.IsValid)
            {
                _context.players.Add(player.CurrentPlayer);
                _context.SaveChanges();
                return RedirectToAction("Players");
            }
            var teams = _context.teams.OrderBy(t => t.TeamName).ToList();
            ViewBag.Teams = new SelectList(teams, "TeamId", "TeamName");

            return View(player);
        }
        [HttpGet]
        public IActionResult View(int id)
        {
            var player = _context.players.Find(id);
            player.Team = _context.teams.Find(player.TeamId);

            var model = new PlayerTeamViewModel
            {
                CurrentPlayer = player
            };

            return View(model);

        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var player = _context.players.Find(id);
            player.Team = _context.teams.Find(player.TeamId);


            var model = new PlayerTeamViewModel
            {
                CurrentPlayer = player
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(PlayerTeamViewModel player)
        {
            _context.players.Remove(player.CurrentPlayer);
            _context.SaveChanges();

            return RedirectToAction("Players");
        }

        private IQueryable<Player> ApplyPlayerSorting(IQueryable<Player> players, string sortOrder)
        {
            switch (sortOrder)
            {
                case "name_asc":
                    return players.OrderBy(p => p.PlayerName);
                case "name_desc":
                    return players.OrderByDescending(p => p.PlayerName);
                case "goals_asc":
                    return players.OrderBy(p => p.Goals);
                case "goals_desc":
                    return players.OrderByDescending(p => p.Goals);
                case "assists_asc":
                    return players.OrderBy(p => p.Assists);
                case "assists_desc":
                    return players.OrderByDescending(p => p.Assists);
                case "team_asc":
                    return players.OrderBy(p => p.Team.TeamName);
                case "team_desc":
                    return players.OrderByDescending(p => p.Team.TeamName);
                default:
                    return players.OrderByDescending(p => p.Goals); 
            }
        }


    }
}
