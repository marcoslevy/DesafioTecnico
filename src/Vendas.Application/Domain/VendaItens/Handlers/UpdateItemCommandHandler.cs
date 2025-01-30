using MediatR;
using Vendas.Application.Domain.VendaItens.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.VendaItens.Handlers;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ResultViewModel>
{
    private readonly IVendaItemRepository _repositoryVendaItem;
    private readonly IVendaRepository _repositoryVenda;

    public UpdateItemCommandHandler(IVendaItemRepository repositoryVendaItem, IVendaRepository repositoryVenda)
    {
        _repositoryVendaItem = repositoryVendaItem;
        _repositoryVenda = repositoryVenda;
    }

    public async Task<ResultViewModel> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _repositoryVendaItem.GetByIdAsync(request.Id, request.VendaId, request.ProdutoId);

        if (item is null)
            return ResultViewModel.Error("Item da venda não encontrado.");

        var venda = await _repositoryVenda.GetByIdAsync(item.VendaId);

        if (venda is null)
            return ResultViewModel.Error("Venda não encontrada.");

        if (venda.DataStatus is not null)
        {
            switch (venda.Status)
            {
                case VendaEnum.Faturada:
                    return ResultViewModel.Error("Venda já está faturada.");
                case VendaEnum.Cancelada:
                    return ResultViewModel.Error("Venda já está cancelada.");
            }
        }

        item.Update(request.Quantidade, request.ValorUnitario);

        _repositoryVendaItem.Update(item);
        await _repositoryVendaItem.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
