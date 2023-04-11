using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiroApi.ViewModels;

public class TipoPagamentoViewModel
{
    [Required(ErrorMessage = "O nome do pagamento é necessário.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Esse campo deve conter entre 3 e 50 caracteres.")]
    public string Nome { get; set; }
    public DateTime? Vencimento { get; set; }
}