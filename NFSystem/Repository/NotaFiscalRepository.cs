using FaturamentoService.Data;
using FaturamentoService.Interfaces;
using FaturamentoService.Models;
using Microsoft.EntityFrameworkCore;

namespace FaturamentoService.Repository
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly FaturamentoServiceDbContext _context;

        public NotaFiscalRepository(FaturamentoServiceDbContext context)
        {
            _context = context;
        }

        public async Task Add(NotaFiscal notaFiscal)
        {
            await _context.NotasFiscais.AddAsync(notaFiscal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NotaFiscal nota)
        {
            _context.NotasFiscais.Update(nota);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NotaFiscal>> GetAll()
        {
            return await _context.NotasFiscais.ToListAsync();
        }

        public async Task<NotaFiscal> GetById(int id)
        {
            return await _context.NotasFiscais.Include(n => n.Itens).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task Update(NotaFiscal notaFiscal)
        {
            _context.NotasFiscais.Update(notaFiscal);
            await _context.SaveChangesAsync();
        }

        public int GetProximoNumero()
        {
            return _context.NotasFiscais
                .OrderByDescending(n => n.Numero)
                .Select(n => n.Numero)
                .FirstOrDefault();
        }
    }
}
