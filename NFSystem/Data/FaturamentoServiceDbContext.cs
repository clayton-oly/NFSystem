using EstoqueService.Models;
using FaturamentoService.Models;
using Microsoft.EntityFrameworkCore;

namespace FaturamentoService.Data
{
    public class FaturamentoServiceDbContext : DbContext
    {
        public FaturamentoServiceDbContext(DbContextOptions<FaturamentoServiceDbContext> options) : base(options) { }

        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<ItemNota> ItensNota { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemNota>()
                .HasOne(i => i.NotaFiscal)
                .WithMany(n => n.Itens)
                .HasForeignKey(i => i.NotaFiscalId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
