using EstoqueService.Models;
using System.ComponentModel.DataAnnotations;

namespace FaturamentoService.Models
{
    public class NotaFiscal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Status { get; set; } = "Aberta"; 


        public ICollection<ItemNota> Itens { get; set; } = new List<ItemNota>();

    }
}
