using Moq;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Domain.Clientes.Handlers;
using Vendas.Core.Entities;
using Vendas.Core.Repositories;
using Xunit;

namespace Vendas.UnitTests.Application.Handlers.Clientes;

public class UpdateClienteTest
{
    [Fact]
    public async Task Handle_DeveAtualizarClienteERetornarSucesso()
    {
        // Arrange
        var clienteId = 1;
        var cliente = new Cliente("Marcos Levy");
        cliente.SetId(clienteId);

        var mockRepository = new Mock<IClienteRepository>();
        mockRepository
            .Setup(repo => repo.GetByIdAsync(clienteId))
            .ReturnsAsync(cliente);

        var handler = new UpdateClienteCommandHandler(mockRepository.Object);
        var command = new UpdateClienteCommand { Id = clienteId, Nome = "Maria Otilia" };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepository.Verify(repo => repo.Update(cliente), Times.Once);
        mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        Assert.True(result.IsSuccess);
        Assert.Equal("Maria Otilia", cliente.Nome);
    }
}
