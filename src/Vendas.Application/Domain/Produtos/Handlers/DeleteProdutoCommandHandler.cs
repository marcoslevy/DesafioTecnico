using MediatR;
using Vendas.Application.Domain.Produtos.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Produtos.Handlers;

public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, ResultViewModel>
{
    private readonly IProdutoRepository _repository;

    public DeleteProdutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = await _repository.GetByIdAsync(request.Id);

        if (produto is null)
            return ResultViewModel.Error("Produto não encontrado");

        _repository.Delete(produto);
        await _repository.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
