using Ledger.Domain.Products;
using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Providers;
using Ledger.Domain.Tickets;

namespace Ledger.Application.Products
{
    internal class ProductService : IProductService
    {
        public Task<Dictionary<Provider, double>> GetProductPricesAcrossProviders(Product product, IEnumerable<Ticket> tickets)
        {
            var dic = new Dictionary<Provider, double>();
            foreach (var (ticket, order) in tickets.SelectMany(ticket => ticket.Orders.Where(order => order.Product == product).Select(order => (ticket, order))))
            {
                if (!dic.ContainsKey(ticket.Provider))
                {
                    dic[ticket.Provider] = 0;
                }

                dic[ticket.Provider] = (dic[ticket.Provider] + order.Value) / 2;
            }

            return Task.FromResult(dic);
        }
    }
}
