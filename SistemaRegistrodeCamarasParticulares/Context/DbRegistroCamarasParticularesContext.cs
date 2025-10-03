using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaRegistrodeCamarasParticulares.Models;

namespace SistemaRegistrodeCamarasParticulares.Context;

public partial class DbRegistroCamarasParticularesContext : DbContext
{
    public DbRegistroCamarasParticularesContext()
    {
    }

    public DbRegistroCamarasParticularesContext(DbContextOptions<DbRegistroCamarasParticularesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Camara> Camaras { get; set; }

    public virtual DbSet<Casa> Casas { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Camara>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CAMARAS__3214EC07D872CBA5");

            entity.ToTable("CAMARAS");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DescripcionUbicacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaFabricacion).HasColumnType("datetime");
            entity.Property(e => e.Marca)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ObservacionValidacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TipoCamara)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoUbicacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TipoUsoCamara)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdCasaNavigation).WithMany(p => p.Camaras)
                .HasForeignKey(d => d.IdCasa)
                .HasConstraintName("FK__CAMARAS__IdCasa__4E88ABD4");
        });

        modelBuilder.Entity<Casa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CASAS__3214EC070DB172C3");

            entity.ToTable("CASAS");

            entity.Property(e => e.CallePrincipal)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CalleSecundaria)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CalleTercera)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Colonia)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Latitud)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Longitud)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Municipio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExterior)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Casas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__CASAS__IdUsuario__4BAC3F29");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DOCUMENT__3214EC07F6884913");

            entity.ToTable("DOCUMENTOS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Documento1).HasColumnName("Documento");
            entity.Property(e => e.Ruta)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdCasaNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdCasa)
                .HasConstraintName("FK__DOCUMENTO__IdCas__52593CB8");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__DOCUMENTO__IdUsu__5165187F");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOGS__3214EC0766C23BFC");

            entity.ToTable("LOGS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DireccionIp)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DireccionIP");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Metodo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ruta)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Usuario)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USUARIOS__3214EC0799AF01DB");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Colonia)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Municipio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
