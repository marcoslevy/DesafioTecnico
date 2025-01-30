using MediatR;
using Vendas.Application.Domain.Produtos.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Produtos.Handlers;

public class GetAllProdutoCommandHandler : IRequestHandler<GetAllProdutoCommand, ResultViewModel<List<ProdutoViewModel>>>
{
    private readonly IProdutoRepository _repository;

    public GetAllProdutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<ProdutoViewModel>>> Handle(GetAllProdutoCommand request, CancellationToken cancellationToken)
    {
        var produtos = await _repository.GetAllAsync();

        var model = produtos.Select(ProdutoViewModel.Instance).ToList();

        return ResultViewModel<List<ProdutoViewModel>>.Success(model);
    }
}
