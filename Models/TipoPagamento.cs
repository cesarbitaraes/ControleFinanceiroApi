namespace ControleFinanceiroApi.Models;

public class TipoPagamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime? Vencimento { get; set; }
}