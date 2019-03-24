using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestionRH.Models
{
    public partial class GestionRHContext : DbContext
    {
        public GestionRHContext()
        {
        }

        public GestionRHContext(DbContextOptions<GestionRHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MantenimientoCargo> MantenimientoCargo { get; set; }
        public virtual DbSet<MantenimientoDepartamento> MantenimientoDepartamento { get; set; }
        public virtual DbSet<MantenimientoEmpleado> MantenimientoEmpleado { get; set; }
        public virtual DbSet<ProcessLicencias> ProcessLicencias { get; set; }
        public virtual DbSet<ProcessNominas> ProcessNominas { get; set; }
        public virtual DbSet<ProcessPermisos> ProcessPermisos { get; set; }
        public virtual DbSet<ProcessSalidaEmpleado> ProcessSalidaEmpleado { get; set; }
        public virtual DbSet<ProcessVacaciones> ProcessVacaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=Enrique-PC;Initial Catalog=GestionRH;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<MantenimientoCargo>(entity =>
            {
                entity.ToTable("Mantenimiento_Cargo");

                entity.Property(e => e.CodigoCargo).HasColumnName("Codigo_Cargo");

                entity.Property(e => e.NombreCargo)
                    .IsRequired()
                    .HasColumnName("Nombre_Cargo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MantenimientoDepartamento>(entity =>
            {
                entity.ToTable("Mantenimiento_Departamento");

                entity.Property(e => e.CodigoDepartamento).HasColumnName("Codigo_Departamento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MantenimientoEmpleado>(entity =>
            {
                entity.ToTable("Mantenimiento_Empleado");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CodigoEmpleado).HasColumnName("Codigo_empleado");
                

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("Fecha_Ingreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50);
                
            });

            modelBuilder.Entity<ProcessLicencias>(entity =>
            {
                entity.ToTable("Process_licencias");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasColumnName("comentario")
                    .HasMaxLength(300);

                entity.Property(e => e.Desde)
                    .HasColumnName("desde")
                    .HasColumnType("datetime");

                entity.Property(e => e.Empleado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hasta)
                    .HasColumnName("hasta")
                    .HasColumnType("datetime");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasColumnName("motivo")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<ProcessNominas>(entity =>
            {
                entity.ToTable("Process_nominas");

                entity.Property(e => e.Age).HasColumnType("datetime");

                entity.Property(e => e.Mes)
                    .HasColumnName("mes")
                    .HasColumnType("datetime");

                entity.Property(e => e.MontoTotal).HasColumnName("monto_total");
            });

            modelBuilder.Entity<ProcessPermisos>(entity =>
            {
                entity.ToTable("Process_Permisos");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasColumnName("comentario")
                    .HasMaxLength(50);

                entity.Property(e => e.Desde)
                    .HasColumnName("desde")
                    .HasColumnType("datetime");

                entity.Property(e => e.Empleados)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hasta)
                    .HasColumnName("hasta")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ProcessSalidaEmpleado>(entity =>
            {
                entity.ToTable("Process_salida_empleado");

                entity.Property(e => e.Empleado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.TipoDeSalida)
                    .IsRequired()
                    .HasColumnName("Tipo_de_salida")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProcessVacaciones>(entity =>
            {
                entity.ToTable("Process_Vacaciones");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasColumnName("comentario")
                    .HasMaxLength(300);

                entity.Property(e => e.Correspondiente)
                    .HasColumnName("correspondiente")
                    .HasColumnType("datetime");

                entity.Property(e => e.Desde)
                    .HasColumnName("desde")
                    .HasColumnType("datetime");

                entity.Property(e => e.Empleado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hasta)
                    .HasColumnName("hasta")
                    .HasColumnType("datetime");
            });
        }
    }
}
