using MediatR;
using Vendas.Application.Domain.Produtos.Commands;
using Vendas.Application.Models;

namespace Vendas.Application.Domain.Produtos.Validations;

public class InsertProdutoCommandValidator : IPipelineBehavior<InsertProdutoCommand, ResultViewModel<int>>
{
    public async Task<ResultViewModel<int>> Handle(InsertProdutoCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Descricao))
            return ResultViewModel<int>.Error("O descrição do produto é obrigatorio.");

        if (request.ValorUnitario.Equals(0))
            return ResultViewModel<int>.Error("O valor unitário deve ser maior que zero.");

        return await next();
    }
}

