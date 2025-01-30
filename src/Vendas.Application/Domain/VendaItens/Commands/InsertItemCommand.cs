using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.VendaItens.Commands;

public class InsertItemCommand : IRequest<ResultViewModel>
{
    public int VendaId { get; set; }
    public int ProdutoId { get; set; }
    public decimal Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
}
