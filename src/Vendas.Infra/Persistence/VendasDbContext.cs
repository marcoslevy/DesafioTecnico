using Microsoft.EntityFrameworkCore;
using Vendas.Core.Entities;
using Vendas.Infra.Persistence.Configuration;

namespace Vendas.Infra.Persistence;

public class VendasDbContext : DbContext
{
    public VendasDbContext(DbContextOptions<VendasDbContext> options)
            : base(options)
    {

    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<VendaItem> VendaItens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        modelBuilder.ApplyConfiguration(new VendaItemConfiguration());
        modelBuilder.ApplyConfiguration(new VendaItemConfiguration());
    }
}
