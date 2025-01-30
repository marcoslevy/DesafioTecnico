using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Clientes.Commands;

public class DeleteClienteCommand : IRequest<ResultViewModel>
{
    public DeleteClienteCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
