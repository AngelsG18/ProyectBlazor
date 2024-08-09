using System;
using System.Collections.Generic;

namespace ProyectBlazor.API.Models;

public partial class SegPerfil
{
    public string CodPerfil { get; set; } = null!;

    public string? DesPerfil { get; set; }

    public string? FlgSector { get; set; }

    public string? FlgIncluidoEnPerfil { get; set; }

    public virtual ICollection<SegAdministracion> SegAdministracions { get; set; } = new List<SegAdministracion>();
}
