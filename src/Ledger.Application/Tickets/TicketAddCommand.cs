using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Products.ValueObjects;
using Ledger.Domain.Providers.Interfaces;
using Ledger.Domain.Providers.ValueObjects;
using Ledger.Domain.Tickets;
using Ledger.Domain.Tickets.Enums;
using Ledger.Domain.Tickets.Interfaces;
using Ledger.Domain.Tickets.Messages;
using Ledger.Domain.Tickets.ValueObjects;
using MassTransit;

namespace Ledger.Application.Tickets
{
    public record TicketAddCommand(
        string ProviderId,
        DateOnly Date,
        IEnumerable<OrderItem> Orders,
        int Installments,
        Currency Currency,
        Direction Direction) : ICommand<Result<Ticket>>;

    public record OrderItem(
        string Product,
        double Value,
        double Amount = 1);

    public class TicketAddCommandHandler : ICommandHandler<TicketAddCommand, Result<Ticket>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITopicProducer<ExMessage> _publishEndpoint;

        public TicketAddCommandHandler(
            ITicketRepository ticketRepository,
            IProviderRepository providerRepository,
            IProductRepository productRepository,
            ITopicProducer<ExMessage> publisher)
        {
            _ticketRepository = ticketRepository;
            _providerRepository = providerRepository;
            _productRepository = productRepository;
            _publishEndpoint = publisher;
        }

        public async Task<Result<Ticket>> Handle(TicketAddCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Produce(new ExMessage("TEST"), cancellationToken);

            // if (!Guid.TryParse(request.ProviderId, out var providerGuid))
            // {
            //     throw new Exception("Invalid passed GUID");
            // }
            // var provider = await _providerRepository.FindAsync(ProviderId.Create(providerGuid), cancellationToken)
            //     ?? throw new Exception("Unable to find Provider");
            //
            // var orders = new List<OrderValue>();
            // foreach (var item in request.Orders)
            // {
            //     if (!Guid.TryParse(item.Product, out var productGuid))
            //     {
            //         throw new Exception("Invalid passed GUID");
            //     }
            //     var product = await _productRepository.FindAsync(ProductId.Create(productGuid), cancellationToken)
            //         ?? throw new Exception("Unable to find Product");
            //     orders.Add(new OrderValue(
            //         product,
            //         item.Value,
            //         item.Amount));
            // }

            // var ticket = Ticket.Create(
            //     provider,
            //     request.Date,
            //     orders,
            //     request.Installments,
            //     request.Currency,
            //     request.Direction);
            //await _ticketRepository.AddAsync(ticket, cancellationToken);

            return Result.Fail("Fail");
        }
    }
}