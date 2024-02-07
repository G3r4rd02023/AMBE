using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AMBE.Data;

public partial class TransportedbContext : DbContext
{
    public TransportedbContext()
    {
    }

    public TransportedbContext(DbContextOptions<TransportedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bitacora> Bitacora { get; set; }

    public virtual DbSet<Institutos> Institutos { get; set; }

    public virtual DbSet<Objetos> Objetos { get; set; }

    public virtual DbSet<Parametros> Parametros { get; set; }

    public virtual DbSet<Permisos> Permisos { get; set; }

    public virtual DbSet<Personas> Personas { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<TipoPersonas> TipoPersonas { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySql( Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Bitacora>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PRIMARY");

            entity.ToTable("bitacora");

            entity.HasIndex(e => e.IdInstituto, "ID_INSTITUTO");

            entity.HasIndex(e => e.IdUsuario, "ID_USUARIO");

            entity.Property(e => e.IdBitacora).HasColumnName("ID_BITACORA");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdInstituto).HasColumnName("ID_INSTITUTO");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Tabla)
                .HasMaxLength(50)
                .HasColumnName("TABLA");
            entity.Property(e => e.TipoAccion)
                .HasMaxLength(50)
                .HasColumnName("TIPO_ACCION");

            //entity.HasOne(d => d.IdInstitutoNavigation).WithMany(p => p.Bitacora)
            //    .HasForeignKey(d => d.IdInstituto)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("bitacora_ibfk_2");

            //entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Bitacora)
            //    .HasForeignKey(d => d.IdUsuario)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("bitacora_ibfk_1");
        });

        modelBuilder.Entity<Institutos>(entity =>
        {
            entity.HasKey(e => e.IdInstituto).HasName("PRIMARY");

            entity.ToTable("institutos");

            entity.Property(e => e.IdInstituto).HasColumnName("ID_INSTITUTO");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(50)
                .HasColumnName("CREADO_POR");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(50)
                .HasColumnName("MODIFICADO_POR");
            entity.Property(e => e.NombreInstituto)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_INSTITUTO");
            entity.Property(e => e.Rtn)
                .HasMaxLength(20)
                .HasColumnName("RTN");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("TELEFONO");

            //entity.HasMany(d => d.IdRol).WithMany(p => p.IdInstitutoNavigation)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "InstitutoRoles",
            //        r => r.HasOne<Roles>().WithMany()
            //            .HasForeignKey("IdRol")
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("instituto_roles_ibfk_2"),
            //        l => l.HasOne<Institutos>().WithMany()
            //            .HasForeignKey("IdInstituto")
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("instituto_roles_ibfk_1"),
            //        j =>
            //        {
            //            j.HasKey("IdInstituto", "IdRol")
            //                .HasName("PRIMARY")
            //                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            //            j.ToTable("instituto_roles");
            //            j.HasIndex(new[] { "IdRol" }, "ID_ROL");
            //            j.IndexerProperty<int>("IdInstituto").HasColumnName("ID_INSTITUTO");
            //            j.IndexerProperty<int>("IdRol").HasColumnName("ID_ROL");
            //        });

            //entity.HasMany(d => d.IdUsuario).WithMany(p => p.IdInstitutoNavigation)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "InstitutoUsuarios",
            //        r => r.HasOne<Usuarios>().WithMany()
            //            .HasForeignKey("IdUsuario")
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("instituto_usuarios_ibfk_2"),
            //        l => l.HasOne<Institutos>().WithMany()
            //            .HasForeignKey("IdInstituto")
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("instituto_usuarios_ibfk_1"),
            //        j =>
            //        {
            //            j.HasKey("IdInstituto", "IdUsuario")
            //                .HasName("PRIMARY")
            //                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            //            j.ToTable("instituto_usuarios");
            //            j.HasIndex(new[] { "IdUsuario" }, "ID_USUARIO");
            //            j.IndexerProperty<int>("IdInstituto").HasColumnName("ID_INSTITUTO");
            //            j.IndexerProperty<int>("IdUsuario").HasColumnName("ID_USUARIO");
            //        });
        });

        modelBuilder.Entity<Objetos>(entity =>
        {
            entity.HasKey(e => e.IdObjeto).HasName("PRIMARY");

            entity.ToTable("objetos");

            entity.HasIndex(e => e.IdInstituto, "ID_INSTITUTO");

            entity.Property(e => e.IdObjeto).HasColumnName("ID_OBJETO");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(100)
                .HasColumnName("CREADO_POR");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.FechaDeCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_DE_CREACION");
            entity.Property(e => e.FechaDeModificacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_DE_MODIFICACION");
            entity.Property(e => e.IdInstituto).HasColumnName("ID_INSTITUTO");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(100)
                .HasColumnName("MODIFICADO_POR");
            entity.Property(e => e.Objeto)
                .HasMaxLength(255)
                .HasColumnName("OBJETO");
            entity.Property(e => e.TipoObjeto)
                .HasMaxLength(50)
                .HasColumnName("TIPO_OBJETO");

            //entity.HasOne(d => d.IdInstitutoNavigation).WithMany(p => p.Objetos)
            //    .HasForeignKey(d => d.IdInstituto)
            //    .HasConstraintName("objetos_ibfk_1");
        });

        modelBuilder.Entity<Parametros>(entity =>
        {
            entity.HasKey(e => e.IdParametro).HasName("PRIMARY");

            entity.ToTable("parametros");

            entity.HasIndex(e => e.IdUsuario, "ID_USUARIO");

            entity.Property(e => e.IdParametro).HasColumnName("ID_PARAMETRO");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Parametro)
                .HasMaxLength(10)
                .HasColumnName("PARAMETRO");
            entity.Property(e => e.Valor)
                .HasMaxLength(10)
                .HasColumnName("VALOR");

            //entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Parametros)
            //    .HasForeignKey(d => d.IdUsuario)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("parametros_ibfk_1");
        });

        modelBuilder.Entity<Permisos>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PRIMARY");

            entity.ToTable("permisos");

            entity.HasIndex(e => e.IdInstituto, "ID_INSTITUTO");

            entity.HasIndex(e => e.IdObjeto, "ID_OBJETO");

            entity.HasIndex(e => e.IdRol, "ID_ROL");

            entity.Property(e => e.IdPermiso).HasColumnName("ID_PERMISO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.IdInstituto).HasColumnName("ID_INSTITUTO");
            entity.Property(e => e.IdObjeto).HasColumnName("ID_OBJETO");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(50)
                .HasColumnName("MODIFICADO_POR");
            entity.Property(e => e.Permiso)
                .HasMaxLength(50)
                .HasColumnName("PERMISO");

            //entity.HasOne(d => d.IdInstitutoNavigation).WithMany(p => p.Permisos)
            //    .HasForeignKey(d => d.IdInstituto)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("permisos_ibfk_3");

            //entity.HasOne(d => d.IdObjetoNavigation).WithMany(p => p.Permisos)
            //    .HasForeignKey(d => d.IdObjeto)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("permisos_ibfk_2");

            //entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Permisos)
            //    .HasForeignKey(d => d.IdRol)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("permisos_ibfk_1");
        });

        modelBuilder.Entity<Personas>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PRIMARY");

            entity.ToTable("personas");

            entity.HasIndex(e => e.IdInstituto, "ID_INSTITUTO");

            entity.HasIndex(e => e.IdTipoPersona, "ID_TIPO_PERSONA");

            entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(100)
                .HasColumnName("CREADO_POR");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.FechaNacimiento).HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .HasColumnName("GENERO");
            entity.Property(e => e.IdInstituto).HasColumnName("ID_INSTITUTO");
            entity.Property(e => e.IdTipoPersona).HasColumnName("ID_TIPO_PERSONA");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(100)
                .HasColumnName("MODIFICADO_POR");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(40)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(40)
                .HasColumnName("PRIMER_NOMBRE");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(40)
                .HasColumnName("SEGUNDO_APELLIDO");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(40)
                .HasColumnName("SEGUNDO_NOMBRE");

            //entity.HasOne(d => d.IdInstitutoNavigation).WithMany(p => p.Personas)
            //    .HasForeignKey(d => d.IdInstituto)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("personas_ibfk_1");

            //entity.HasOne(d => d.IdTipoPersonaNavigation).WithMany(p => p.Personas)
            //    .HasForeignKey(d => d.IdTipoPersona)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("personas_ibfk_2");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.HasIndex(e => e.IdInstituto, "ID_INSTITUTO");

            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(50)
                .HasColumnName("CREADO_POR");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.IdInstituto).HasColumnName("ID_INSTITUTO");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(50)
                .HasColumnName("MODIFICADO_POR");

            //entity.HasOne(d => d.IdInstituto1).WithMany(p => p.Roles)
            //    .HasForeignKey(d => d.IdInstituto)
            //    .HasConstraintName("roles_ibfk_1");
        });

        modelBuilder.Entity<TipoPersonas>(entity =>
        {
            entity.HasKey(e => e.IdTipoPersona).HasName("PRIMARY");

            entity.ToTable("tipo_personas");

            entity.HasIndex(e => e.IdInstituto, "ID_INSTITUTO");

            entity.Property(e => e.IdTipoPersona).HasColumnName("ID_TIPO_PERSONA");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(100)
                .HasColumnName("CREADO_POR");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(80)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.IdInstituto).HasColumnName("ID_INSTITUTO");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(100)
                .HasColumnName("MODIFICADO_POR");
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(50)
                .HasColumnName("TIPO_PERSONA");

            //entity.HasOne(d => d.IdInstitutoNavigation).WithMany(p => p.TipoPersonas)
            //    .HasForeignKey(d => d.IdInstituto)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("tipo_personas_ibfk_1");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.IdInstituto, "ID_INSTITUTO");

            entity.HasIndex(e => e.IdPersona, "ID_PERSONA");

            entity.HasIndex(e => e.IdRol, "ID_ROL");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(20)
                .HasColumnName("CONTRASEÑA");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.CreadoPor)
                .HasMaxLength(50)
                .HasColumnName("CREADO_POR");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.FechaUltimaConexion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ULTIMA_CONEXION");
            entity.Property(e => e.IdInstituto).HasColumnName("ID_INSTITUTO");
            entity.Property(e => e.IdPersona).HasColumnName("ID_PERSONA");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(50)
                .HasColumnName("MODIFICADO_POR");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_USUARIO");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("USUARIO");

            //entity.HasOne(d => d.IdInstituto1).WithMany(p => p.Usuarios)
            //    .HasForeignKey(d => d.IdInstituto)
            //    .HasConstraintName("usuarios_ibfk_2");

            //entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
            //    .HasForeignKey(d => d.IdPersona)
            //    .HasConstraintName("usuarios_ibfk_1");

            //entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
            //    .HasForeignKey(d => d.IdRol)
            //    .HasConstraintName("usuarios_ibfk_3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
