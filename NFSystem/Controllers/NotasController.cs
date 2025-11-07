using FaturamentoService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FaturamentoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        //GET /api/notas → listar notas
        [HttpGet]
        public ActionResult<IEnumerable<NotaFiscalOutputDTO>> Get()
        {
            return Ok();
        }

        //POST /api/notas
        [HttpPost]
        public ActionResult Post([FromBody] NotaFiscalInputDTO notaFiscal)
        {
            //return CreatedAtAction(nameof(Get), new { id = notaFiscal.Id }, notaFiscal);
            return Ok();
        }

        //POST /api/notas/{id}/fechar
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NotaFiscalInputDTO notaFiscal)
        {
            //if (id != notaFiscal.Id)
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
