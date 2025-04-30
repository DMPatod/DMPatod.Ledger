using Ledger.Domain.Bills.Interfaces;
using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Providers.Interfaces;
using Ledger.Domain.Tickets.Interfaces;

namespace Ledger.Domain;

public class UnitOfWork(
    IProviderRepository providerRepository,
    IProductRepository productRepository,
    ITicketRepository ticketRepository,
    IProductService productService,
    IBillRepository billRepository)
{
    public IProviderRepository ProviderRepository { get => providerRepository; }
    public IProductRepository ProductRepository { get => productRepository; }
    public IProductService ProductService { get => productService; }
    public ITicketRepository TicketRepository { get => ticketRepository; }
    public IBillRepository BillRepository { get => billRepository; }
}
