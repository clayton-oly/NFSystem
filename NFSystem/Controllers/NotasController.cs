using FaturamentoService.DTOs;
using FaturamentoService.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<NotaFiscalOutputDTO>>> GetById(int id)
        {
            var nota = await _notaFiscalService.GetByIdAsync(id);
            return Ok(nota);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NotaFiscalInputDTO notaFiscal)
        {
            await _notaFiscalService.CriarNotaAsync(notaFiscal);
            return CreatedAtAction(nameof(GetById), notaFiscal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] NotaFiscalInputDTO notaFiscal)
        {
            if (notaFiscal == null)
                return BadRequest("Dados da nota fiscal inválidos.");

            await _notaFiscalService.AtualizarNotaAsync(id, notaFiscal);

            return NoContent();
        }




        [HttpPatch("{id}/imprimir")]
        public async Task<IActionResult> FecharNota(int id)
        {
            try
            {
                var sucesso = await _notaFiscalService.FecharNotaAsync(id);
                return Ok("Nota impressa com sucesso");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("proximo-numero")]
        public IActionResult GetProximoNumero()
        {
            var proximoNumero = _notaFiscalService.GetProximoNumero();
            return Ok(proximoNumero);
        }
    }
}
