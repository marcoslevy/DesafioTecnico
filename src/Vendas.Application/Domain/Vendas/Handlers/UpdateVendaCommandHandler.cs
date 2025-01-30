using MediatR;
using Vendas.Application.Domain.Vendas.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Vendas.Handlers;

public class UpdateVendaCommandHandler : IRequestHandler<UpdateVendaCommand, ResultViewModel>
{
    private readonly IVendaRepository _repository;    

    public UpdateVendaCommandHandler(IVendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(UpdateVendaCommand request, CancellationToken cancellationToken)
    {
        var venda = await _repository.GetByIdAsync(request.Id);

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

        venda.Update(request.ClienteId);

        _repository.Update(venda);
        await _repository.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
