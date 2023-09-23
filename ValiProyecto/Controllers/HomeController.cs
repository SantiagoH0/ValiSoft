using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValiProyecto.Models;
using ValiProyecto.Models.View_Models;

namespace ValiProyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProyectoValiContext _dbcontext;

        public HomeController(ProyectoValiContext context)
        {
            _dbcontext = context;
        }

        public IActionResult resumenVenta()
        {
            DateTime fechaInicio = DateTime.Now;
            fechaInicio = fechaInicio.AddDays(-7);

            List<VMVentas> Lista = (from tbventa in _dbcontext.Ventas
                                    where tbventa.FechaVenta.Date >= fechaInicio.Date
                                    group tbventa by tbventa.FechaVenta.Date into grupo
                                    select new VMVentas
                                    {
                                        fecha = grupo.Key.ToString("dd/MM/yy"),
                                        cantidad = grupo.Count(),
                                    }
                                    ).ToList();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        public IActionResult resumenProducto()
        {

            List<VMProductos> Lista = (from tbdetalleventa in _dbcontext.DetallesVentas
                                       group tbdetalleventa by tbdetalleventa.ProductoId into grupo
                                       orderby grupo.Count() descending
                                       select new VMProductos
                                       {
                                           producto = grupo.Key.ToString(),
                                           cantidad = grupo.Count(),
                                       }
                                    ).ToList();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        public IActionResult resumenCompra()
        {
            DateTime fechaInicio = DateTime.Now;
            fechaInicio = fechaInicio.AddDays(-7);

            List<VMCompras> Lista = (from tbcompra in _dbcontext.Compras
                                     where tbcompra.FechaCompra.Date >= fechaInicio.Date
                                     group tbcompra by tbcompra.FechaCompra.Date into grupo
                                     select new VMCompras
                                     {
                                         fecha = grupo.Key.ToString("dd/MM/yy"),
                                         cantidad = grupo.Count(),
                                     }
                                    ).ToList();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }


        public IActionResult resumenProductoMV()
        {

            List<VMProductosMv> Lista = (from tbdetalleventa in _dbcontext.DetallesVentas
                                       group tbdetalleventa by tbdetalleventa.ProductoId into grupo
                                       orderby grupo.Count() ascending
                                       select new VMProductosMv
                                       {
                                           producto = grupo.Key.ToString(),
                                           cantidad = grupo.Count(),
                                       }
                                    ).ToList();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}