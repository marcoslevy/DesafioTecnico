using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Clientes.Commands;

public class GetAllClienteCommand : IRequest<ResultViewModel<List<ClienteViewModel>>>
{
}
