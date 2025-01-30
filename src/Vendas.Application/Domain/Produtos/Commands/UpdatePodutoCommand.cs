using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Produtos.Commands;

public class UpdatePodutoCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnitario { get; set; }
}
