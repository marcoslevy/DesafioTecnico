using MediatR;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Clientes.Handlers;

public class GetAllClienteCommandHandler : IRequestHandler<GetAllClienteCommand, ResultViewModel<List<ClienteViewModel>>>
{
    private readonly IClienteRepository _repository;

    public GetAllClienteCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<ClienteViewModel>>> Handle(GetAllClienteCommand request, CancellationToken cancellationToken)
    {
        var clientes = await _repository.GetAllAsync();

        var model = clientes.Select(ClienteViewModel.Instance).ToList();

        return ResultViewModel<List<ClienteViewModel>>.Success(model);
    }
}
