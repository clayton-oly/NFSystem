using FaturamentoService.DTOs;

namespace FaturamentoService.Interfaces
{
    public interface INotaFiscalService
    {
        Task<IEnumerable<NotaFiscalOutputDTO>> GetAll();
        Task<NotaFiscalOutputDTO>GetByIdAsync(int id);
        Task CriarNotaAsync(NotaFiscalInputDTO notaFiscal);
        Task AtualizarNotaAsync(int id, NotaFiscalInputDTO notaFiscalInputDTO);
        Task<bool> FecharNotaAsync(int id);
        int GetProximoNumero();
    }
}
