using Vendas.Core.Entities;
using Xunit;

namespace Vendas.UnitTests.Core;

public class VendaItemTest
{
    [Fact]
    public void Construtor_DeveConfigurarPropriedadesCorretamente()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        int vendaId = 1;
        int produtoId = 1;
        decimal quantidade = 1;
        decimal valorUnitario = 10;
        decimal valorTotal = 10;

        // Act
        var vendaItem = new VendaItem(id, vendaId, produtoId, quantidade, valorUnitario, valorTotal);

        // Assert
        Assert.Equal(id, vendaItem.Id);
        Assert.Equal(vendaId, vendaItem.VendaId);
        Assert.Equal(produtoId, vendaItem.ProdutoId);
        Assert.Equal(quantidade, vendaItem.Quantidade);
        Assert.Equal(valorUnitario, vendaItem.ValorUnitario);
        Assert.Equal(valorTotal, vendaItem.ValorTotal);
    }

    [Fact]
    public void Update_DeveAtualizarQuantidadeValorUnitarioEValorTotal()
    {
        // Arrange
        var vendaItem = new VendaItem(Guid.NewGuid(), 1, 1, 1, 10, 20);
        decimal novaQuantidade = 2;
        decimal novoValorUnitario = 15;

        // Act
        vendaItem.Update(novaQuantidade, novoValorUnitario);

        // Assert
        Assert.Equal(novaQuantidade, vendaItem.Quantidade);
        Assert.Equal(novoValorUnitario, vendaItem.ValorUnitario);
        Assert.Equal(novaQuantidade * novoValorUnitario, vendaItem.ValorTotal);
    }
}
