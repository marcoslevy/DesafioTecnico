using MediatR;
using Vendas.Application.Domain.Vendas.Commands;
using Vendas.Application.Models;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Vendas.Handlers;

public class InsertVendaCommandHandler : IRequestHandler<InsertVendaCommand, ResultViewModel<VendaViewModel>>
{
    private readonly IVendaRepository _repositoryVenda;
    private readonly IClienteRepository _repositoryCliente;

    public InsertVendaCommandHandler(IVendaRepository repository, IClienteRepository repositoryCliente)
    {
        _repositoryVenda = repository;
        _repositoryCliente = repositoryCliente;
    }

    public async Task<ResultViewModel<VendaViewModel>> Handle(InsertVendaCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repositoryCliente.GetByIdAsync(request.ClienteId);

        if (cliente is null)
            return ResultViewModel<VendaViewModel>.Error("Cliente não encontrado.");

        var venda = request.ToEntity();

        await _repositoryVenda.AddAsync(venda);
        await _repositoryVenda.SaveChangesAsync();

        var model = VendaViewModel.Instance(venda);

        return ResultViewModel<VendaViewModel>.Success(model);
    }
}
