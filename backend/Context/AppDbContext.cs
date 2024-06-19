using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Linha> Linha { get; set; }
        public DbSet<Parada> Parada { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<PosicaoVeiculo> PosicoesVeiculo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Linha>()
               .HasMany(l => l.Paradas)
               .WithMany(p => p.Linhas)
               .UsingEntity(j => j.ToTable("LinhaParada"));

            modelBuilder.Entity<Veiculo>()
               .HasOne(p => p.Linha);

            base.OnModelCreating(modelBuilder);
        }

    

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    }

}
