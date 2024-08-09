using System;
using System.Collections.Generic;

namespace ProyectBlazor.API.Models;

public partial class SegOpcione
{
    public string CodOpcion { get; set; } = null!;

    public string? CodAplicacion { get; set; }

    public string? RutExe { get; set; }

    public string? NomFor { get; set; }

    public int? Nivel { get; set; }

    public string? Tipo { get; set; }

    public string? Icono { get; set; }

    public string? CodPadre { get; set; }

    public string? DesOpcion { get; set; }

    public string? DesOpcionEng { get; set; }

    public string? ReadmeDoc { get; set; }

    public int? Secuencia { get; set; }

    public DateTime? FecCreacion { get; set; }

    public string? TipoVersion { get; set; }

    public int? TipoIcono { get; set; }

    public string? NombreSp { get; set; }

    public string? ExtensionSalida { get; set; }

    public string? ProgramaEjecutableSalida { get; set; }

    public string? MacroExcelVba { get; set; }

    public string? CoordenadaInicioAreaImpresion { get; set; }

    public string? CoordenadaFinalAreaImpresion { get; set; }

    public int? OrientacionAreaImpresion { get; set; }

    public decimal? ZoomAreaImpresion { get; set; }

    public string? FilasTitulosAreaImpresion { get; set; }

    public string? ColumnasTitulosAreaImpresion { get; set; }

    public string? CodGrupoMenu { get; set; }

    public string? Observacion { get; set; }

    public bool? FlgWeb { get; set; }

    public virtual SegAplicacion? CodAplicacionNavigation { get; set; }

    public virtual ICollection<SegAcceso> SegAccesos { get; set; } = new List<SegAcceso>();
}
