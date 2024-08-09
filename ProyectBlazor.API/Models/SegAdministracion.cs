using System;
using System.Collections.Generic;

namespace ProyectBlazor.API.Models;

public partial class SegAdministracion
{
    public string CodEmpresa { get; set; } = null!;

    public string CodPerfil { get; set; } = null!;

    public string CodAplicacion { get; set; } = null!;

    public virtual SegAplicacion CodAplicacionNavigation { get; set; } = null!;

    public virtual SegEmpresa CodEmpresaNavigation { get; set; } = null!;

    public virtual SegPerfil CodPerfilNavigation { get; set; } = null!;
}
