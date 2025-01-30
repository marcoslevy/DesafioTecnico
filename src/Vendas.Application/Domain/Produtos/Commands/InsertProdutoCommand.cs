using MediatR;
using Vendas.Application.Models;
using Vendas.Core.Entities;

namespace Vendas.Application.Domain.Produtos.Commands;

public class InsertProdutoCommand : IRequest<ResultViewModel<ProdutoViewModel>>
{
    public string Descricao { get; set; }
    public decimal ValorUnitario { get; set; }

    public Produto ToEntity()
        => new(Descricao, ValorUnitario);
}
