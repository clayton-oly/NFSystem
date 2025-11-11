using FaturamentoService.Models;

namespace FaturamentoService.Interfaces
{
    public interface INotaFiscalRepository
    {
        Task<IEnumerable<NotaFiscal>> GetAll();
        Task<NotaFiscal> GetById(int id);
        Task Add(NotaFiscal notaFiscal);
        Task Update(NotaFiscal notaFiscal);
        int GetProximoNumero();
    }
}
