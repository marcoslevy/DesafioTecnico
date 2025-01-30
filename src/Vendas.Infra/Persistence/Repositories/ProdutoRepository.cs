using Microsoft.EntityFrameworkCore;
using Vendas.Core.Entities;
using Vendas.Core.Repositories;

namespace Vendas.Infra.Persistence.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly VendasDbContext _context;

    public ProdutoRepository(VendasDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Produto entity)
    {
        await _context.Produtos.AddAsync(entity);
    }

    public void Delete(Produto entity)
    {
        _context.Remove(entity);
    }

    public async Task<List<Produto>> GetAllAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto> GetByIdAsync(object id)
    {
        return await _context.Produtos.SingleOrDefaultAsync(i => i.Id == (int)id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Produto entity)
    {
        _context.Update(entity);
    }
}
