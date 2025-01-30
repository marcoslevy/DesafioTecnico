using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Vendas.Commands;

public class GetByIdVendaCommand : IRequest<ResultViewModel<VendaByIdViewModel>>
{
    public GetByIdVendaCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
