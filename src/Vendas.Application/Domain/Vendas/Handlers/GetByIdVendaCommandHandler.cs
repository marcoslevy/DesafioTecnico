using MediatR;
using Vendas.Application.Domain.Vendas.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Vendas.Handlers;

public class GetByIdVendaCommandHandler : IRequestHandler<GetByIdVendaCommand, ResultViewModel<VendaByIdViewModel>>
{
    private readonly IVendaRepository _repository;

    public GetByIdVendaCommandHandler(IVendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<VendaByIdViewModel>> Handle(GetByIdVendaCommand request, CancellationToken cancellationToken)
    {
        var venda = await _repository.GetDetailsByIdAsync(request.Id);

        if (venda is null)
            return ResultViewModel<VendaByIdViewModel>.Error("Venda não encontrada.");

        var model = VendaByIdViewModel.Instance(venda);

        return ResultViewModel<VendaByIdViewModel>.Success(model);
    }
}
