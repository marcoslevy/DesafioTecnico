using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Domain.VendaItens.Commands;
using Vendas.Application.Domain.Vendas.Commands;

namespace Vendas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VendaItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendaItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertItemCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        var venda = await _mediator.Send(new GetByIdVendaCommand(command.VendaId));

        return Ok(venda);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateItemCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteItemCommand(id));

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return NoContent();
    }
}
