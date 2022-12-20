using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra.Models;

namespace ProyectoProgra.Controllers
{
    public class ProdRecController : Controller
    {
        private readonly PFContext _context;

        public ProdRecController(PFContext context)
        {
            _context = context;
        }

        // GET: ProdRec
        public async Task<IActionResult> Index()
        {
            var pFContext = _context.ProdRecs.Include(p => p.IdProductoNavigation).Include(p => p.IdReciboNavigation);
            return View(await pFContext.ToListAsync());
        }

        // GET: ProdRec/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProdRecs == null)
            {
                return NotFound();
            }

            var prodRec = await _context.ProdRecs
                .Include(p => p.IdProductoNavigation)
                .Include(p => p.IdReciboNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodRec == null)
            {
                return NotFound();
            }

            return View(prodRec);
        }

        // GET: ProdRec/Create
        public IActionResult Create()
        {
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id");
            ViewData["IdRecibo"] = new SelectList(_context.Recibos, "Id", "Id");
            return View();
        }

        // POST: ProdRec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProducto,IdRecibo")] ProdRec prodRec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodRec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", prodRec.IdProducto);
            ViewData["IdRecibo"] = new SelectList(_context.Recibos, "Id", "Id", prodRec.IdRecibo);
            return View(prodRec);
        }

        // GET: ProdRec/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProdRecs == null)
            {
                return NotFound();
            }

            var prodRec = await _context.ProdRecs.FindAsync(id);
            if (prodRec == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", prodRec.IdProducto);
            ViewData["IdRecibo"] = new SelectList(_context.Recibos, "Id", "Id", prodRec.IdRecibo);
            return View(prodRec);
        }

        // POST: ProdRec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProducto,IdRecibo")] ProdRec prodRec)
        {
            if (id != prodRec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodRec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdRecExists(prodRec.Id))
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
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", prodRec.IdProducto);
            ViewData["IdRecibo"] = new SelectList(_context.Recibos, "Id", "Id", prodRec.IdRecibo);
            return View(prodRec);
        }

        // GET: ProdRec/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProdRecs == null)
            {
                return NotFound();
            }

            var prodRec = await _context.ProdRecs
                .Include(p => p.IdProductoNavigation)
                .Include(p => p.IdReciboNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodRec == null)
            {
                return NotFound();
            }

            return View(prodRec);
        }

        // POST: ProdRec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProdRecs == null)
            {
                return Problem("Entity set 'PFContext.ProdRecs'  is null.");
            }
            var prodRec = await _context.ProdRecs.FindAsync(id);
            if (prodRec != null)
            {
                _context.ProdRecs.Remove(prodRec);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdRecExists(int id)
        {
          return _context.ProdRecs.Any(e => e.Id == id);
        }
    }
}
