namespace Vendas.Core.Entities;

public class Cliente : BaseEntity
{
    public Cliente(string nome)
    {
        Nome = nome;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }

    public virtual ICollection<Venda> Vendas { get; set; }

    public void Update(string nome)
    {
        Nome = nome;
    }

    public void SetId(int id)
    {
        Id = id;
    }
}
