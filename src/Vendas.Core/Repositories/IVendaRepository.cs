using Vendas.Core.Entities;

namespace Vendas.Core.Repositories;

public interface IVendaRepository : IRepository<Venda>
{
    Task<Venda> GetDetailsByIdAsync(int id);
}
