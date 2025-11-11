using EstoqueService.DTOs;

namespace EstoqueService.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoOutputDTO>> GetAllProdutos();
        Task CriarProdutoAsync(ProdutoInputDTO produto);
        Task AtualizarSaldo(int id, int novoSaldo);
        Task<ProdutoOutputDTO> GetProdutoByIdAsync(int id);
    }
}
