using FaturamentoService.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueService.Data
{
    public class EstoqueServiceDbContext : DbContext
    {
        public EstoqueServiceDbContext(DbContextOptions<EstoqueServiceDbContext> options) : base(options) {}
        public DbSet<Produto> Produtos { get; set; }
    }
}
