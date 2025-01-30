using MediatR;
using Vendas.Application.Domain.VendaItens.Commands;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.VendaItens.Validations;

public class InsertItemCommandValidator : IPipelineBehavior<InsertItemCommand, ResultViewModel>
{
    public async Task<ResultViewModel> Handle(InsertItemCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
    {
        if (request.Quantidade <= 0)
            return ResultViewModel<int>.Error("A quantidade deve ser maior que zero.");

        return await next();
    }
}
