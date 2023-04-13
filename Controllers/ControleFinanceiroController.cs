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
    public async Task<IActionResult> PostTiposGastosAsync(
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

    [HttpGet("v1/tipo_gasto")]
    public async Task<IActionResult> GetTiposGastosAsync(
        [FromServices] ApiDataContext context)
    {
        try
        {
            var tiposGastos = await context.TiposGastos.ToListAsync();

            return Ok(new ResultViewModel<List<TipoGasto>>(tiposGastos));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<TipoGasto>>("Falha interna no servidor."));
        }
    }

    [HttpPost("v1/tipo_pagamento")]
    public async Task<IActionResult> PostTipoPagamentoAsync(
        [FromServices] ApiDataContext context,
        [FromBody] TipoPagamentoViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<TipoPagamento>(ModelState.GetErrors()));
        try
        {
            var tipoPagamento = new TipoPagamento
            {
                Id = 0,
                Nome = model.Nome,
                DiaVencimento = model.DiaVencimento
            };

            await context.TiposPagamentos!.AddAsync(tipoPagamento);
            await context.SaveChangesAsync();
            
            return Created($"v1/tipo_gasto/{tipoPagamento.Id}", new ResultViewModel<TipoPagamento>(tipoPagamento));
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

    [HttpGet("v1/tipo_pagamento")]
    public async Task<IActionResult> GetTiposPagamentosAsync(
        [FromServices] ApiDataContext context)
    {
        try
        {
            var tiposPagamentos = await context.TiposPagamentos.ToListAsync();
            return Ok(new ResultViewModel<List<TipoPagamento>>(tiposPagamentos));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<TipoGasto>>("Falha interna no servidor."));
        }
    }
}