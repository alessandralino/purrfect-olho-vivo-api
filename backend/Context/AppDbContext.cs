using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.Context
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<Linha> Linhas { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Parada> Parada { get; set; }
        public DbSet<PosicaoVeiculo> PosicaoVeiculo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar o relacionamento um-para-muitos
            modelBuilder.Entity<Linha>()
                .HasMany(l => l.Paradas);
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    }

}
