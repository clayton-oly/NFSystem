using System.ComponentModel.DataAnnotations;

namespace FaturamentoService.DTOs
{
    public class AtualizarSaldoDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "O saldo não pode ser negativo.")]
        public int Quantidade { get; set; }
    }
}
