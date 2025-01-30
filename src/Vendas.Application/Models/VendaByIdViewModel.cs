using Vendas.Core.Entities;

namespace Vendas.Application.Models;

public class VendaByIdViewModel
{
    public VendaByIdViewModel(int id, DateTime data, VendaEnum status, ClienteViewModel cliente, List<VendaItemViewModel> itens)
    {
        Id = id;
        Data = data;
        Cliente = cliente;
        Itens = itens;
        Status = status;
    }

    public int Id { get; set; }
    public DateTime Data { get; set; }
    public VendaEnum Status { get; set; }
    public decimal ValorTotal { get { return Itens.Sum(i => i.ValorTotal); } }
    public int TotalItens { get { return Itens.Count; } }
    public ClienteViewModel Cliente { get; set; }
    public List<VendaItemViewModel> Itens { get; set; }

    public static VendaByIdViewModel Instance(Venda venda)
        => new(venda.Id, venda.Data, venda.Status, ClienteViewModel.Instance(venda.Cliente), venda.Itens.Select(VendaItemViewModel.Instance).ToList());
}
