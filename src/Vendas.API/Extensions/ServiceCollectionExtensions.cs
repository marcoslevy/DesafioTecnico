using MediatR;
using Vendas.Application.Domain.Clientes.Commands;
using Vendas.Application.Domain.Clientes.Validations;
using Vendas.Application.Domain.Produtos.Commands;
using Vendas.Application.Domain.Produtos.Validations;
using Vendas.Application.Domain.VendaItens.Commands;
using Vendas.Application.Domain.VendaItens.Validations;
using Vendas.Application.Domain.Vendas.Commands;
using Vendas.Application.Domain.Vendas.Validations;
using Vendas.Application.Models;
using Vendas.Application.Services;
using Vendas.Core.Repositories;
using Vendas.Core.Services;
using Vendas.Infra.Persistence.Repositories;
using Vendas.Infra.Services;

namespace Vendas.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServicesCollection(this IServiceCollection services)
    {
        services
            .AddServices()
            .AddHandlers()
            .AddRepositories();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IMessageBusService>(provider => new MessageBusService("amqp://admin:admin@localhost:5672/"));

        services.AddTransient<SendMessage>();

        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertClienteCommand>());

        services.AddTransient<IPipelineBehavior<InsertClienteCommand, ResultViewModel<int>>, InsertClienteCommandValidator>();
        services.AddTransient<IPipelineBehavior<InsertProdutoCommand, ResultViewModel<int>>, InsertProdutoCommandValidator>();
        services.AddTransient<IPipelineBehavior<InsertItemCommand, ResultViewModel>, InsertItemCommandValidator>();
        services.AddTransient<IPipelineBehavior<UpdateVendaCommand, ResultViewModel>, UpdateVendaCommandValidator>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IVendaRepository, VendaRepository>();
        services.AddScoped<IVendaItemRepository, VendaItemRepository>();

        return services;
    }
}
