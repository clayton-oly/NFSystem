using EstoqueService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoOutputDTO>> Get()
        {
            return new List<ProdutoOutputDTO>
            {
                new ProdutoOutputDTO { Id = 1, Codigo = 101, Descricao = "Produto 1", Saldo = 10 },
                new ProdutoOutputDTO { Id = 2, Codigo = 102, Descricao = "Produto 2", Saldo = 20 }
            };
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutoInputDTO produto)
        {
            //return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProdutoInputDTO produto)
        {
            //if (id != produto.Id)
            //{
            //    return BadRequest();
            //}

            return NoContent();
        }

        [HttpPatch("{id}/atualizar-saldo")]
        public IActionResult AtualizarSaldo(int id, [FromBody] decimal novoSaldo)
        {
            return NoContent();
        }

    }
}
