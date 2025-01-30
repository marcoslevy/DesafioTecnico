using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Clientes.Commands;

public class GetByIdClienteCommand : IRequest<ResultViewModel<ClienteViewModel>>
{
    public GetByIdClienteCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
