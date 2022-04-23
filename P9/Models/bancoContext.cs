using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace P9.AutoModel
{
  public partial class bancoContext : DbContext
  {
    public bancoContext()
    {
    }

    public bancoContext(DbContextOptions<bancoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; } = null!;
    public virtual DbSet<Gerente> Gerentes { get; set; } = null!;
    public virtual DbSet<Pago> Pagos { get; set; } = null!;
    public virtual DbSet<Persona> Personas { get; set; } = null!;
    public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
    public virtual DbSet<Solicitud> Solicituds { get; set; } = null!;
    public virtual DbSet<SolicitudPrestamo> SolicitudPrestamos { get; set; } = null!;
    public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseSqlite("Filename=banco.db");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Empleado>(entity =>
      {
        entity.ToTable("empleado");

        entity.HasIndex(e => e.Id, "IX_empleado_id")
                  .IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Activo)
                  .HasColumnType("BOOLEAN")
                  .HasColumnName("activo")
                  .HasDefaultValueSql("true");

        entity.Property(e => e.FechaNacimiento)
                  .HasColumnType("DATE")
                  .HasColumnName("fecha_nacimiento");

        entity.Property(e => e.Password).HasColumnName("password");

        entity.Property(e => e.PrimerApellido)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("primer_apellido");

        entity.Property(e => e.PrimerNombre)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("primer_nombre");

        entity.Property(e => e.SegundoApellido)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("segundo_apellido");

        entity.Property(e => e.SegundoNombre)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("segundo_nombre");
      });

      modelBuilder.Entity<Gerente>(entity =>
      {
        entity.ToTable("gerente");

        entity.HasIndex(e => e.Id, "IX_gerente_id")
                  .IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.FechaIncorporacion)
                  .HasColumnType("DATE")
                  .HasColumnName("fecha_incorporacion");

        entity.Property(e => e.FechaNacimiento)
                  .HasColumnType("DATE")
                  .HasColumnName("fecha_nacimiento");

        entity.Property(e => e.Password).HasColumnName("password");

        entity.Property(e => e.PrimerApellido)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("primer_apellido");

        entity.Property(e => e.PrimerNombre)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("primer_nombre");

        entity.Property(e => e.SegundoApellido)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("segundo_apellido");

        entity.Property(e => e.SegundoNombre)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("segundo_nombre");

        entity.Property(e => e.UltimasVacaciones)
                  .HasColumnType("DATE")
                  .HasColumnName("ultimas_vacaciones");
      });

      modelBuilder.Entity<Pago>(entity =>
      {
        entity.ToTable("pagos");

        entity.HasIndex(e => e.Id, "IX_pagos_id")
                  .IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Cantidad)
                  .HasColumnType("DECIMAL (30, 2)")
                  .HasColumnName("cantidad");

        entity.Property(e => e.Fecha)
                  .HasColumnType("DATETIME")
                  .HasColumnName("fecha");

        entity.Property(e => e.PrestamoId).HasColumnName("prestamo_id");

        entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

        entity.HasOne(d => d.Prestamo)
                  .WithMany(p => p.Pagos)
                  .HasForeignKey(d => d.PrestamoId)
                  .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.Usuario)
                  .WithMany(p => p.Pagos)
                  .HasForeignKey(d => d.UsuarioId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
      });

      modelBuilder.Entity<Persona>(entity =>
      {
        entity.ToTable("persona");

        entity.HasIndex(e => e.Id, "IX_persona_id")
                  .IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Curp)
                  .HasColumnType("VARCHAR (20)")
                  .HasColumnName("curp");

        entity.Property(e => e.FechaNacimiento)
                  .HasColumnType("DATE")
                  .HasColumnName("fecha_nacimiento");

        entity.Property(e => e.PrimerApellido)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("primer_apellido");

        entity.Property(e => e.PrimerNombre)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("primer_nombre");

        entity.Property(e => e.SegundoApellido)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("segundo_apellido");

        entity.Property(e => e.SegundoNombre)
                  .HasColumnType("VARCHAR (30)")
                  .HasColumnName("segundo_nombre");
      });

      modelBuilder.Entity<Prestamo>(entity =>
      {
        entity.ToTable("prestamo");

        entity.HasIndex(e => e.Id, "IX_prestamo_id")
                  .IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Activo)
                  .HasColumnType("BOOLEAN")
                  .HasColumnName("activo")
                  .HasDefaultValueSql("false");

        entity.Property(e => e.Cantidad)
                  .HasColumnType("DECIMAL (30, 2)")
                  .HasColumnName("cantidad");

        entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");

        entity.Property(e => e.FechaAprobacion)
                  .HasColumnType("DATE")
                  .HasColumnName("fecha_aprobacion");

        entity.Property(e => e.FechaLiquidacion)
                  .HasColumnType("DATE")
                  .HasColumnName("fecha_liquidacion");

        entity.Property(e => e.FechaSolicitud)
                  .HasColumnType("DATE")
                  .HasColumnName("fecha_solicitud");

        entity.Property(e => e.GerenteId).HasColumnName("gerente_id");

        entity.Property(e => e.Interes)
                  .HasColumnType("DECIMAL (2, 1)")
                  .HasColumnName("interes");

        entity.Property(e => e.Meses)
                  .HasColumnType("INT (2)")
                  .HasColumnName("meses");

        entity.Property(e => e.PagoMes)
                  .HasColumnType("DECIMAL (30, 2)")
                  .HasColumnName("pago_mes");

        entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

        entity.HasOne(d => d.Empleado)
                  .WithMany(p => p.Prestamos)
                  .HasForeignKey(d => d.EmpleadoId);

        entity.HasOne(d => d.Gerente)
                  .WithMany(p => p.Prestamos)
                  .HasForeignKey(d => d.GerenteId);

        entity.HasOne(d => d.Usuario)
                  .WithMany(p => p.Prestamos)
                  .HasForeignKey(d => d.UsuarioId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
      });

      modelBuilder.Entity<Solicitud>(entity =>
      {
        entity.ToTable("solicitud");

        entity.HasIndex(e => e.Id, "IX_solicitud_id")
                  .IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Estatus)
                  .HasColumnType("INT (1)")
                  .HasColumnName("estatus")
                  .HasDefaultValueSql("1");

        entity.Property(e => e.GerenteId).HasColumnName("gerente_id");

        entity.Property(e => e.PersonaId).HasColumnName("persona_id");

        entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

        entity.HasOne(d => d.Gerente)
                  .WithMany(p => p.Solicituds)
                  .HasForeignKey(d => d.GerenteId);

        entity.HasOne(d => d.Persona)
                  .WithMany(p => p.Solicituds)
                  .HasForeignKey(d => d.PersonaId)
                  .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.Usuario)
                  .WithMany(p => p.Solicituds)
                  .HasForeignKey(d => d.UsuarioId);
      });

      modelBuilder.Entity<SolicitudPrestamo>(entity =>
      {
        entity.ToTable("solicitud_prestamo");

        entity.HasIndex(e => e.Id, "IX_solicitud_prestamo_id")
                  .IsUnique();

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Estatus)
                  .HasColumnType("INT (1)")
                  .HasColumnName("estatus")
                  .HasDefaultValueSql("1");

        entity.Property(e => e.PrestamoId).HasColumnName("prestamo_id");

        entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

        entity.HasOne(d => d.Prestamo)
                  .WithMany(p => p.SolicitudPrestamos)
                  .HasForeignKey(d => d.PrestamoId)
                  .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.Usuario)
                  .WithMany(p => p.SolicitudPrestamos)
                  .HasForeignKey(d => d.UsuarioId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
      });

      modelBuilder.Entity<Usuario>(entity =>
      {
        entity.ToTable("usuario");

        entity.HasIndex(e => e.Id, "IX_usuario_id")
                  .IsUnique();

        entity.HasIndex(e => e.NombreUsuario, "IX_usuario_nombre_usuario")
                  .IsUnique();

        entity.HasIndex(e => e.PersonaId, "IX_usuario_persona_id")
                  .IsUnique();

        entity.Property(e => e.Id)
                  .ValueGeneratedNever()
                  .HasColumnName("id");

        entity.Property(e => e.Activo)
                  .HasColumnType("BOOLEAN")
                  .HasColumnName("activo")
                  .HasDefaultValueSql("true");

        entity.Property(e => e.Intentos)
                  .HasColumnType("INT (1)")
                  .HasColumnName("intentos");

        entity.Property(e => e.NombreUsuario)
                  .HasColumnType("VARCHAR (50)")
                  .HasColumnName("nombre_usuario");

        entity.Property(e => e.Password).HasColumnName("password");

        entity.Property(e => e.PersonaId).HasColumnName("persona_id");

        entity.Property(e => e.Saldo)
                  .HasColumnType("DECIMAL (30, 2)")
                  .HasColumnName("saldo")
                  .HasDefaultValueSql("10000");

        entity.Property(e => e.TiempoBloqueo)
                  .HasColumnType("DATE")
                  .HasColumnName("tiempo_bloqueo");

        entity.HasOne(d => d.Persona)
                  .WithOne(p => p.Usuario)
                  .HasForeignKey<Usuario>(d => d.PersonaId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
