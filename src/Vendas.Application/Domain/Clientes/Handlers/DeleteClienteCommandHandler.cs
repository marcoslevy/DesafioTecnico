using MediatR;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Clientes.Handlers;

public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, ResultViewModel>
{
    private readonly IClienteRepository _repository;

    public DeleteClienteCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repository.GetByIdAsync(request.Id);

        if (cliente is null)
            return ResultViewModel.Error("Cliente não encontrado");

        _repository.Delete(cliente);
        await _repository.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
