using EstoqueService.DTOs;
using EstoqueService.Interfaces;
using EstoqueService.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueService.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoOutputDTO>> GetAllProdutos()
        {
            var produtos = await _produtoRepository.GetAllProdutos();
            return produtos.Select(p => new ProdutoOutputDTO
            {
                Id = p.Id,
                Descricao = p.Descricao,
                Codigo = p.Codigo,
                Saldo = p.Saldo
            });
        }

        public async Task CriarProdutoAsync(ProdutoInputDTO produtoInputDTO)
        {
            var existente = await _produtoRepository.GetByCodigoAsync(produtoInputDTO.Codigo);
            if (existente != null)
                throw new InvalidOperationException("Já existe um produto com esse código.");

            var produto = new Produto
            {
                Codigo = produtoInputDTO.Codigo,
                Descricao = produtoInputDTO.Descricao,
                Saldo = produtoInputDTO.Saldo
            };

            await _produtoRepository.Add(produto);
        }

        public async Task AtualizarSaldo(int id, int quantidade)
        {
            var produto = await _produtoRepository.GetById(id);

            if (produto == null)
                throw new KeyNotFoundException("Produto não encontrado.");

            if (quantidade < 0)
                throw new ArgumentException("O saldo não pode ser negativo.");

            if (produto.Saldo < quantidade)
                throw new InvalidOperationException(
                    $"Não foi possível atualizar o saldo do produto '{produto.Descricao}'. " +
                    $"Quantidade solicitada: {quantidade}, disponível em estoque: {produto.Saldo}."
                );

            try
            {
                produto.Saldo -= quantidade;
                await _produtoRepository.Update(produto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Conflito ao atualizar o saldo do produto. Outra operação alterou este produto simultaneamente. Tente novamente.");
            }
        }

        public Task<ProdutoOutputDTO> GetProdutoByIdAsync(int id)
        {
           var produto =  _produtoRepository.GetById(id);


            var produtoOutputDTO = new ProdutoOutputDTO
            {
                Id = produto.Result.Id,
                Descricao = produto.Result.Descricao,
                Codigo = produto.Result.Codigo,
                Saldo = produto.Result.Saldo
            };

            return Task.FromResult(produtoOutputDTO);
        }
    }
}
