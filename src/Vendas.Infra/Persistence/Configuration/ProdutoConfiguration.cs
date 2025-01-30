using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Core.Entities;

namespace Vendas.Infra.Persistence.Configuration;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(r => new { r.Id });

        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();

        builder.Property(m => m.Descricao)
            .IsRequired()
            .HasMaxLength(100);
    }
}
