using Ledger.Domain.Providers;
using Ledger.Domain.Tickets;

namespace Ledger.Domain.Products.Interfaces
{
    public interface IProductService
    {
        Task<Dictionary<Provider, double>> GetProductPricesAcrossProviders(Product product, IEnumerable<Ticket> tickets);
    }
}
