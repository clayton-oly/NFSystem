using EstoqueService.Data;
using EstoqueService.Interfaces;
using EstoqueService.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueService.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly EstoqueServiceDbContext _context;
        public ProdutoRepository(EstoqueServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto> GetByCodigoAsync(string codigo)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public async Task Add(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
