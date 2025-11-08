using EstoqueService.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueService.Data
{
    public class EstoqueServiceDbContext : DbContext
    {
        public EstoqueServiceDbContext(DbContextOptions<EstoqueServiceDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
             .HasIndex(p => p.Codigo)
             .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

    }
}
