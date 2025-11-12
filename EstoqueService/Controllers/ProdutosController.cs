using EstoqueService.DTOs;
using EstoqueService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoOutputDTO>>> Get()
        {
            var produtos = await _produtoService.GetAllProdutos();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoInputDTO produto)
        {
            await _produtoService.CriarProdutoAsync(produto);
            return CreatedAtAction(nameof(Get), produto);
        }


        [HttpPatch("{id}/atualizar-saldo")]
        public async Task<ActionResult> AtualizarSaldo(int id, [FromBody] AtualizarSaldoInputDTO atualizarSaldoDTO)
        {
            await _produtoService.AtualizarSaldo(id, atualizarSaldoDTO.Quantidade);
            return Ok("produto atualizado com sucesso");
        }
    }
}
