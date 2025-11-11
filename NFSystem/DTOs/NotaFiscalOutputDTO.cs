namespace FaturamentoService.DTOs
{
    public class NotaFiscalOutputDTO
    {
        public int Id { get; set; }

        public int Numero { get; set; } 

        public string Status { get; set; }

        public List<ItemNotaFiscalDTO> Itens { get; set; } = new();
    }
}
