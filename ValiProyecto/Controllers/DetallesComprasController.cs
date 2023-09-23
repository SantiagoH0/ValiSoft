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
    public class DetallesComprasController : Controller
    {
        private readonly ProyectoValiContext _context;

        public DetallesComprasController(ProyectoValiContext context)
        {
            _context = context;
        }
        // GET: DetallesCompras
        public async Task<IActionResult> Index()
        {
            var proyectoValiContext = _context.DetallesCompras.Include(d => d.Compra).Include(d => d.Producto);
            return View(await proyectoValiContext.ToListAsync());
        }

        // GET: DetallesCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallesCompras == null)
            {
                return NotFound();
            }

            var detallesCompra = await _context.DetallesCompras
                .Include(d => d.Compra)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.IdDetalleCompra == id);
            if (detallesCompra == null)
            {
                return NotFound();
            }

            return View(detallesCompra);
        }

        // GET: DetallesCompras/Create
        public IActionResult Create()
        {
            ViewData["CompraId"] = new SelectList(_context.Compras, "IdCompra", "IdCompra");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre");
            ViewData["Mensaje"] = "";
            return View();
        }

        // POST: DetallesCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleCompra,CompraId,ProductoId,Cantidad,Valor")] DetallesCompra detallesCompra)
        {
            if (!ModelState.IsValid)
            {
                    var producto = await _context.Productos.FindAsync(detallesCompra.ProductoId);
                    detallesCompra.Valor = (decimal)producto.ValorUnitario * detallesCompra.Cantidad;
                    
                        if (detallesCompra.Cantidad > 0)
                        {
                            _context.Add(detallesCompra);
                            await _context.SaveChangesAsync();

                            producto.Stock += detallesCompra.Cantidad;
                            _context.Productos.Update(producto);

                            var compra = await _context.Compras.FindAsync(detallesCompra.CompraId);
                            compra.Total = 0;
                            foreach (var item in await _context.DetallesCompras.Where(p => p.CompraId == detallesCompra.CompraId).ToListAsync())
                            {
                                compra.Total += item.Valor;
                            }
                            _context.Compras.Update(compra);

                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            ViewData["Mensaje"] = "Cantidad no permitida. Por favor verifíque";
                        }          
                                    
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", detallesCompra.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre", detallesCompra.ProductoId);
            return View(detallesCompra);
        }

        // GET: DetallesCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallesCompras == null)
            {
                return NotFound();
            }

            var detallesCompra = await _context.DetallesCompras.FindAsync(id);
            if (detallesCompra == null)
            {
                return NotFound();
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", detallesCompra.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre", detallesCompra.ProductoId);
            return View(detallesCompra);
        }

        // POST: DetallesCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleCompra,CompraId,ProductoId,Cantidad,Valor")] DetallesCompra detallesCompra)
        {
            if (id != detallesCompra.IdDetalleCompra)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesCompraExists(detallesCompra.IdDetalleCompra))
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
            ViewData["CompraId"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", detallesCompra.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre", detallesCompra.ProductoId);
            return View(detallesCompra);
        }

        // GET: DetallesCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallesCompras == null)
            {
                return NotFound();
            }

            var detallesCompra = await _context.DetallesCompras
                .Include(d => d.Compra)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.IdDetalleCompra == id);
            if (detallesCompra == null)
            {
                return NotFound();
            }

            return View(detallesCompra);
        }

        // POST: DetallesCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallesCompras == null)
            {
                return Problem("Entity set 'ProyectoValiContext.DetallesCompras'  is null.");
            }
            var detallesCompra = await _context.DetallesCompras.FindAsync(id);
            if (detallesCompra != null)
            {
                _context.DetallesCompras.Remove(detallesCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesCompraExists(int id)
        {
          return (_context.DetallesCompras?.Any(e => e.IdDetalleCompra == id)).GetValueOrDefault();
        }
    }
}
