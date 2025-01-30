using MediatR;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Clientes.Handlers;

public class InsertClienteCommandHandler : IRequestHandler<InsertClienteCommand, ResultViewModel<ClienteViewModel>>
{
    private readonly IClienteRepository _repository;

    public InsertClienteCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<ClienteViewModel>> Handle(InsertClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = request.ToEntity();

        await _repository.AddAsync(cliente);
        await _repository.SaveChangesAsync();

        var model = ClienteViewModel.Instance(cliente);

        return ResultViewModel<ClienteViewModel>.Success(model);
    }
}
