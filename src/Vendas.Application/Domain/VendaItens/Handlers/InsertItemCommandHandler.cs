using MediatR;
using Vendas.Application.Domain.VendaItens.Commands;
using Vendas.Application.Models;
using Vendas.Core.Entities;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.VendaItens.Handlers;

public class InsertItemCommandHandler : IRequestHandler<InsertItemCommand, ResultViewModel>
{
    private readonly IVendaRepository _repositoryVenda;
    private readonly IProdutoRepository _repositoryProduto;
    private readonly IVendaItemRepository _repositoryVendaItem;

    public InsertItemCommandHandler(IVendaRepository repositoryVenda, IProdutoRepository repositoryProduto, IVendaItemRepository repositoryVendaItem)
    {
        _repositoryVenda = repositoryVenda;
        _repositoryVendaItem = repositoryVendaItem;
        _repositoryProduto = repositoryProduto;
    }

    public async Task<ResultViewModel> Handle(InsertItemCommand request, CancellationToken cancellationToken)
    {
        var venda = await _repositoryVenda.GetByIdAsync(request.VendaId);

        if (venda is null)
            return ResultViewModel.Error("Venda não encontrada.");

        var produto = await _repositoryProduto.GetByIdAsync(request.ProdutoId);

        if (produto is null)
            return ResultViewModel.Error("Produto não encontrado.");

        var entity = new VendaItem(Guid.NewGuid(), request.VendaId, request.ProdutoId, request.Quantidade, produto.ValorUnitario, request.Quantidade * produto.ValorUnitario);

        await _repositoryVendaItem.AddAsync(entity);
        await _repositoryVendaItem.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
