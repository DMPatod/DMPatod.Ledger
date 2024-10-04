using Ledger.Domain.Products;
using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Ledger.Infrastructure.DataPersistence.SqlServer.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext _context;

        public ProductRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product entity, CancellationToken cancellationToken = default)
        {
            var ct = await _context.AddAsync(entity, cancellationToken);
            await _context.SaveAsync(cancellationToken);
            return ct.Entity;
        }

        public Task DeleteAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> FindAsync(ProductId id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<ICollection<Product>> FindAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().ToListAsync(cancellationToken);
        }

        public Task<int> FindPaginatedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
