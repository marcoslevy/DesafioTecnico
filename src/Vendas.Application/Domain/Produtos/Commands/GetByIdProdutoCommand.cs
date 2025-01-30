using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Produtos.Commands;

public class GetByIdProdutoCommand : IRequest<ResultViewModel<ProdutoViewModel>>
{
    public GetByIdProdutoCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
