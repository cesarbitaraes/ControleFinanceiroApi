using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiroApi.ViewModels;

public class TipoGastoViewModel
{
    [Required(ErrorMessage = "A descrição do gasto é necessária.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Esse campo deve conter entre 3 e 50 caracteres.")]
    public string Descricao { get; set; }
}