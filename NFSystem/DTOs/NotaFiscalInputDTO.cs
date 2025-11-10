using System.ComponentModel.DataAnnotations;

namespace FaturamentoService.DTOs
{
    public class NotaFiscalInputDTO
    {
        public string Numero { get; set; }
        public string Status { get; set; } = "Aberta";
        public List<ItemNotaFiscalDTO> Itens { get; set; } = new();
    }
}
