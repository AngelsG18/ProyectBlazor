using System;
using System.Collections.Generic;

namespace ProyectBlazor.API.Models;

public partial class SegAcceso
{
    public string CodEmpresa { get; set; } = null!;

    public string CodPerfil { get; set; } = null!;

    public string CodAplicacion { get; set; } = null!;

    public string CodOpcion { get; set; } = null!;

    public virtual SegOpcione CodOpcionNavigation { get; set; } = null!;
}
