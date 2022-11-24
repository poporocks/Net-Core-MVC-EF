using Microsoft.EntityFrameworkCore;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones) : base(opciones)
        {

        }

        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad => 
            {
                entidad.ToTable("Especialidad");
                
                entidad.HasKey(e => e.IdEspecialidad);

                entidad.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>(entidad => 
            {
                entidad.ToTable("Paciente");
                
                entidad.HasKey(e => e.IdPaciente);

                entidad.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

                entidad.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entidad => 
            {
                entidad.ToTable("Medico");
                
                entidad.HasKey(e => e.IdMedico);

                entidad.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

                entidad.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.HorarioAtencionDesde)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(e => e.HorarioAtencionHasta)
                .IsRequired()
                .IsUnicode(false);
            });
        }
    }
}