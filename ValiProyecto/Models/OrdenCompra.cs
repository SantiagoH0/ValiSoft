using System;
using System.Collections.Generic;

namespace ValiProyecto.Models;

public partial class OrdenCompra
{
    public int IdOrdenCompra { get; set; }

    public int ProveedorId { get; set; }

    public DateTime FechaOrdenCompra { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<DetallesOrdenCompra> DetallesOrdenCompras { get; set; } = new List<DetallesOrdenCompra>();

    public virtual Proveedor Proveedor { get; set; } = null!;
}
