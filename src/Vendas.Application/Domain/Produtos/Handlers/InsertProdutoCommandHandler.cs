using MediatR;
using Vendas.Application.Domain.Produtos.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Produtos.Handlers;

public class InsertProdutoCommandHandler : IRequestHandler<InsertProdutoCommand, ResultViewModel<ProdutoViewModel>>
{
    private readonly IProdutoRepository _repository;

    public InsertProdutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<ProdutoViewModel>> Handle(InsertProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = request.ToEntity();

        await _repository.AddAsync(produto);
        await _repository.SaveChangesAsync();

        var model = ProdutoViewModel.Instance(produto);

        return ResultViewModel<ProdutoViewModel>.Success(model);
    }
}
