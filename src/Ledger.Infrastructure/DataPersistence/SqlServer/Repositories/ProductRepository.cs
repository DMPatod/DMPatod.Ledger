using Ledger.Domain.Products;
using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger.Infrastructure.DataPersistence.SqlServer.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        public Task<Product> CreateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> FindAsync(ProductId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> FindAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
