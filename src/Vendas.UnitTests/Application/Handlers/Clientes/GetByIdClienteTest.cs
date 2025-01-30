using Moq;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Domain.Clientes.Handlers;
using Vendas.Core.Entities;
using Vendas.Core.Repositories;
using Xunit;

namespace Vendas.UnitTests.Application.Handlers.Clientes;

public class GetByIdClienteTest
{
    [Fact]
    public async Task Handle_DeveRetornarCliente()
    {
        // Arrange
        var clienteId = 1;
        var cliente = new Cliente("Marcos Levy");

        var mockRepository = new Mock<IClienteRepository>();
        mockRepository
            .Setup(repo => repo.GetByIdAsync(clienteId))
            .ReturnsAsync(cliente);

        var handler = new GetByIdClienteCommandHandler(mockRepository.Object);
        var command = new GetByIdClienteCommand(clienteId);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Marcos Levy", result.Data.Nome);
    }
}
