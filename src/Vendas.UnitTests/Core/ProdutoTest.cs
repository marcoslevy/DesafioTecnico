using Vendas.Core.Entities;
using Xunit;

namespace Vendas.UnitTests.Core;

public class ProdutoTest
{
    [Fact]
    public void Construtor_DeveConfigurarPropriedadeCorretamente()
    {
        // Arrange
        string descricao = "Produto 01";
        decimal valorUnitario = 50;

        // Act
        var produto = new Produto(descricao, valorUnitario);

        // Assert
        Assert.Equal(descricao, produto.Descricao);
        Assert.Equal(valorUnitario, produto.ValorUnitario);
    }

    [Fact]
    public void Update_DeveAtualizarDescricaoEValorUnitario()
    {
        // Arrange
        var produto = new Produto("Produto 01", 50);
        string novaDescricao = "Produto 02";
        decimal novoValorUnitario = 55;

        // Act
        produto.Update(novaDescricao, novoValorUnitario);

        // Assert
        Assert.Equal(novaDescricao, produto.Descricao);
        Assert.Equal(novoValorUnitario, produto.ValorUnitario);
    }
}
