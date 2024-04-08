using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CitasMedicas.Models
{
    public class CitasMedicasContext : DbContext
    {

        public CitasMedicasContext(DbContextOptions<CitasMedicasContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; } = null!; 

        public DbSet<Paciente> Pacientes { get; set; } = null!;
        public DbSet<Medico> Medicos { get; set; } = null!;

        public DbSet<Cita> Citas { get; set; } = null!;

        public DbSet<Diagnostico> Diagnosticos { get; set; } = null !;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {

                entity.UseTpcMappingStrategy();

            });


            modelBuilder.Entity<Cita>(entity =>
            {
                entity.ToTable("Citas");
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Diagnostico).WithOne(e => e.Cita).HasForeignKey<Diagnostico>(e => e.CitaId).IsRequired();
            });


            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity.ToTable("Diagnosticos");
                entity.HasKey(e => e.Id);
                

            });
        }

    }
}
