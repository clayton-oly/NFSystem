using FaturamentoService.DTOs;
using FaturamentoService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FaturamentoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly INotaFiscalService _notaFiscalService;

        public NotasController(INotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaFiscalOutputDTO>>> Get()
        {
            var notas = await _notaFiscalService.GetAll();
            return Ok(notas);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NotaFiscalInputDTO notaFiscal)
        {
            await _notaFiscalService.CriarNotaAsync(notaFiscal);
            return CreatedAtAction(nameof(Get), notaFiscal);
        }

        [HttpPatch("{id}/imprimir")]
        public async Task<IActionResult> FecharNota(int id)
        {
            var sucesso = await _notaFiscalService.FecharNotaAsync(id);
            if (!sucesso) return BadRequest("Não foi possível fechar a nota.");

            return Ok("Nota fiscal fechada com sucesso.");
        }

        [HttpGet("proximo-numero")]
        public IActionResult GetProximoNumero()
        {
            var proximoNumero = _notaFiscalService.GetProximoNumero();
            return Ok(proximoNumero);
        }
    }
}
