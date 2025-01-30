using Vendas.Core.Entities;
using Xunit;

namespace Vendas.UnitTests.Core;

public class ClienteTests
{
    [Fact]
    public void Construtor_DeveConfigurarPropriedadeCorretamente()
    {
        // Arrange
        string nome = "Marcos Levy";

        // Act
        var cliente = new Cliente(nome);

        // Assert
        Assert.Equal(nome, cliente.Nome);
    }

    [Fact]
    public void Update_DeveAtualizarDescricaoEValorUnitario()
    {
        // Arrange
        var cliente = new Cliente("Marcos Levy");
        string novoNome = "Marcos Levy Nunes da Silva";

        // Act
        cliente.Update(novoNome);

        // Assert
        Assert.Equal(novoNome, cliente.Nome);
    }
}
