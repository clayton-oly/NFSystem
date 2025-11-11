using System.ComponentModel.DataAnnotations;

namespace EstoqueService.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O código do produto é obrigatório.")]
        [StringLength(14, ErrorMessage = "O código pode ter no máximo 14 caracteres.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        [StringLength(100, ErrorMessage = "A descrição pode ter no máximo 100 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantidade disponível em estoque é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int Saldo { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
