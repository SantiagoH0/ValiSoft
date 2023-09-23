using System;
using System.Collections.Generic;

namespace ValiProyecto.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string Nit { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int CategoriaId { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();
}
