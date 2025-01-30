using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Core.Entities;

namespace Vendas.Infra.Persistence.Configuration;

public class VendaItemConfiguration : IEntityTypeConfiguration<VendaItem>
{
    public void Configure(EntityTypeBuilder<VendaItem> builder)
    {
        builder.HasKey(v => new { v.Id });

        builder.HasOne(vi => vi.Venda)
            .WithMany(v => v.Itens)
            .HasForeignKey(vi => vi.VendaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(vi => vi.Produto)
            .WithMany(p => p.VendaItens)
            .HasForeignKey(vi => vi.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
