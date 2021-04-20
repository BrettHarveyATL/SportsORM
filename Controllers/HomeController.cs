using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                .OrderBy(team => team.Location)
                .ToList();
            ViewBag.AlphaReverse = _context.Teams
                .Select(team => team)
                .OrderByDescending(team => team.TeamName)
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
            ViewBag.NumberOne = _context.Teams
                .Include(t => t.CurrLeague)
                .Where(t => t.CurrLeague.Name == "Atlantic Soccer Conference")
                .ToList();
            ViewBag.NumberTwo = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.TeamName == "Penguins")
                .Where(p => p.CurrentTeam.Location == "Boston")
                .ToList();
            ViewBag.NumberThree = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference")
                .ToList();
            ViewBag.NumberFour = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.CurrLeague.Name == "American Conference of Amateur Football" && p.LastName == "Lopez")
                .ToList();
            ViewBag.NumberFive = _context.Players
            .Include(player => player.CurrentTeam)
            .Include(player => player.CurrentTeam.CurrLeague)
            .Where(player => player.CurrentTeam.CurrLeague.Sport == "Football")
            .ToList();
            // ...all teams with a (current) player named "Sophia"
            ViewBag.NumberSix = _context.Players
            .Include(player => player.CurrentTeam)
            .Where(player => player.FirstName == "Sophia")
            .ToList();
            //...all leagues with a (current) player named "Sophia"
            ViewBag.NumberSeven = _context.Players
            .Include(player => player.CurrentTeam)
            .Include(player => player.CurrentTeam.CurrLeague)
            .Where(player => player.FirstName == "Sophia")
            .ToList();
            ViewBag.NumberEight = _context.Players
            .Include(player => player.CurrentTeam)
            .Where(player => player.CurrentTeam.TeamName != "Roughriders")
            .Where(player => player.LastName == "Flores")
            .ToList();
            return View();
            
            
            // ...everyone with the last name "Flores" who DOESN'T (currently) play for the Washington Roughriders
        }
            
        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}