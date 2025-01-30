using Vendas.Core.Services;

namespace Vendas.Application.Services;

public class SendMessage
{
    private readonly IMessageBusService _messageBusService;

    public SendMessage(IMessageBusService messageBusService)
    {
        _messageBusService = messageBusService;
    }

    public async Task<string> ExecuteAsync(string queueName, string message)
    {
        return await _messageBusService.PublishAndWaitForReplyAsync(queueName, message);
    }
}
