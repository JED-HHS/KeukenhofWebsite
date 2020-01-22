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
            return View();
        }

        public IActionResult HetPark()
        {
            return View();
        }

        public IActionResult _Contact()
        {
            return View();
        }

        public IActionResult Privacy_statement()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View(_context.QenA.ToList());
        }

        public IActionResult Bereikbaarheid()
        {
            return View();
        }

        public IActionResult Content()
        {
            return View();
        }

        public IActionResult Evenementen()
        {
            return View();
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
