using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Vendas.Commands;

public class GetAllVendaCommand : IRequest<ResultViewModel<List<VendaViewModel>>>
{
}
