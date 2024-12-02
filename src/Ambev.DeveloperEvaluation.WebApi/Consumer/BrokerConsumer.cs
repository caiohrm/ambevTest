using MassTransit;
namespace Ambev.DeveloperEvaluation.WebApi.Consumer;
public class BrokerConsumer : IConsumer<Message>
{
    public Task Consume(ConsumeContext<Message> context)
    {
        Console.WriteLine(context.Message.Text);
        return Task.CompletedTask;
    }
}