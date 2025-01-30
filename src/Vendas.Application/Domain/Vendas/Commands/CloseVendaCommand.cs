using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Vendas.Commands;

public class CloseVendaCommand : IRequest<ResultViewModel>
{
    public CloseVendaCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
