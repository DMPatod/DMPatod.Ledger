using Ledger.Domain.Tickets.Messages;
using MassTransit;

namespace Ledger.Infrastructure.Messaging
{
    internal class ExConsumer : IConsumer<ExMessage>
    {
        public async Task Consume(ConsumeContext<ExMessage> context)
        {
            Console.WriteLine($"Received: {context.Message.Text}");

            await Task.CompletedTask;
        }
    }
}
