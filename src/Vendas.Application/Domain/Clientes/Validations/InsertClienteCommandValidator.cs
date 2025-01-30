using MediatR;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Clientes.Validations;

public class InsertClienteCommandValidator : IPipelineBehavior<InsertClienteCommand, ResultViewModel<int>>
{
    public async Task<ResultViewModel<int>> Handle(InsertClienteCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
    {
        if(string.IsNullOrEmpty(request.Nome))
            return ResultViewModel<int>.Error("O nome do cliente é obrigatorio.");

        if (request.Nome.Length > 100)
            return ResultViewModel<int>.Error("O nome do cliente não pode exceder 100 caracteres.");

        return await next();
    }
}
