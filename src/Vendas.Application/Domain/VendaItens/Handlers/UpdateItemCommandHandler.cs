using MediatR;
using Vendas.Application.Domain.VendaItens.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.VendaItens.Handlers;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ResultViewModel>
{
    private readonly IVendaItemRepository _repository;

    public UpdateItemCommandHandler(IVendaItemRepository repositoryVendaItem)
    {
        _repository = repositoryVendaItem;
    }

    public async Task<ResultViewModel> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, request.VendaId, request.ProdutoId);

        if (item is null)
            return ResultViewModel.Error("Item da venda não encontrado.");

        item.Update(request.Quantidade, request.ValorUnitario);

        _repository.Update(item);
        await _repository.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
