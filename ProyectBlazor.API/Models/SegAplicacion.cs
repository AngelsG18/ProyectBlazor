using System;
using System.Collections.Generic;

namespace ProyectBlazor.API.Models;

public partial class SegAplicacion
{
    public string CodAplicacion { get; set; } = null!;

    public string? DesAplicacion { get; set; }

    public string? NomMenu { get; set; }

    public int? Secuencia { get; set; }

    public string? DesAplicacionEng { get; set; }

    public virtual ICollection<SegAdministracion> SegAdministracions { get; set; } = new List<SegAdministracion>();

    public virtual ICollection<SegOpcione> SegOpciones { get; set; } = new List<SegOpcione>();
}
