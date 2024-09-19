using DDD.Core.Repositories;
using Ledger.Domain.Products.ValueObjects;

namespace Ledger.Domain.Products.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product, ProductId>
    {
    }
}
