using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Providers.Interfaces;
using Ledger.Domain.Tickets.Interfaces;

namespace Ledger.Domain
{
    public class UnitOfWork
    {
        private readonly IProviderRepository _providerRepository;
        public IProviderRepository ProviderRepository { get => _providerRepository; }


        private readonly IProductRepository _productRepository;
        public IProductRepository ProductRepository { get => _productRepository; }


        private readonly IProductService _productService;
        public IProductService ProductService { get => _productService; }


        private readonly ITicketRepository _ticketRepository;
        public ITicketRepository TicketRepository { get => _ticketRepository; }


        public UnitOfWork(
            IProviderRepository providerRepository,
            IProductRepository productRepository,
            ITicketRepository ticketRepository,
            IProductService productService)
        {
            _providerRepository = providerRepository;
            _productRepository = productRepository;
            _ticketRepository = ticketRepository;
            _productService = productService;
        }
    }
}
