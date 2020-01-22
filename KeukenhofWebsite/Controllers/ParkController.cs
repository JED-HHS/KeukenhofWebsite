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
    public class ParkController : Controller
    {
        private readonly KeukenhofWebsiteContext _context;

        public ParkController(KeukenhofWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult GoToMainIndex()
        {
            return RedirectToAction("Index", "Admin");
        }

        // GET: Park
        public async Task<IActionResult> Index()
        {
            return View(await _context.Park.ToListAsync());
        }

        // GET: Park/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Park
                .FirstOrDefaultAsync(m => m.Naam == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // GET: Park/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Park/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naam,Openingsdag,Sluitingsdag,OpeningstijdMaandag,SluitingstijdMaandag,OpeningstijdDinsdag,SluitingstijdDinsdag,OpeningstijdWoensdag,SluitingstijdWoensdag,OpeningstijdDonderdag,SluitingstijdDonderdag,OpeningstijdVrijdag,SluitingstijdVrijdag,OpeningstijdZaterdag,SluitingstijdZaterdag,OpeningstijdZondag,SluitingstijdZondag")] Park park)
        {
            if (ModelState.IsValid)
            {
                _context.Add(park);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(park);
        }

        // GET: Park/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Park.FindAsync(id);
            if (park == null)
            {
                return NotFound();
            }
            return View(park);
        }

        // POST: Park/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Naam,Openingsdag,Sluitingsdag,OpeningstijdMaandag,SluitingstijdMaandag,OpeningstijdDinsdag,SluitingstijdDinsdag,OpeningstijdWoensdag,SluitingstijdWoensdag,OpeningstijdDonderdag,SluitingstijdDonderdag,OpeningstijdVrijdag,SluitingstijdVrijdag,OpeningstijdZaterdag,SluitingstijdZaterdag,OpeningstijdZondag,SluitingstijdZondag")] Park park)
        {
            if (id != park.Naam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(park);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkExists(park.Naam))
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
            return View(park);
        }

        // GET: Park/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Park
                .FirstOrDefaultAsync(m => m.Naam == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // POST: Park/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var park = await _context.Park.FindAsync(id);
            _context.Park.Remove(park);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkExists(string id)
        {
            return _context.Park.Any(e => e.Naam == id);
        }
    }
}
