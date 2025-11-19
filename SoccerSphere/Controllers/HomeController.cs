using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SoccerSphere.Models;

namespace SoccerSphere.Controllers
{
    public class HomeController : Controller
    {
        private TeamContext _ctx;

        public HomeController(TeamContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TeamList()
        {
            var teams = _ctx.teams.ToList();

            return View(teams);
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
                _ctx.teams.Add(team);
                _ctx.SaveChanges();
                return RedirectToAction("TeamList");
            }
            return View(team);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var team = _ctx.teams.Find(id);
            return View(team);
        }
        [HttpPost]
        public IActionResult Delete(Team team) 
        {
            if (team != null)
            {
                _ctx.teams.Remove(team);
                _ctx.SaveChanges();
            }
            return RedirectToAction("TeamList");
        }
    }
}
