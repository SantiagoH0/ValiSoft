using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ValiProyecto.Models;

namespace ValiProyecto.Controllers
{
    public class DetallesOrdenComprasController : Controller
    {
        private readonly ProyectoValiContext _context;

        public DetallesOrdenComprasController(ProyectoValiContext context)
        {
            _context = context;
        }
        // GET: DetallesOrdenCompras
        public async Task<IActionResult> Index()
        {
            var proyectoValiContext = _context.DetallesOrdenCompras.Include(d => d.OrdenCompra).Include(d => d.Producto);
            return View(await proyectoValiContext.ToListAsync());
        }

        // GET: DetallesOrdenCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallesOrdenCompras == null)
            {
                return NotFound();
            }

            var detallesOrdenCompra = await _context.DetallesOrdenCompras
                .Include(d => d.OrdenCompra)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.IdDetalleOrdenCompra == id);
            if (detallesOrdenCompra == null)
            {
                return NotFound();
            }

            return View(detallesOrdenCompra);
        }

        // GET: DetallesOrdenCompras/Create
        public IActionResult Create()
        {
            ViewData["OrdenCompraId"] = new SelectList(_context.OrdenCompras, "IdOrdenCompra", "IdOrdenCompra");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre");
            ViewData["Mensaje"] = "";
            return View();
        }

        // POST: DetallesOrdenCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleOrdenCompra,OrdenCompraId,ProductoId,Cantidad,Valor")] DetallesOrdenCompra detallesOrdenCompra)
        {
            if (!ModelState.IsValid)
            {
                // Se valida que no se este registrando mas articulos de los que hay en el inventario
                var producto = await _context.Productos.FindAsync(detallesOrdenCompra.ProductoId);
                detallesOrdenCompra.Valor = (decimal)producto.ValorUnitario * detallesOrdenCompra.Cantidad;
                
                    if (detallesOrdenCompra.Cantidad > 0)
                    {
                    
                        _context.Add(detallesOrdenCompra);
                        await _context.SaveChangesAsync();

             
                        var OrdenCompra = await _context.OrdenCompras.FindAsync(detallesOrdenCompra.OrdenCompraId);
                        OrdenCompra.Total = 0;
                        foreach (var item in await _context.DetallesOrdenCompras.Where(p => p.OrdenCompraId == detallesOrdenCompra.OrdenCompraId).ToListAsync())
                        {
                            OrdenCompra.Total += item.Valor;
                        }
                        _context.OrdenCompras.Update(OrdenCompra);

                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["Mensaje"] = "Cantidad no permitida. Por favor verifíque";
                    }
                
            }
            ViewData["OrdenCompraId"] = new SelectList(_context.OrdenCompras, "IdOrdenCompra", "IdOrdenCompra", detallesOrdenCompra.OrdenCompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre", detallesOrdenCompra.ProductoId);
            return View(detallesOrdenCompra);
        }

        // GET: DetallesOrdenCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallesOrdenCompras == null)
            {
                return NotFound();
            }

            var detallesOrdenCompra = await _context.DetallesOrdenCompras.FindAsync(id);
            if (detallesOrdenCompra == null)
            {
                return NotFound();
            }
            ViewData["OrdenCompraId"] = new SelectList(_context.OrdenCompras, "IdOrdenCompra", "IdOrdenCompra", detallesOrdenCompra.OrdenCompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre", detallesOrdenCompra.ProductoId);
            return View(detallesOrdenCompra);
        }

        // POST: DetallesOrdenCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleOrdenCompra,OrdenCompraId,ProductoId,Cantidad,Valor")] DetallesOrdenCompra detallesOrdenCompra)
        {
            if (id != detallesOrdenCompra.IdDetalleOrdenCompra)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesOrdenCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesOrdenCompraExists(detallesOrdenCompra.IdDetalleOrdenCompra))
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
            ViewData["OrdenCompraId"] = new SelectList(_context.OrdenCompras, "IdOrdenCompra", "IdOrdenCompra", detallesOrdenCompra.OrdenCompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre", detallesOrdenCompra.ProductoId);
            return View(detallesOrdenCompra);
        }

        // GET: DetallesOrdenCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallesOrdenCompras == null)
            {
                return NotFound();
            }

            var detallesOrdenCompra = await _context.DetallesOrdenCompras
                .Include(d => d.OrdenCompra)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.IdDetalleOrdenCompra == id);
            if (detallesOrdenCompra == null)
            {
                return NotFound();
            }

            return View(detallesOrdenCompra);
        }

        // POST: DetallesOrdenCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallesOrdenCompras == null)
            {
                return Problem("Entity set 'ProyectoValiContext.DetallesOrdenCompras'  is null.");
            }
            var detallesOrdenCompra = await _context.DetallesOrdenCompras.FindAsync(id);
            if (detallesOrdenCompra != null)
            {
                _context.DetallesOrdenCompras.Remove(detallesOrdenCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesOrdenCompraExists(int id)
        {
          return (_context.DetallesOrdenCompras?.Any(e => e.IdDetalleOrdenCompra == id)).GetValueOrDefault();
        }
    }
}
