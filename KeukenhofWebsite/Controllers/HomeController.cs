﻿using System;
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
            return View(_context.Content.ToList());
        }

        /* GET: tests/Edit/5
        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Home home)
        {
            if (ModelState.IsValid)
            {
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(home);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var home = await _context.test.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }
            return View(home);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Home home)
        {
            if (id != home.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(home);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeExists(home.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(home);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.test
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var home = await _context.test.FindAsync(id);
            _context.test.Remove(home);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(int id)
        {
            return _context.test.Any(e => e.Id == id);
        }*/

    }
}
