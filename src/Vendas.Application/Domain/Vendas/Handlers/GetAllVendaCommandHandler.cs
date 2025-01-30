using MediatR;
using Vendas.Application.Domain.Vendas.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Vendas.Handlers;

public class GetAllVendaCommandHandler : IRequestHandler<GetAllVendaCommand, ResultViewModel<List<VendaViewModel>>>
{
    private readonly IVendaRepository _repository;

    public GetAllVendaCommandHandler(IVendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<VendaViewModel>>> Handle(GetAllVendaCommand request, CancellationToken cancellationToken)
    {
        var vendas = await _repository.GetAllAsync();

        var model = vendas.Select(VendaViewModel.Instance).ToList();

        return ResultViewModel<List<VendaViewModel>>.Success(model);
    }
}
