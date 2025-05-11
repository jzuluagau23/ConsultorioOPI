using System;
using System.Collections.Generic;
using ConsultorioOPI.Repository.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioOPI.Repository.Persistence;

public partial class ConsultorioOPIContext : DbContext
{
    public ConsultorioOPIContext()
    {
    }

    public ConsultorioOPIContext(DbContextOptions<ConsultorioOPIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EstadosTurno> EstadosTurnos { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:opi-test-server.database.windows.net,1433;Initial Catalog=ConsulltorioopiDB;Persist Security Info=False;User ID=opiadmin;Password=j23opi-+;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstadosTurno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstadosT__3214EC070C2C1E97");

            entity.ToTable("EstadosTurno");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicos__3214EC0732D0A06A");

            entity.Property(e => e.Especialidad).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paciente__3214EC0701F31E49");

            entity.Property(e => e.Documento).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Turnos__3214EC0775AF0008");

            entity.Property(e => e.EstadoId).HasDefaultValue(1);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");

            entity.HasOne(d => d.Estado).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Turno_Estado");

            entity.HasOne(d => d.Medico).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.MedicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Turno_Medico");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Turno_Paciente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
