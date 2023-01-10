using System;
using System.Collections.Generic;

namespace DL;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? NombreProveedor { get; set; }

    public virtual ICollection<Medicamento> Medicamentos { get; } = new List<Medicamento>();
}
