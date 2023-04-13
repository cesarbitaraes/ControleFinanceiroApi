using System.Text.Json.Serialization;

namespace ControleFinanceiroApi.Models;

public class TipoPagamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    [JsonPropertyName("dia_vencimento")]
    public int? DiaVencimento { get; set; }
}