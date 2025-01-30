using MediatR;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Produtos.Commands;

public class GetAllProdutoCommand : IRequest<ResultViewModel<List<ProdutoViewModel>>>
{
}
