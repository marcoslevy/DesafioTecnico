namespace Vendas.Core.Entities;

public class Venda : BaseEntity
{
    public Venda(int clienteId)
    {
        ClienteId = clienteId;
        Data = DateTime.Now;
    }

    public int Id { get; private set; }
    public DateTime Data { get; private set; }
    public int ClienteId { get; private set; }
    public VendaEnum Status { get; set; }
    public DateTime? DataStatus { get; private set; }

    public virtual Cliente Cliente { get; set; }
    public virtual ICollection<VendaItem> Itens { get; set; }

    public void Update(int clienteId)
    {
        ClienteId = clienteId;
    }

    public void Faturar()
    {
        Status = VendaEnum.Faturada;
        DataStatus = DateTime.Now;
    }

    public void Cancelar()
    {
        Status = VendaEnum.Cancelada;
        DataStatus = DateTime.Now;
    }
}
