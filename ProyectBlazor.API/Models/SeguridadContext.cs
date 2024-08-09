using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectBlazor.API.Models;

public partial class SeguridadContext : DbContext
{
    public SeguridadContext()
    {
    }

    public SeguridadContext(DbContextOptions<SeguridadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SegAcceso> SegAccesos { get; set; }

    public virtual DbSet<SegAdministracion> SegAdministracions { get; set; }

    public virtual DbSet<SegAplicacion> SegAplicacions { get; set; }

    public virtual DbSet<SegEmpresa> SegEmpresas { get; set; }

    public virtual DbSet<SegOpcione> SegOpciones { get; set; }

    public virtual DbSet<SegPerfil> SegPerfils { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=DESKTOP-AI9GQRS\\SQLEXPRESS;database=SEGURIDAD;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SegAcceso>(entity =>
        {
            entity.HasKey(e => new { e.CodEmpresa, e.CodPerfil, e.CodAplicacion, e.CodOpcion }).HasName("PK__SEG_Acce__97E0EE35429DE3F4");

            entity.ToTable("SEG_Accesos");

            entity.Property(e => e.CodEmpresa)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Empresa");
            entity.Property(e => e.CodPerfil)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Perfil");
            entity.Property(e => e.CodAplicacion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Aplicacion");
            entity.Property(e => e.CodOpcion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Opcion");

            entity.HasOne(d => d.CodOpcionNavigation).WithMany(p => p.SegAccesos)
                .HasForeignKey(d => d.CodOpcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SEG_Acces__Cod_O__2D27B809");
        });

        modelBuilder.Entity<SegAdministracion>(entity =>
        {
            entity.HasKey(e => new { e.CodEmpresa, e.CodPerfil, e.CodAplicacion }).HasName("PK__SEG_Admi__7ED591BD97EBF00B");

            entity.ToTable("SEG_Administracion");

            entity.Property(e => e.CodEmpresa)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Empresa");
            entity.Property(e => e.CodPerfil)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Perfil");
            entity.Property(e => e.CodAplicacion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Aplicacion");

            entity.HasOne(d => d.CodAplicacionNavigation).WithMany(p => p.SegAdministracions)
                .HasForeignKey(d => d.CodAplicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SEG_Admin__Cod_A__5FB337D6");

            entity.HasOne(d => d.CodEmpresaNavigation).WithMany(p => p.SegAdministracions)
                .HasForeignKey(d => d.CodEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SEG_Admin__Cod_E__00DF2177");

            entity.HasOne(d => d.CodPerfilNavigation).WithMany(p => p.SegAdministracions)
                .HasForeignKey(d => d.CodPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SEG_Admin__Cod_P__619B8048");
        });

        modelBuilder.Entity<SegAplicacion>(entity =>
        {
            entity.HasKey(e => e.CodAplicacion).HasName("PK__SEG_Apli__74D257E0BB3A39CE");

            entity.ToTable("SEG_Aplicacion");

            entity.Property(e => e.CodAplicacion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Aplicacion");
            entity.Property(e => e.DesAplicacion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Des_Aplicacion");
            entity.Property(e => e.DesAplicacionEng)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Des_Aplicacion_ENG");
            entity.Property(e => e.NomMenu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Nom_Menu");
            entity.Property(e => e.Secuencia).HasDefaultValue(1);
        });

        modelBuilder.Entity<SegEmpresa>(entity =>
        {
            entity.HasKey(e => e.CodEmpresa).HasName("PK__SEG_Empresas__6BE40491");

            entity.ToTable("SEG_Empresas");

            entity.Property(e => e.CodEmpresa)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Empresa");
            entity.Property(e => e.CodGrupEmp)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Grup_Emp");
            entity.Property(e => e.CodRazsocial)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cod_razsocial");
            entity.Property(e => e.ColorFondoB).HasColumnName("ColorFondo_B");
            entity.Property(e => e.ColorFondoG).HasColumnName("ColorFondo_G");
            entity.Property(e => e.ColorFondoR).HasColumnName("ColorFondo_R");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DesCompEmp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Des_Comp_Emp");
            entity.Property(e => e.DesEmpresa)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Des_Empresa");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DireccionLetras)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Direccion_Letras");
            entity.Property(e => e.Dsn)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DSN");
            entity.Property(e => e.DsnNet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DSN_NET");
            entity.Property(e => e.DsnNetVpn)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DSN_NET_VPN");
            entity.Property(e => e.DsnOlap)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DSN_OLAP");
            entity.Property(e => e.DsnSeguridadNetVpn)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DSN_SEGURIDAD_NET_VPN");
            entity.Property(e => e.DsnSeguridadVpn)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DSN_SEGURIDAD_VPN");
            entity.Property(e => e.DsnVpn)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DSN_VPN");
            entity.Property(e => e.Dsnseguridad)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DSNSeguridad");
            entity.Property(e => e.DsnseguridadNet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DSNSeguridad_NET");
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FlgPrincipal)
                .HasDefaultValue(false)
                .HasColumnName("Flg_Principal");
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LugCobranza)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lug_Cobranza");
            entity.Property(e => e.NumRuc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("Num_Ruc");
            entity.Property(e => e.OlapUdm)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("OLAP_UDM");
            entity.Property(e => e.PrefijoFileDocumento)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("DOC")
                .IsFixedLength()
                .HasColumnName("Prefijo_File_Documento");
            entity.Property(e => e.PrefijoFileImagen)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("IMG")
                .IsFixedLength()
                .HasColumnName("Prefijo_File_Imagen");
            entity.Property(e => e.RazSocial)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Raz_Social");
            entity.Property(e => e.Ruta0)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.RutaDocumentos)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Ruta_Documentos");
            entity.Property(e => e.RutaIcono)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ruta_Icono");
            entity.Property(e => e.RutaImagenes)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Ruta_Imagenes");
            entity.Property(e => e.RutaLogo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Ruta_Logo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TelefonoLetras)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Telefono_Letras");
        });

        modelBuilder.Entity<SegOpcione>(entity =>
        {
            entity.HasKey(e => e.CodOpcion).HasName("PK__SEG_Opciones__286302EC");

            entity.ToTable("SEG_Opciones");

            entity.Property(e => e.CodOpcion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Opcion");
            entity.Property(e => e.CodAplicacion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Aplicacion");
            entity.Property(e => e.CodGrupoMenu)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("Cod_GrupoMenu");
            entity.Property(e => e.CodPadre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Padre");
            entity.Property(e => e.ColumnasTitulosAreaImpresion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CoordenadaFinalAreaImpresion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CoordenadaInicioAreaImpresion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DesOpcion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Des_Opcion");
            entity.Property(e => e.DesOpcionEng)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Des_Opcion_Eng");
            entity.Property(e => e.ExtensionSalida)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Extension_Salida");
            entity.Property(e => e.FecCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fec_Creacion");
            entity.Property(e => e.FilasTitulosAreaImpresion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.FlgWeb)
                .HasDefaultValue(true)
                .HasColumnName("flg_web");
            entity.Property(e => e.Icono)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MacroExcelVba)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("MacroExcelVBA");
            entity.Property(e => e.NomFor)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NombreSp)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Nombre_SP");
            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.OrientacionAreaImpresion).HasDefaultValue(1);
            entity.Property(e => e.ProgramaEjecutableSalida)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Programa_Ejecutable_Salida");
            entity.Property(e => e.ReadmeDoc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RutExe)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Secuencia).HasDefaultValue(1);
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TipoIcono)
                .HasDefaultValue(2)
                .HasColumnName("Tipo_Icono");
            entity.Property(e => e.TipoVersion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("VB60");
            entity.Property(e => e.ZoomAreaImpresion)
                .HasDefaultValue(100m)
                .HasColumnType("numeric(6, 3)");

            entity.HasOne(d => d.CodAplicacionNavigation).WithMany(p => p.SegOpciones)
                .HasForeignKey(d => d.CodAplicacion)
                .HasConstraintName("FK__SEG_Opcio__Cod_A__3B75D760");
        });

        modelBuilder.Entity<SegPerfil>(entity =>
        {
            entity.HasKey(e => e.CodPerfil).HasName("PK__SEG_Perf__7F593E83C1B9BAFA");

            entity.ToTable("SEG_Perfil");

            entity.Property(e => e.CodPerfil)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Cod_Perfil");
            entity.Property(e => e.DesPerfil)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Des_Perfil");
            entity.Property(e => e.FlgIncluidoEnPerfil)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .IsFixedLength()
                .HasColumnName("Flg_incluido_en_perfil");
            entity.Property(e => e.FlgSector)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .IsFixedLength()
                .HasColumnName("flg_Sector");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
