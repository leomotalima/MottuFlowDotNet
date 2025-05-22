using Microsoft.EntityFrameworkCore;
using MottuFlowApi.Models;

namespace MottuFlowApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Patio> Patios { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<ArucoTag> ArucoTags { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Localidade> Localidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patio>().HasKey(p => p.IdPatio);
            modelBuilder.Entity<Moto>().HasKey(m => m.IdMoto);
            modelBuilder.Entity<Camera>().HasKey(c => c.IdCamera);
            modelBuilder.Entity<ArucoTag>().HasKey(a => a.IdTag);
            modelBuilder.Entity<Status>().HasKey(s => s.IdStatus);
            modelBuilder.Entity<Localidade>().HasKey(l => l.IdLocalidade);
            modelBuilder.Entity<Funcionario>().HasKey(f => f.Id);
        }
    }
}
