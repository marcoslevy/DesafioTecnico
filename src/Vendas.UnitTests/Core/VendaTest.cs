using Vendas.Core.Entities;
using Xunit;

namespace Vendas.UnitTests.Core;

public class VendaTest
{
    [Fact]
    public void Construtor_DeveConfigurarPropriedadesCorretamente()
    {
        // Arrange
        int clienteId = 1;

        // Act
        var venda = new Venda(clienteId);

        // Assert
        Assert.Equal(clienteId, venda.ClienteId);
        Assert.Equal(VendaEnum.Criada, venda.Status);
        Assert.Null(venda.DataStatus);
    }

    [Fact]
    public void Update_DeveAtualizarClienteId()
    {
        // Arrange
        var venda = new Venda(1);
        int novoClienteId = 2;

        // Act
        venda.Update(novoClienteId);

        // Assert
        Assert.Equal(novoClienteId, venda.ClienteId);
    }

    [Fact]
    public void Faturar_DeveAtualizarStatusEDataStatus()
    {
        // Arrange
        var venda = new Venda(1);

        // Act
        venda.Faturar();

        // Assert
        Assert.Equal(VendaEnum.Faturada, venda.Status);
        Assert.NotNull(venda.DataStatus);
    }

    [Fact]
    public void Cancelar_DeveAtualizarStatusEDataStatus()
    {
        // Arrange
        var venda = new Venda(1);

        // Act
        venda.Cancelar();

        // Assert
        Assert.Equal(VendaEnum.Cancelada, venda.Status);
        Assert.NotNull(venda.DataStatus);
    }
}
