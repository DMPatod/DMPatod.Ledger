using Ledger.Application.Tickets;
using Ledger.Domain.Products;
using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Products.ValueObjects;
using Ledger.Domain.Providers;
using Ledger.Domain.Providers.Interfaces;
using Ledger.Domain.Providers.ValueObjects;
using Ledger.Domain.Tickets.Enums;
using Ledger.Domain.Tickets.Interfaces;
using Moq;

namespace Ledger.Application.Tests.Tickets
{
    public class TicketCreateCommandTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTicket()
        {
            var command = new TicketAddCommand(
                Guid.NewGuid().ToString(),
                DateOnly.FromDateTime(DateTime.Now),
                [
                    new OrderItem(
                        Guid.NewGuid().ToString(),
                        1)],
                1,
                Currency.BRL,
                Direction.Outcome);

            var providerRepository = new Mock<IProviderRepository>();
            providerRepository.Setup(x => x.FindAsync(It.IsAny<ProviderId>(), default))
                .ReturnsAsync(Provider.Create("Any"));

            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(x => x.FindAsync(It.IsAny<ProductId>(), default))
                .ReturnsAsync(Product.Create("Any"));

            var ticketRepository = new Mock<ITicketRepository>();

            var handler = new TicketAddCommandHandler(
                ticketRepository.Object,
                providerRepository.Object,
                productRepository.Object);

            var result = await handler.Handle(command, default);

            Assert.True(result.IsSuccess);

            var ticket = result.Value;
            Assert.Equal(1, ticket.Value);
            Assert.Null(ticket.FinishPayment);
            Assert.Single(ticket.Orders);
        }
    }
}
