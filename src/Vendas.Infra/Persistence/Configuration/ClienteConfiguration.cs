using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Core.Entities;

namespace Vendas.Infra.Persistence.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(r => new { r.Id });

        builder.Property(m => m.Nome)
            .IsRequired()
            .HasMaxLength(100);

    }
}
