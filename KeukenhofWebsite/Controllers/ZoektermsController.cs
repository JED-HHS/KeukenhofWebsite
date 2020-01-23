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
    public class ZoektermsController : Controller
    {
        private readonly KeukenhofWebsiteContext _context;

        public ZoektermsController(KeukenhofWebsiteContext context)
        {
            _context = context;
        }

        // GET: Zoekterms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zoekterm.ToListAsync());
        }

        // GET: Zoekterms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoekterm = await _context.Zoekterm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoekterm == null)
            {
                return NotFound();
            }

            return View(zoekterm);
        }

        // GET: Zoekterms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zoekterms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ZoektermString")] Zoekterm zoekterm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zoekterm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zoekterm);
        }

        // GET: Zoekterms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoekterm = await _context.Zoekterm.FindAsync(id);
            if (zoekterm == null)
            {
                return NotFound();
            }
            return View(zoekterm);
        }

        // POST: Zoekterms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ZoektermString")] Zoekterm zoekterm)
        {
            if (id != zoekterm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zoekterm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZoektermExists(zoekterm.Id))
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
            return View(zoekterm);
        }

        // GET: Zoekterms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoekterm = await _context.Zoekterm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoekterm == null)
            {
                return NotFound();
            }

            return View(zoekterm);
        }

        // POST: Zoekterms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zoekterm = await _context.Zoekterm.FindAsync(id);
            _context.Zoekterm.Remove(zoekterm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZoektermExists(int id)
        {
            return _context.Zoekterm.Any(e => e.Id == id);
        }
    }
}
