using MediatR;
using Vendas.Application.Models;
using Vendas.Core.Entities;

namespace Vendas.Application.Domain.Clientes.Commands;

public class InsertClienteCommand : IRequest<ResultViewModel<ClienteViewModel>>
{
    public string Nome { get; set; }

    public Cliente ToEntity()
        => new(Nome);
}
