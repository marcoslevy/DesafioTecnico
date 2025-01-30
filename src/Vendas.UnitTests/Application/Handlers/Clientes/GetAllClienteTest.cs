using Moq;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Domain.Clientes.Handlers;
using Vendas.Core.Entities;
using Vendas.Core.Repositories;
using Xunit;

namespace Vendas.UnitTests.Application.Handlers.Clientes;

public class GetAllClienteTest
{
    [Fact]
    public async Task Handle_DeveRetornarListaDeClientes()
    {
        // Arrange
        var clientes = new List<Cliente>
        {
            new Cliente("Marcos Levy"),
            new Cliente("Maria Otilia"),
            new Cliente("Anna Caroline"),
            new Cliente("Anna Elisa")
        };

        var mockRepository = new Mock<IClienteRepository>();
        mockRepository
            .Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(clientes);

        var handler = new GetAllClienteCommandHandler(mockRepository.Object);
        var command = new GetAllClienteCommand();

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(4, result.Data.Count);
        Assert.Equal("Marcos Levy", result.Data[0].Nome);
    }
}
