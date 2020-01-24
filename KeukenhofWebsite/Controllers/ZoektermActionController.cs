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
    public class ZoektermActionController : Controller
    {
        private readonly KeukenhofWebsiteContext _context;

        public ZoektermActionController(KeukenhofWebsiteContext context)
        {
            _context = context;
        }

        // GET: ZoektermAction
        public async Task<IActionResult> Index()
        {
            var keukenhofWebsiteContext = _context.ZoektermAction.Include(z => z.Action).Include(z => z.Zoekterm);
            return View(await keukenhofWebsiteContext.ToListAsync());
        }

        // GET: ZoektermAction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoektermAction = await _context.ZoektermAction
                .Include(z => z.Action)
                .Include(z => z.Zoekterm)
                .FirstOrDefaultAsync(m => m.ZoektermId == id);
            if (zoektermAction == null)
            {
                return NotFound();
            }

            return View(zoektermAction);
        }

        // GET: ZoektermAction/Create
        public IActionResult Create()
        {
            ViewData["ActionId"] = new SelectList(_context.Action, "Id", "Id");
            ViewData["ZoektermId"] = new SelectList(_context.Zoekterm, "Id", "Id");
            return View();
        }

        // POST: ZoektermAction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZoektermId,ActionId")] ZoektermAction zoektermAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zoektermAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActionId"] = new SelectList(_context.Action, "Id", "Id", zoektermAction.ActionId);
            ViewData["ZoektermId"] = new SelectList(_context.Zoekterm, "Id", "Id", zoektermAction.ZoektermId);
            return View(zoektermAction);
        }

        // GET: ZoektermAction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoektermAction = await _context.ZoektermAction.FindAsync(id);
            if (zoektermAction == null)
            {
                return NotFound();
            }
            ViewData["ActionId"] = new SelectList(_context.Action, "Id", "Id", zoektermAction.ActionId);
            ViewData["ZoektermId"] = new SelectList(_context.Zoekterm, "Id", "Id", zoektermAction.ZoektermId);
            return View(zoektermAction);
        }

        // POST: ZoektermAction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZoektermId,ActionId")] ZoektermAction zoektermAction)
        {
            if (id != zoektermAction.ZoektermId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zoektermAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZoektermActionExists(zoektermAction.ZoektermId))
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
            ViewData["ActionId"] = new SelectList(_context.Action, "Id", "Id", zoektermAction.ActionId);
            ViewData["ZoektermId"] = new SelectList(_context.Zoekterm, "Id", "Id", zoektermAction.ZoektermId);
            return View(zoektermAction);
        }

        // GET: ZoektermAction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoektermAction = await _context.ZoektermAction
                .Include(z => z.Action)
                .Include(z => z.Zoekterm)
                .FirstOrDefaultAsync(m => m.ZoektermId == id);
            if (zoektermAction == null)
            {
                return NotFound();
            }

            return View(zoektermAction);
        }

        // POST: ZoektermAction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zoektermAction = await _context.ZoektermAction.FindAsync(id);
            _context.ZoektermAction.Remove(zoektermAction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZoektermActionExists(int id)
        {
            return _context.ZoektermAction.Any(e => e.ZoektermId == id);
        }
    }
}
