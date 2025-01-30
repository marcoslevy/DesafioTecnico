using Microsoft.EntityFrameworkCore;
using Vendas.Core.Entities;
using Vendas.Core.Repositories;

namespace Vendas.Infra.Persistence.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly VendasDbContext _context;

    public ClienteRepository(VendasDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Cliente entity)
    {
        await _context.Clientes.AddAsync(entity);
    }

    public void Delete(Cliente entity)
    {
        _context.Remove(entity);
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> GetByIdAsync(object id)
    {
        return await _context.Clientes.SingleOrDefaultAsync(i => i.Id == (int)id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Cliente entity)
    {
        _context.Update(entity);
    }
}
