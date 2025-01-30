using Moq;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Domain.Clientes.Handlers;
using Vendas.Core.Entities;
using Vendas.Core.Repositories;
using Xunit;

namespace Vendas.UnitTests.Application.Handlers.Clientes;

public class InsertClienteTest
{
    [Fact]
    public async Task Handle_DeveInserirClienteERetornarId()
    {
        // Arrange
        var clienteId = 1;

        var mockRepository = new Mock<IClienteRepository>();
        mockRepository
            .Setup(repo => repo.AddAsync(It.IsAny<Cliente>()))
            .Callback<Cliente>(c => c.SetId(clienteId));

        var handler = new InsertClienteCommandHandler(mockRepository.Object);
        var command = new InsertClienteCommand { Nome = "Marcos Levy" };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Cliente>()), Times.Once);
        mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        Assert.True(result.IsSuccess);
        Assert.Equal(clienteId, result.Data.Id);
    }
}
