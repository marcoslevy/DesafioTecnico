using MediatR;
using Vendas.Application.Domain.Produtos.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Produtos.Handlers;

public class GetByIdProdutoCommandHandler : IRequestHandler<GetByIdProdutoCommand, ResultViewModel<ProdutoViewModel>>
{
    private readonly IProdutoRepository _repository;

    public GetByIdProdutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<ProdutoViewModel>> Handle(GetByIdProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = await _repository.GetByIdAsync(request.Id);

        if (produto is null)
            return ResultViewModel<ProdutoViewModel>.Error("Produto não encontrado.");

        var model = ProdutoViewModel.Instance(produto);

        return ResultViewModel<ProdutoViewModel>.Success(model);
    }
}
