using ControleFinanceiroApi.Data;
using ControleFinanceiroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiroApi.Controllers;

[ApiController]
[Route("controle_financeiro")]
public class ControleFinanceiroController : ControllerBase
{
    [HttpPost("v1/gastos")]
    public async Task<IActionResult> Post(
        [FromBody] Gasto gastoModel,
        [FromServices] ApiDataContext context)
    {
        var gasto = new Gasto
        {
            Descricao = gastoModel.Descricao,
            Valor = gastoModel.Valor
        };

        await context.Gastos.AddAsync(gasto);
        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("v1/gastos")]
    public async Task<IActionResult> GetAsync(
        [FromServices] ApiDataContext context)
    {
        var gastos = await context.Gastos.ToListAsync();

        return Ok(gastos);
    }
}