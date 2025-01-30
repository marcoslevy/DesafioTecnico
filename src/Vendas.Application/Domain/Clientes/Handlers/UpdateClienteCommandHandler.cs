using MediatR;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Clientes.Handlers;

public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, ResultViewModel>
{
    private readonly IClienteRepository _repository;

    public UpdateClienteCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repository.GetByIdAsync(request.Id);

        if (cliente is null)
            return ResultViewModel.Error("Cliente não encontrado");

        cliente.Update(request.Nome);

        _repository.Update(cliente);
        await _repository.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
