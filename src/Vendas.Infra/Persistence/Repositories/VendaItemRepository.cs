using Microsoft.EntityFrameworkCore;
using Vendas.Core.Entities;
using Vendas.Core.Repositories;

namespace Vendas.Infra.Persistence.Repositories;

public class VendaItemRepository : IVendaItemRepository
{
    private readonly VendasDbContext _context;

    public VendaItemRepository(VendasDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(VendaItem entity)
    {
        await _context.VendaItens.AddAsync(entity);
    }

    public void Delete(VendaItem entity)
    {
        _context.Remove(entity);
    }

    public async Task<List<VendaItem>> GetAllAsync()
    {
        return await _context.VendaItens.ToListAsync();
    }

    public async Task<VendaItem> GetByIdAsync(object id)
    {
        return await _context.VendaItens.SingleOrDefaultAsync(i => i.Id == (Guid)id);
    }

    public async Task<VendaItem> GetByIdAsync(Guid id, int vendaId, int produtoId)
    {
        return await _context.VendaItens.SingleOrDefaultAsync(i => i.Id == id && i.VendaId == vendaId && i.ProdutoId == produtoId);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(VendaItem entity)
    {
        _context.Update(entity);
    }
}
