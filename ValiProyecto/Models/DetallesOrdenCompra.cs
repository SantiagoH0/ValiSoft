using System;
using System.Collections.Generic;

namespace ValiProyecto.Models;

public partial class DetallesOrdenCompra
{
    public int IdDetalleOrdenCompra { get; set; }

    public int OrdenCompraId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Valor { get; set; }

    public virtual OrdenCompra OrdenCompra { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
