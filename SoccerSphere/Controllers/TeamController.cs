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


        public IActionResult Players(string sortType, string sortDir, string posId, int? id = null)
        {
            var players = _context.players.Include(p => p.Team).Include(p => p.Position).AsQueryable();
            var positions = _context.positions.ToList();


            // Filter by Team
            if (id.HasValue && id > 0)
            {
                players = players.Where(p => p.TeamId == id);
            }

            // Filter by Player Position
            if (!string.IsNullOrEmpty(posId) && int.TryParse(posId, out int posIdInt))
            {
                players = players.Where(p => p.PositionId == posIdInt);
            }

            players = ApplyPlayerSorting(players, sortType, sortDir);

            ViewData["CurrentSortType"] = sortType;
            ViewData["CurrentSortDir"] = sortDir;
            ViewData["CurrentPosId"] = posId;

            var model = new PlayerTeamViewModel
            {
                Players = players.ToList(),
                CurrentTeam = id.HasValue && id > 0
                    ? _context.teams.FirstOrDefault(t => t.TeamId == id) : null,
                Positions = positions
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var teams = _context.teams.OrderBy(t => t.TeamName).ToList();
            var positions = _context.positions.ToList();

            var model = new PlayerTeamViewModel
            {
                CurrentPlayer = new Player(),
                Teams = teams,
                Positions = positions
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(PlayerTeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CurrentPlayer.PlayerId == 0)
                {
                    _context.players.Add(model.CurrentPlayer);
                }
                else
                {
                    _context.players.Update(model.CurrentPlayer);
                }

                _context.SaveChanges();
                return RedirectToAction("Players");
            }
            else
            {
                model.Teams = _context.teams.OrderBy(t => t.TeamName).ToList();
                model.Positions = _context.positions.ToList();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var player = _context.players.Find(id);
            player.Team = _context.teams.Find(player.TeamId);
            player.Position = _context.positions.Find(player.PositionId);

            var model = new PlayerTeamViewModel
            {
                CurrentPlayer = player
            };

            return View(model);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var player = _context.players.Find(id);
            var teams = _context.teams.OrderBy(t => t.TeamName).ToList();
            var positions = _context.positions.ToList();

            var model = new PlayerTeamViewModel
            {
                CurrentPlayer = player,
                Teams = teams,
                Positions = positions
            };

            return View("Add", model);
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

        private IQueryable<Player> ApplyPlayerSorting(IQueryable<Player> players, string sortType, string sortDir)
        {
            bool ascending = sortDir == "asc";

            return sortType switch
            {
                "name" => ascending ? players.OrderBy(p => p.PlayerName) : players.OrderByDescending(p => p.PlayerName),
                "goals" => ascending ? players.OrderBy(p => p.Goals) : players.OrderByDescending(p => p.Goals),
                "assists" => ascending ? players.OrderBy(p => p.Assists) : players.OrderByDescending(p => p.Assists),
                "team" => ascending ? players.OrderBy(p => p.Team.TeamName) : players.OrderByDescending(p => p.Team.TeamName),
                _ => players.OrderByDescending(p => p.Goals)
            };
        }


    }
}
