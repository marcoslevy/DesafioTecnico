using Microsoft.EntityFrameworkCore;
using Vendas.Core.Entities;
using Vendas.Core.Repositories;

namespace Vendas.Infra.Persistence.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly VendasDbContext _context;

    public VendaRepository(VendasDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Venda entity)
    {
        await _context.Vendas.AddAsync(entity);
    }

    public void Delete(Venda entity)
    {
        _context.Remove(entity);
    }

    public async Task<List<Venda>> GetAllAsync()
    {
        return await _context.Vendas
            .Include(i => i.Itens)
            .ToListAsync();
    }

    public async Task<Venda> GetByIdAsync(object id)
    {
        return await _context.Vendas.SingleOrDefaultAsync(i => i.Id == (int)id);
    }

    public async Task<Venda> GetDetailsByIdAsync(int id)
    {
        return await _context.Vendas
            .Include(c => c.Cliente)
            .Include(i => i.Itens)
                .ThenInclude(i=>i.Produto)
            .SingleOrDefaultAsync(v => v.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Venda entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Update(entity);
    }
}
