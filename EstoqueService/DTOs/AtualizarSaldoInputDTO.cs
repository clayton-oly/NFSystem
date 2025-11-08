using System.ComponentModel.DataAnnotations;

namespace EstoqueService.DTOs
{
    public class AtualizarSaldoInputDTO
    {
        [Required(ErrorMessage = "Quantidade disponível em estoque é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int Quantidade { get; set; }
    }
}
