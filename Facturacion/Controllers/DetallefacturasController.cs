using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Facturacion.Models;

namespace Facturacion.Controllers
{
    public class DetallefacturasController : Controller
    {
        private readonly FacturacionContext _context;

        public DetallefacturasController(FacturacionContext context)
        {
            _context = context;
        }

        // GET: Detallefacturas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Detallefactura.ToListAsync());
        }

        // GET: Detallefacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallefactura = await _context.Detallefactura
                .FirstOrDefaultAsync(m => m.IdDetallefactura == id);
            if (detallefactura == null)
            {
                return NotFound();
            }

            return View(detallefactura);
        }

        // GET: Detallefacturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Detallefacturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetallefactura,Producto,Precio,Cantidad,Total,Iva,Fecha,IdFactura")] Detallefactura detallefactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallefactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detallefactura);
        }

        // GET: Detallefacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallefactura = await _context.Detallefactura.FindAsync(id);
            if (detallefactura == null)
            {
                return NotFound();
            }
            return View(detallefactura);
        }

        // POST: Detallefacturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetallefactura,Producto,Precio,Cantidad,Total,Iva,Fecha,IdFactura")] Detallefactura detallefactura)
        {
            if (id != detallefactura.IdDetallefactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallefactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallefacturaExists(detallefactura.IdDetallefactura))
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
            return View(detallefactura);
        }

        // GET: Detallefacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallefactura = await _context.Detallefactura
                .FirstOrDefaultAsync(m => m.IdDetallefactura == id);
            if (detallefactura == null)
            {
                return NotFound();
            }

            return View(detallefactura);
        }

        // POST: Detallefacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallefactura = await _context.Detallefactura.FindAsync(id);
            _context.Detallefactura.Remove(detallefactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallefacturaExists(int id)
        {
            return _context.Detallefactura.Any(e => e.IdDetallefactura == id);
        }
    }
}
