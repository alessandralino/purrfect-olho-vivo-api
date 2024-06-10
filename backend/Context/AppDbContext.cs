using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Linha> Linhas { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
    }

}
