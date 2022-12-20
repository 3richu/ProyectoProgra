using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra.Models;

namespace ProyectoProgra.Controllers
{
    [Authorize]
    public class RecibosController : Controller
    {
        private readonly PFContext _context;

        public RecibosController(PFContext context)
        {
            _context = context;
        }

        // GET: Recibos
        public async Task<IActionResult> Index()
        {
            var pFContext = _context.Recibos.Include(r => r.IdClienteNavigation);
            return View(await pFContext.ToListAsync());
        }

        // GET: Recibos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recibos == null)
            {
                return NotFound();
            }

            var recibo = await _context.Recibos
                .Include(r => r.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recibo == null)
            {
                return NotFound();
            }

            return View(recibo);
        }

        // GET: Recibos/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: Recibos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Total,IdCliente")] Recibo recibo)
        {
            _context.Add(recibo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", recibo.IdCliente);
            return View(recibo);
        }

        // GET: Recibos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recibos == null)
            {
                return NotFound();
            }

            var recibo = await _context.Recibos.FindAsync(id);
            if (recibo == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", recibo.IdCliente);
            return View(recibo);
        }

        // POST: Recibos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Total,IdCliente")] Recibo recibo)
        {
            if (id != recibo.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(recibo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciboExists(recibo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", recibo.IdCliente);
            return View(recibo);
        }

        // GET: Recibos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recibos == null)
            {
                return NotFound();
            }

            var recibo = await _context.Recibos
                .Include(r => r.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recibo == null)
            {
                return NotFound();
            }

            return View(recibo);
        }

        // POST: Recibos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recibos == null)
            {
                return Problem("Entity set 'PFContext.Recibos'  is null.");
            }
            var recibo = await _context.Recibos.FindAsync(id);
            if (recibo != null)
            {
                _context.Recibos.Remove(recibo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReciboExists(int id)
        {
            return _context.Recibos.Any(e => e.Id == id);
        }
    }
}
