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
    public class PaginasController : Controller
    {
        private readonly KeukenhofWebsiteContext _context;

        public PaginasController(KeukenhofWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult GoToMainIndex()
        {
            return RedirectToAction("Index", "Admin");
        }

        // GET: Paginas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pagina.ToListAsync());
        }

        // GET: Paginas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagina = await _context.Pagina
                .FirstOrDefaultAsync(m => m.PaginaId == id);
            if (pagina == null)
            {
                return NotFound();
            }

            return View(pagina);
        }

        // GET: Paginas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paginas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaginaId,Titel")] Pagina pagina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagina);
        }

        // GET: Paginas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagina = await _context.Pagina.FindAsync(id);
            if (pagina == null)
            {
                return NotFound();
            }
            return View(pagina);
        }

        // POST: Paginas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaginaId,Titel")] Pagina pagina)
        {
            if (id != pagina.PaginaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaginaExists(pagina.PaginaId))
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
            return View(pagina);
        }

        // GET: Paginas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagina = await _context.Pagina
                .FirstOrDefaultAsync(m => m.PaginaId == id);
            if (pagina == null)
            {
                return NotFound();
            }

            return View(pagina);
        }

        // POST: Paginas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagina = await _context.Pagina.FindAsync(id);
            _context.Pagina.Remove(pagina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaginaExists(int id)
        {
            return _context.Pagina.Any(e => e.PaginaId == id);
        }
    }
}
