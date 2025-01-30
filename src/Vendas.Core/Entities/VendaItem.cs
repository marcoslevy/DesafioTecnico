namespace Vendas.Core.Entities;

public class VendaItem : BaseEntity
{
    public VendaItem(Guid id, int vendaId, int produtoId, decimal quantidade, decimal valorUnitario, decimal valorTotal)
    {
        Id = id;
        VendaId = vendaId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
        ValorTotal = valorTotal;
    }

    public Guid Id { get; private set; }
    public int VendaId { get; private set; }
    public int ProdutoId { get; private set; }
    public decimal Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public decimal ValorTotal { get; private set; }
    
    public virtual Venda Venda { get; private set; }
    public virtual Produto Produto { get; private set; }

    public void Update(decimal quantidade, decimal valorUnitario)
    {
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
        ValorTotal = quantidade * valorUnitario;
    }
}
