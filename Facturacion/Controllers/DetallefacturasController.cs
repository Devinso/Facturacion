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
            var facturacionContext = _context.Detallefactura.Include(d => d.Factura).Include(d => d.Producto);
            return View(await facturacionContext.ToListAsync());
        }

        // GET: Detallefacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallefactura = await _context.Detallefactura
                .Include(d => d.Factura)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetalleFacturaId == id);
            if (detallefactura == null)
            {
                return NotFound();
            }

            return View(detallefactura);
        }

        // GET: Detallefacturas/Create
        public IActionResult Create()
        {
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId");
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "ProductoId");
            return View();
        }

        // POST: Detallefacturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleFacturaId,Precio,Cantidad,Total,Iva,Fecha,IdFactura,Nombre,Apellido,ProductoId,FacturaId")] Detallefactura detallefactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallefactura);
                _context.SaveChanges();

                int FacturaId = (int)detallefactura.IdFactura;
                var factura = _context.Factura.FirstOrDefault(f => f.FacturaId == FacturaId);
                decimal subtotal = 0;
                foreach (var item in _context.Detallefactura.Where(d => d.FacturaId == FacturaId))
                {
                    subtotal += item.Total;
                }
                 factura.Subtotal = subtotal;
                factura.Iva = subtotal * (decimal)0.15;
                factura.Total = subtotal - factura.Iva;
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
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", detallefactura.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "ProductoId", detallefactura.ProductoId);
            return View(detallefactura);
        }

        // POST: Detallefacturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleFacturaId,Precio,Cantidad,Total,Iva,Fecha,IdFactura,Nombre,Apellido,ProductoId,FacturaId")] Detallefactura detallefactura)
        {
            if (id != detallefactura.DetalleFacturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallefactura);
                    _context.SaveChanges();

                    int FacturaId = (int)detallefactura.IdFactura;
                    var factura = _context.Factura.FirstOrDefault(f => f.FacturaId == FacturaId);
                    decimal subtotal = 0;
                    foreach (var item in _context.Detallefactura.Where(d => d.FacturaId == FacturaId))
                    {
                        subtotal += item.Total;
                    }
                    factura.Subtotal = subtotal;
                    factura.Iva = subtotal * (decimal)0.15;
                    factura.Total = subtotal - factura.Iva;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallefacturaExists(detallefactura.DetalleFacturaId))
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
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", detallefactura.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "ProductoId", detallefactura.ProductoId);
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
                .Include(d => d.Factura)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetalleFacturaId == id);
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
            return _context.Detallefactura.Any(e => e.DetalleFacturaId == id);
        }
    }
}
