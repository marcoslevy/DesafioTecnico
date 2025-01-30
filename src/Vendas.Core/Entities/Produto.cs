namespace Vendas.Core.Entities;

public class Produto : BaseEntity
{
    public Produto(string descricao, decimal valorUnitario)
    {
        Descricao = descricao;
        ValorUnitario = valorUnitario;
    }

    public int Id { get; private set; }
    public string Descricao { get; private set; }
    public decimal ValorUnitario { get; private set; }

    public virtual ICollection<VendaItem> VendaItens { get; set; }

    public void Update(string descricao, decimal valorUnitario)
    {
        Descricao = descricao;
        ValorUnitario = valorUnitario;
    }
}
