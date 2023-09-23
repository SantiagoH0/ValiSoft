using System;
using System.Collections.Generic;

namespace ValiProyecto.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int CategoriaId { get; set; }

    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Stock { get; set; }

    public int StockMin { get; set; }

    public double ValorUnitario { get; set; }

    public double Iva { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<DetallesCompra> DetallesCompras { get; set; } = new List<DetallesCompra>();

    public virtual ICollection<DetallesOrdenCompra> DetallesOrdenCompras { get; set; } = new List<DetallesOrdenCompra>();

    public virtual ICollection<DetallesVenta> DetallesVenta { get; set; } = new List<DetallesVenta>();
}
