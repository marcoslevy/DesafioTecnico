using MediatR;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Clientes.Handlers;

public class GetByIdClienteCommandHandler : IRequestHandler<GetByIdClienteCommand, ResultViewModel<ClienteViewModel>>
{
    private readonly IClienteRepository _repository;

    public GetByIdClienteCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<ClienteViewModel>> Handle(GetByIdClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repository.GetByIdAsync(request.Id);

        if (cliente is null)
            return ResultViewModel<ClienteViewModel>.Error("Cliente não encontrado.");

        var model = ClienteViewModel.Instance(cliente);

        return ResultViewModel<ClienteViewModel>.Success(model);
    }
}
