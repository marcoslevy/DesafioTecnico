using Vendas.Core.Entities;

namespace Vendas.Application.Models;

public class VendaItemViewModel
{
    public VendaItemViewModel(Guid id, int vendaId, decimal quantidade, decimal valorUnitario, decimal valorTotal, ProdutoItemVendaViewModel produto)
    {
        Id = id;
        VendaId = vendaId;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
        ValorTotal = valorTotal;
        Produto = produto;
    }

    public Guid Id { get; set; }
    public int VendaId { get; set; }
    public decimal Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; }
    public ProdutoItemVendaViewModel Produto { get; set; }

    public static VendaItemViewModel Instance(VendaItem item)
        => new(item.Id, item.VendaId, item.Quantidade, item.ValorUnitario, item.ValorTotal, ProdutoItemVendaViewModel.Instance(item.Produto));
}
