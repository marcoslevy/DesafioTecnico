using MediatR;
using Vendas.Application.Models;
using Vendas.Core.Entities;

namespace Vendas.Application.Domain.Vendas.Commands;

public class InsertVendaCommand : IRequest<ResultViewModel<VendaViewModel>>
{
    public int ClienteId { get; set; }

    public Venda ToEntity()
        => new(ClienteId);
}
