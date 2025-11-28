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
        public IActionResult Teams(string sortType, string sortDir)
        {
            var teams = _context.teams.AsQueryable();

            teams = ApplyTeamSorting(teams, sortType, sortDir);

            ViewData["CurrentSortType"] = sortType;
            ViewData["CurrentSortDir"] = sortDir;

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

            var model = new PlayerTeamViewModel
            {
                CurrentTeam = new Team()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(PlayerTeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CurrentTeam.TeamId == 0)
                {
                    _context.teams.Add(model.CurrentTeam);
                }
                else
                {
                    _context.teams.Update(model.CurrentTeam);
                }

                _context.SaveChanges();
                return RedirectToAction("Teams");
            }
            else
            {
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var team = _context.teams.Find(id);

            var model = new PlayerTeamViewModel
            {
                CurrentTeam = team
            };

            return View("Add", model);

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
        public IActionResult Delete(PlayerTeamViewModel model)
        {
            _context.teams.Remove(model.CurrentTeam);
            _context.SaveChanges();

            return RedirectToAction("Teams");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IQueryable<Team> ApplyTeamSorting(IQueryable<Team> teams, string sortType, string sortDir)
        {
            bool ascending = sortDir == "asc";

            return sortType switch
            {
                "name" => ascending ? teams.OrderBy(t => t.TeamName) : teams.OrderByDescending(t => t.TeamName),
                "wins" => ascending ? teams.OrderBy(t => t.Wins) : teams.OrderByDescending(t => t.Wins),
                "draws" => ascending ? teams.OrderBy(t => t.Draws) : teams.OrderByDescending(t => t.Draws),
                "losses" => ascending ? teams.OrderBy(t => t.Loses) : teams.OrderByDescending(t => t.Loses),
                _ => teams.OrderByDescending(t => t.Wins)
            };
        }

    }
}
