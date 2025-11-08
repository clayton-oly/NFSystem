using EstoqueService.Models;
using FaturamentoService.DTOs;
using FaturamentoService.Interfaces;
using FaturamentoService.Models;
using Newtonsoft.Json;
using System.Text;

namespace FaturamentoService.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly HttpClient _httpClient;
        private readonly INotaFiscalRepository _notaFiscalRepository;
        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository, HttpClient httpClient)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:5000");
        }

        //public async Task<NotaFiscal> CriarNotaAsync(NotaFiscal novaNota)
        //{
        //    int ultimoNumero = await _context.NotasFiscais
        //        .OrderByDescending(n => n.Numero)
        //        .Select(n => n.Numero)
        //        .FirstOrDefaultAsync();

        //    novaNota.Numero = ultimoNumero + 1; // Se não tiver nenhuma, será 0 + 1 = 1
        //    novaNota.Status = "Aberta";

        //    _context.NotasFiscais.Add(novaNota);
        //    await _context.SaveChangesAsync();

        //    return novaNota;
        //}

        public async Task CriarNotaAsync(NotaFiscalInputDTO notaFiscalInputDTO)
        {
            var nota = new NotaFiscal
            {
                Numero = notaFiscalInputDTO.Numero,
                Status = "Aberta",
                Itens = notaFiscalInputDTO.Itens.Select(i => new ItemNota
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade
                }).ToList()
            };

            await _notaFiscalRepository.Add(nota);
        }

        public async Task<IEnumerable<NotaFiscalOutputDTO>> GetAll()
        {
            var notas = await _notaFiscalRepository.GetAll();
            return notas.Select(notaFiscal => new NotaFiscalOutputDTO
            {
                Id = notaFiscal.Id,
                Numero = notaFiscal.Numero,
                Status = notaFiscal.Status
            });
        }

        public async Task<bool> FecharNotaAsync(int id)
        {
            var nota = await _notaFiscalRepository.GetById(id);
            if (nota == null || nota.Status != "Aberta")
                return false;

            foreach (var item in nota.Itens)
            {
                await AtualizarSaldoProdutoAsync(item.ProdutoId, item.Quantidade);
            }

            nota.Status = "Fechada";
            await _notaFiscalRepository.Update(nota);

            return true;
        }

        public async Task AtualizarSaldoProdutoAsync(int produtoId, int novoSaldo)
        {
            var dto = new AtualizarSaldoDTO { Quantidade = novoSaldo };
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync($"/api/produtos/{produtoId}/atualizar-saldo", content);

            response.EnsureSuccessStatusCode();
        }

    }
}
