using FaturamentoService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueService.Models
{
    public class ItemNota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NotaFiscalId { get; set; }

        [ForeignKey("NotaFiscalId")]
        public NotaFiscal NotaFiscal { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}
