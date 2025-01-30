using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Clientes.Commands;

public class UpdateClienteCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
