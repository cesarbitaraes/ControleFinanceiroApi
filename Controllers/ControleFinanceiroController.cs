using ControleFinanceiroApi.Data;
using ControleFinanceiroApi.Extensions;
using ControleFinanceiroApi.Models;
using ControleFinanceiroApi.ViewModels;
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

    [HttpPost("v1/tipo_gasto")]
    public async Task<IActionResult> PostGastosAsync(
        [FromServices] ApiDataContext context,
        [FromBody] TipoGastoViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<TipoGasto>(ModelState.GetErrors()));

        try
        {
            var tipoGasto = new TipoGasto
            {
                Id = 0,
                Descricao = model.Descricao
            };

            await context.TiposGastos!.AddAsync(tipoGasto);
            await context.SaveChangesAsync();

            return Created($"v1/tipo_gasto/{tipoGasto.Id}", new ResultViewModel<TipoGasto>(tipoGasto));
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, new ResultViewModel<TipoGasto>("Não foi possível incluir esse tipo de gasto"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<TipoGasto>("Falha interna no servidor."));
        }
    }
        
}