using MediatR;
using Vendas.Application.Domain.Vendas.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Vendas.Validations;

public class UpdateVendaCommandValidator : IPipelineBehavior<UpdateVendaCommand, ResultViewModel>
{
    private readonly IClienteRepository _repository;

    public UpdateVendaCommandValidator(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(UpdateVendaCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
    {
        var cliente = await _repository.GetByIdAsync(request.ClienteId);

        if (cliente is null)
            return ResultViewModel<VendaViewModel>.Error("Cliente não encontrado.");

        return await next();
    }
}
