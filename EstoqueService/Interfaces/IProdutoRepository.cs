using EstoqueService.Models;

namespace EstoqueService.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAllProdutos();
        Task<Produto> GetById(int id);
        Task<Produto> GetByCodigoAsync(string codigo);
        Task Add(Produto produto);
        Task Update(Produto produto);

    }
}
