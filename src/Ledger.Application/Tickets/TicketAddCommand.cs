using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Products.ValueObjects;
using Ledger.Domain.Providers.Interfaces;
using Ledger.Domain.Providers.ValueObjects;
using Ledger.Domain.Tickets;
using Ledger.Domain.Tickets.Entity;
using Ledger.Domain.Tickets.Enums;
using Ledger.Domain.Tickets.Interfaces;

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
        double Amount = 1,
        MesureUnit MesureUnit = MesureUnit.Unit);

    public class TicketAddCommandHandler : ICommandHandler<TicketAddCommand, Result<Ticket>>
    {
        private readonly ITicketRepository _repository;
        private readonly IProviderRepository _providerRepository;
        private readonly IProductRepository _productRepository;

        public TicketAddCommandHandler(
            ITicketRepository repository,
            IProviderRepository providerRepository,
            IProductRepository productRepository)
        {
            _repository = repository;
            _providerRepository = providerRepository;
            _productRepository = productRepository;
        }

        public async Task<Result<Ticket>> Handle(TicketAddCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.ProviderId, out var providerGuid))
            {
                throw new Exception("Invalid passed GUID");
            }
            var provider = await _providerRepository.FindAsync(ProviderId.Create(providerGuid), cancellationToken)
                ?? throw new Exception("Unable to find Provider");

            var orders = request.Orders.Select(async o =>
            {
                if (!Guid.TryParse(o.Product, out var productGuid))
                {
                    throw new Exception("Invalid passed GUID");
                }
                var product = await _productRepository.FindAsync(
                    ProductId.Create(productGuid),
                    cancellationToken) ?? throw new Exception("Unable to find Product");
                return Order.Create(product, o.Value, o.Amount);
            });

            var ticket = Ticket.Create(
                provider,
                request.Date,
                await Task.WhenAll(orders),
                request.Installments,
                request.Currency,
                request.Direction);
            await _repository.CreateAsync(ticket, cancellationToken);

            return ticket;
        }
    }

}
