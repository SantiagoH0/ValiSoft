using System;
using System.Collections.Generic;

namespace ValiProyecto.Models;

public partial class DetallesCompra
{
    public int IdDetalleCompra { get; set; }

    public int CompraId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Valor { get; set; }

    public virtual Compra Compra { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
