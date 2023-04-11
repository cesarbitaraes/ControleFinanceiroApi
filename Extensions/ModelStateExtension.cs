using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControleFinanceiroApi.Extensions;

public static class ModelStateExtension
{
    public static List<string> GetErrors(this ModelStateDictionary modelState)
    {
        var result = new List<string>();
        foreach (var modelStateValue in modelState.Values)
        {
            result.AddRange(modelStateValue.Errors.Select(error => error.ErrorMessage));
        }

        return result;
    }
}