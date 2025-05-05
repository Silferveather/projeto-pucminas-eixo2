using Microsoft.EntityFrameworkCore;

namespace projeto_pucminas_eixo2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Venda> Consumos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}