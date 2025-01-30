using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Vendas.Commands;

public class UpdateVendaCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
}
