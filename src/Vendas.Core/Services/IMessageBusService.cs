namespace Vendas.Core.Services;

public interface IMessageBusService
{
    Task<string> PublishAndWaitForReplyAsync(string queueName, string message);
}
