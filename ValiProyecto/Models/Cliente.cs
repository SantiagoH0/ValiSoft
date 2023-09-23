using System;
using System.Collections.Generic;

namespace ValiProyecto.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int Cedula { get; set; }

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
