using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerSphere.Data;
using SoccerSphere.Models;

namespace SoccerSphere.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TeamContext _context;

        public HomeController(ILogger<HomeController> logger, TeamContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Teams(string sortOrder)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewData["WinsSortParam"] = sortOrder == "wins_asc" ? "wins_desc" : "wins_asc";
            ViewData["DrawsSortParam"] = sortOrder == "draws_asc" ? "draws_desc" : "draws_asc";
            ViewData["LossesSortParam"] = sortOrder == "losses_asc" ? "losses_desc" : "losses_asc";


            var teams = _context.teams.AsQueryable();

            teams = ApplyTeamSorting(teams, sortOrder);

            var model = new PlayerTeamViewModel
            {
                Teams = teams.ToList()
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult View(int id)
        {
            var team = _context.teams.Find(id);

            var model = new PlayerTeamViewModel
            {
                CurrentTeam = team
            };

            return View(model);

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Team());
        }
        [HttpPost]
        public IActionResult Add(Team team)
        {
            if (ModelState.IsValid)
            {
                _context.teams.Add(team);
                _context.SaveChanges();
                return RedirectToAction("Teams");
            }
            return View(team);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var team = _context.teams.Find(id);

            var model = new PlayerTeamViewModel
            {
                CurrentTeam = team
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Team team)
        {
            _context.teams.Remove(team);
            _context.SaveChanges();

            return View("Teams");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IQueryable<Team> ApplyTeamSorting(IQueryable<Team> teams, string sortOrder)
        {
            switch (sortOrder)
            {
                case "name_desc":
                    return teams.OrderByDescending(t => t.TeamName);
                case "name_asc":
                    return teams.OrderBy(t => t.TeamName);
                case "wins_desc":
                    return teams.OrderByDescending(t => t.Wins);
                case "wins_asc":
                    return teams.OrderBy(t => t.Wins);
                case "draws_desc":
                    return teams.OrderByDescending(t => t.Draws);
                case "draws_asc":
                    return teams.OrderBy(t => t.Draws);
                case "losses_desc":
                    return teams.OrderByDescending(t => t.Loses);
                case "losses_asc":
                    return teams.OrderBy(t => t.Loses);
                default:
                    return teams.OrderByDescending(t => t.Wins); // default sort
            }
        }

    }
}
