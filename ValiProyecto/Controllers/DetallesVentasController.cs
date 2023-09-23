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
    public class DetallesVentasController : Controller
    {
        private readonly ProyectoValiContext _context;

        public DetallesVentasController(ProyectoValiContext context)
        {
            _context = context;
        }
        // GET: DetallesVentas
        public async Task<IActionResult> Index()
        {
            var proyectoValiContext = _context.DetallesVentas.Include(d => d.Producto).Include(d => d.Venta);
            return View(await proyectoValiContext.ToListAsync());
        }

        // GET: DetallesVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallesVentas == null)
            {
                return NotFound();
            }

            var detallesVenta = await _context.DetallesVentas
                .Include(d => d.Producto)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.DetalleVentaId == id);
            if (detallesVenta == null)
            {
                return NotFound();
            }

            return View(detallesVenta);
        }

        // GET: DetallesVentas/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre");
            ViewData["VentaId"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta");
            ViewData["Mensaje"] = "";
            return View();
        }

        // POST: DetallesVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleVentaId,VentaId,ProductoId,Cantidad,Valor")] DetallesVenta detallesVenta)
        {
            if (!ModelState.IsValid)
            {
                // Se valida que no se este registrando mas articulos de los que hay en el inventario
                var producto = await _context.Productos.FindAsync(detallesVenta.ProductoId);
                detallesVenta.Valor = (decimal)producto.ValorUnitario * detallesVenta.Cantidad;
                if (producto.Stock >= detallesVenta.Cantidad)
                {
                    if (detallesVenta.Cantidad > 0)
                    {
                        // guardar el detalle
                        _context.Add(detallesVenta);
                        await _context.SaveChangesAsync();

                        // Actualizar existencias del inventario
                        producto.Stock -= detallesVenta.Cantidad;
                        _context.Productos.Update(producto);

                        // Se actualiza la venta
                        var venta = await _context.Ventas.FindAsync(detallesVenta.VentaId);
                        venta.Total = 0;
                        foreach (var item in await _context.DetallesVentas.Where(p => p.VentaId == detallesVenta.VentaId).ToListAsync())
                        {
                            venta.Total += item.Valor;
                        }
                        _context.Ventas.Update(venta);

                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["Mensaje"] = "Cantidad no permitida. Por favor verifíque";
                    }
                }
                else
                    ViewData["Mensaje"] = "La cantidad de productos es mayor a las existencias, solo quedan " + producto.Stock + " unidades disponibles.";
                //_context.Add(detallesVenta);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre", detallesVenta.ProductoId);
            ViewData["VentaId"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", detallesVenta.VentaId);
            return View(detallesVenta);
        }

        // GET: DetallesVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallesVentas == null)
            {
                return NotFound();
            }

            var detallesVenta = await _context.DetallesVentas.FindAsync(id);
            if (detallesVenta == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre", detallesVenta.ProductoId);
            ViewData["VentaId"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", detallesVenta.VentaId);
            return View(detallesVenta);
        }

        // POST: DetallesVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleVentaId,VentaId,ProductoId,Cantidad,Valor")] DetallesVenta detallesVenta)
        {
            if (id != detallesVenta.DetalleVentaId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesVentaExists(detallesVenta.DetalleVentaId))
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
            ViewData["ProductoId"] = new SelectList(_context.Productos, "IdProducto", "Nombre", detallesVenta.ProductoId);
            ViewData["VentaId"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", detallesVenta.VentaId);
            return View(detallesVenta);
        }

        // GET: DetallesVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallesVentas == null)
            {
                return NotFound();
            }

            var detallesVenta = await _context.DetallesVentas
                .Include(d => d.Producto)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.DetalleVentaId == id);
            if (detallesVenta == null)
            {
                return NotFound();
            }

            return View(detallesVenta);
        }

        // POST: DetallesVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallesVentas == null)
            {
                return Problem("Entity set 'ProyectoValiContext.DetallesVentas'  is null.");
            }
            var detallesVenta = await _context.DetallesVentas.FindAsync(id);
            if (detallesVenta != null)
            {
                _context.DetallesVentas.Remove(detallesVenta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesVentaExists(int id)
        {
          return (_context.DetallesVentas?.Any(e => e.DetalleVentaId == id)).GetValueOrDefault();
        }
    }
}
