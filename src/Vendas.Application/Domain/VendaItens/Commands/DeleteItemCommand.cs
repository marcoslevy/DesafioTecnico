using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.VendaItens.Commands;

public class DeleteItemCommand : IRequest<ResultViewModel>
{
    public DeleteItemCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
