using MediatR;
using Vendas.Application.Domain.Vendas.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Vendas.Handlers;

public class CancelVendaCommandHanlder : IRequestHandler<CancelVendaCommand, ResultViewModel>
{
    private readonly IVendaRepository _repository;

    public CancelVendaCommandHanlder(IVendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(CancelVendaCommand request, CancellationToken cancellationToken)
    {
        var venda = await _repository.GetDetailsByIdAsync(request.Id);

        if (venda is null)
            return ResultViewModel<VendaViewModel>.Error("Venda não encontrado.");

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

        venda.Cancelar();

        _repository.Update(venda);
        await _repository.SaveChangesAsync();

        return ResultViewModel.Success();

    }
}
