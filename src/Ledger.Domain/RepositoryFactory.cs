using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Providers.Interfaces;
using Ledger.Domain.Tickets.Interfaces;

namespace Ledger.Domain
{
    public class RepositoryFactory
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITicketRepository _ticketRepository;
        public RepositoryFactory(
            IProviderRepository providerRepository,
            IProductRepository productRepository,
            ITicketRepository ticketRepository)
        {
            _providerRepository = providerRepository;
            _productRepository = productRepository;
            _ticketRepository = ticketRepository;
        }
        public IProviderRepository ProviderRepository { get => _providerRepository; }
        public IProductRepository ProductRepository { get => _productRepository; }
        public ITicketRepository TicketRepository { get => _ticketRepository; }
    }
}
