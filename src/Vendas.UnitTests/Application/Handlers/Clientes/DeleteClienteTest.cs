using Moq;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Domain.Clientes.Handlers;
using Vendas.Core.Entities;
using Vendas.Core.Repositories;
using Xunit;

namespace Vendas.UnitTests.Application.Handlers.Clientes;

public class DeleteClienteTest
{
    [Fact]
    public async Task Handle_DeveExcluirClienteERetornarSucesso()
    {
        // Arrange
        var clienteId = 1;
        var cliente = new Cliente("Marcos Levy");

        var mockRepository = new Mock<IClienteRepository>();
        mockRepository
            .Setup(repo => repo.GetByIdAsync(clienteId))
            .ReturnsAsync(cliente);

        var handler = new DeleteClienteCommandHandler(mockRepository.Object);
        var command = new DeleteClienteCommand(clienteId);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepository.Verify(repo => repo.Delete(cliente), Times.Once);
        mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        Assert.True(result.IsSuccess);
    }
}
