namespace Vendas.Core.Entities;

public abstract class BaseEntity
{
    public DateTime CreatedAt { get; private set; }

    protected BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }
}
