using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Vendas.Commands;

public class CancelVendaCommand : IRequest<ResultViewModel>
{
    public CancelVendaCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
