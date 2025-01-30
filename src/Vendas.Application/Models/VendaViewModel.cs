using Vendas.Core.Entities;

namespace Vendas.Application.Models;

public class VendaViewModel
{
    public VendaViewModel(int id, DateTime data, int clienteId, VendaEnum status, decimal valoTotal)
    {
        Id = id;
        Data = data;
        ClienteId = clienteId;
        Status = status;
        ValorTotal = valoTotal;
    }

    public int Id { get; set; }
    public DateTime Data { get; set; }
    public int ClienteId { get; set; }
    public VendaEnum Status { get; set; }
    public decimal ValorTotal { get; set; }

    public static VendaViewModel Instance(Venda venda)
        => new(venda.Id, venda.Data, venda.ClienteId, venda.Status, venda.Itens is null ? 0 : venda.Itens.Sum(i => i.ValorTotal));
}
