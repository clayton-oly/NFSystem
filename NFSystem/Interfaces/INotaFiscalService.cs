using FaturamentoService.DTOs;

namespace FaturamentoService.Interfaces
{
    public interface INotaFiscalService
    {
        Task<IEnumerable<NotaFiscalOutputDTO>> GetAll();
        Task CriarNotaAsync(NotaFiscalInputDTO notaFiscal);
        Task<bool> FecharNotaAsync(int id);
        string GetProximoNumero();
    }
}
