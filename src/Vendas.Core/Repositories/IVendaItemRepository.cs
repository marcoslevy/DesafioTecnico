using Vendas.Core.Entities;

namespace Vendas.Core.Repositories;

public interface IVendaItemRepository : IRepository<VendaItem>
{
    Task<VendaItem> GetByIdAsync(Guid id, int vendaId, int produtoId);
}
