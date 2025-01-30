using MediatR;
using System.Text.Json;
using Vendas.Application.Domain.Vendas.Commands;
using Vendas.Application.Models;
using Vendas.Application.Services;
using Vendas.Core.Repositories;

namespace Vendas.Application.Domain.Vendas.Handlers;

public class CloseVendaCommandHandler : IRequestHandler<CloseVendaCommand, ResultViewModel>
{
    private const string QueueName = "Vendas";
    private readonly IVendaRepository _repository;
    private readonly SendMessage _sendMessage;

    public CloseVendaCommandHandler(IVendaRepository repository, SendMessage sendMessage)
    {
        _repository = repository;
        _sendMessage = sendMessage;
    }

    public async Task<ResultViewModel> Handle(CloseVendaCommand request, CancellationToken cancellationToken)
    {
        var venda = await _repository.GetDetailsByIdAsync(request.Id);

        if (venda is null)
            return ResultViewModel<VendaViewModel>.Error("Venda não encontrado.");

        if (venda.DataStatus is not null)
        {
            switch (venda.Status)
            {
                case VendaEnum.Faturada:
                    return ResultViewModel.Error("Venda já está faturada.");
                case VendaEnum.Cancelada:
                    return ResultViewModel.Error("Venda já está cancelada.");
            }
        }
        var json = JsonSerializer.Serialize(VendaByIdViewModel.Instance(venda));
        var response = await _sendMessage.ExecuteAsync(QueueName, json);

        if (response != "Processed")
            return ResultViewModel<VendaViewModel>.Error("Não foi possivel faturar a venda.");

        venda.Faturar();

        _repository.Update(venda);
        await _repository.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
