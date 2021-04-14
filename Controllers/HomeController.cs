using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomansLeague = _context.Leagues
                .Where(womens => womens.Name.Contains("Womens"))
                .ToList();
            ViewBag.HockyLeague = _context.Leagues
                .Where(hockey => hockey.Sport.Contains("Hockey"))
                .ToList();
            ViewBag.NotFootBall = _context.Leagues
            .Where(notFoot => notFoot.Sport != "Football")
            .ToList();
            ViewBag.Conferences = _context.Leagues
                .Where(conference => conference.Name.Contains("Conference"))
                .ToList();
            ViewBag.Atlantic = _context.Leagues
                .Where(atl => atl.Name.Contains("Atlantic"))
                .ToList();
            ViewBag.Dallas = _context.Teams
                .Where(city => city.Location.Contains("Dallas"))
                .ToList();
            ViewBag.Raptors = _context.Teams
                .Where(team => team.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.City = _context.Teams
                .Where(team => team.Location.Contains("City"))
                .ToList();
            ViewBag.StartWithT = _context.Teams.AsEnumerable()
                .Where(team => team.TeamName[0] == ('T'))
                .ToList();
            ViewBag.Alpha = _context.Teams
                .Select(team => team)
                .OrderBy(team=> team.Location)
                .ToList();
            ViewBag.AlphaReverse = _context.Teams
                .Select(team => team)
                .OrderByDescending(team=> team.TeamName)
                .ToList();
            ViewBag.Coop = _context.Players
                .Where(player => player.LastName.Contains("Cooper"))
                .ToList();
            ViewBag.Josh = _context.Players
                .Where(player => player.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.NotJC = _context.Players
                .Where(player => player.FirstName != "Joshua" && player.LastName != "Cooper")
                .ToList();
            ViewBag.AlexWyatt = _context.Players
                .Where(player => player.FirstName == "Alexander" || player.FirstName == "Wyatt")
                .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}