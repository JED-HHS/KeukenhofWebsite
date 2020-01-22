using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KeukenhofWebsite.Models;

namespace KeukenhofWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly KeukenhofWebsiteContext _context;

        public HomeController(KeukenhofWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult _Hoofdpagina()
        {
            return View(_context.Content.ToList());
        }

        public IActionResult HetPark()
        {
            return View(_context.Content.ToList());
        }

        public IActionResult _Contact()
        {
            return View(_context.Content.ToList());
        }

        public IActionResult Privacy_statement()
        {
            return View(_context.Content.ToList());
        }

        public IActionResult FAQ()
        {
            return View(_context.QenA.ToList());
        }

        public IActionResult Bereikbaarheid()
        {
            return View(_context.Content.ToList());
        }

        public IActionResult Content()
        {
            return View(_context.Content.ToList());
        }

        public IActionResult Evenementen()
        {
            return View();
        }

        public IActionResult Zoekresultaten(string query)
        {
            ViewBag.query = query;

            query = query.ToUpper();
            var result = from zt in _context.Zoekterm
                         join zta in _context.ZoektermAction on zt.Id equals zta.ZoektermId
                         join action in _context.Action on zta.ActionId equals action.Id                         
                         where zt.ZoektermString.ToUpper().Contains(query)
                         select action;

            ViewBag.count = result.Count();
            return View(result.Distinct());
        }
        
        public IActionResult PraktischeInformatie()
        {
            return View();
        }

        public IActionResult Zoekresultaten()

        {
            return View();
        }
    }
}
