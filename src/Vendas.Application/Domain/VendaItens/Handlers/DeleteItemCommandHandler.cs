using MediatR;
using Vendas.Application.Domain.VendaItens.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.VendaItens.Handlers;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, ResultViewModel>
{
    private readonly IVendaItemRepository _repository;

    public DeleteItemCommandHandler(IVendaItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id);

        if (item is null)
            return ResultViewModel.Error("Item da venda não encontrado.");

        _repository.Delete(item);
        await _repository.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
