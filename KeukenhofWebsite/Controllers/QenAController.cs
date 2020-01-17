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
    public class QenAController : Controller
    {
        private readonly KeukenhofWebsiteContext _context;

        public QenAController(KeukenhofWebsiteContext context)
        {
            _context = context;
        }

        // GET: QenA
        public async Task<IActionResult> Index()
        {
            return View(await _context.QenA.ToListAsync());
        }

        // GET: QenA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qenA = await _context.QenA
                .FirstOrDefaultAsync(m => m.AnswerId == id);
            if (qenA == null)
            {
                return NotFound();
            }

            return View(qenA);
        }

        // GET: QenA/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QenA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnswerId,Question,Answer")] QenA qenA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qenA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qenA);
        }

        // GET: QenA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qenA = await _context.QenA.FindAsync(id);
            if (qenA == null)
            {
                return NotFound();
            }
            return View(qenA);
        }

        // POST: QenA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnswerId,Question,Answer")] QenA qenA)
        {
            if (id != qenA.AnswerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qenA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QenAExists(qenA.AnswerId))
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
            return View(qenA);
        }

        // GET: QenA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qenA = await _context.QenA
                .FirstOrDefaultAsync(m => m.AnswerId == id);
            if (qenA == null)
            {
                return NotFound();
            }

            return View(qenA);
        }

        // POST: QenA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qenA = await _context.QenA.FindAsync(id);
            _context.QenA.Remove(qenA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QenAExists(int id)
        {
            return _context.QenA.Any(e => e.AnswerId == id);
        }
    }
}
