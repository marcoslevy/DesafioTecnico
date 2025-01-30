using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Domain.Vendas.Commands;

namespace Vendas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VendaController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllVendaCommand());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetByIdVendaCommand(id));

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertVendaCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateVendaCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return NoContent();
    }

    [HttpPut("{id}/faturar")]
    public async Task<IActionResult> PutFaturar(int id)
    {
        var result = await _mediator.Send(new CloseVendaCommand(id));

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return NoContent();
    }

    [HttpPut("{id}/cancelar")]
    public async Task<IActionResult> PutCancelar(int id)
    {
        var result = await _mediator.Send(new CancelVendaCommand(id));

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return NoContent();
    }
}
