using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Produtos.Commands;

public class DeleteProdutoCommand : IRequest<ResultViewModel>
{
    public DeleteProdutoCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
