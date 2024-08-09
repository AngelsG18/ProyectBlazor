using System;
using System.Collections.Generic;

namespace ProyectBlazor.API.Models;

public partial class SegEmpresa
{
    public string CodEmpresa { get; set; } = null!;

    public string? CodGrupEmp { get; set; }

    public string? DesEmpresa { get; set; }

    public string? RutaLogo { get; set; }

    public string? NumRuc { get; set; }

    public string? Direccion { get; set; }

    public string? Dsn { get; set; }

    public string? Ruta0 { get; set; }

    public string? Dsnseguridad { get; set; }

    public string? DsnOlap { get; set; }

    public string? OlapUdm { get; set; }

    public string? Telefono { get; set; }

    public string? Fax { get; set; }

    public string? Localidad { get; set; }

    public string? LugCobranza { get; set; }

    public string? RazSocial { get; set; }

    public string? CodRazsocial { get; set; }

    public string? Contacto { get; set; }

    public string? DesCompEmp { get; set; }

    public string? DireccionLetras { get; set; }

    public string? TelefonoLetras { get; set; }

    public string? DsnNet { get; set; }

    public string? DsnseguridadNet { get; set; }

    public string? RutaIcono { get; set; }

    public short? ColorFondoR { get; set; }

    public short? ColorFondoG { get; set; }

    public short? ColorFondoB { get; set; }

    public string? DsnVpn { get; set; }

    public string? DsnSeguridadVpn { get; set; }

    public string? RutaImagenes { get; set; }

    public string? PrefijoFileImagen { get; set; }

    public string? RutaDocumentos { get; set; }

    public string? PrefijoFileDocumento { get; set; }

    public bool? FlgPrincipal { get; set; }

    public string? DsnNetVpn { get; set; }

    public string? DsnSeguridadNetVpn { get; set; }

    public virtual ICollection<SegAdministracion> SegAdministracions { get; set; } = new List<SegAdministracion>();
}
