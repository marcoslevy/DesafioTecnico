using MediatR;
using Vendas.Application.Domain.Produtos.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Produtos.Handlers;

public class UpdatePodutoCommandHandler : IRequestHandler<UpdatePodutoCommand, ResultViewModel>
{
    private readonly IProdutoRepository _repository;

    public UpdatePodutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(UpdatePodutoCommand request, CancellationToken cancellationToken)
    {
        var produto = await _repository.GetByIdAsync(request.Id);

        if (produto is null)
            return ResultViewModel.Error("Cliente não encontrado");

        produto.Update(request.Descricao, request.ValorUnitario);

        _repository.Update(produto);
        await _repository.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
