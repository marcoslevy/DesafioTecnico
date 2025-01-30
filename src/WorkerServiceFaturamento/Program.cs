using Vendas.Core.Services;
using Vendas.Infra.Services;
using WorkerServiceFaturamento;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<IMessageBusService>(provider => new MessageBusService("amqp://user:password@localhost:5672/"));

var host = builder.Build();

host.Run();
