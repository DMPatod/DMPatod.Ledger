using Ledger.Domain.Providers;
using Ledger.Domain.Providers.Interfaces;
using Ledger.Domain.Providers.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Ledger.Infrastructure.DataPersistence.SqlServer.Repositories
{
    internal class ProviderRepository : IProviderRepository
    {
        private readonly SqlServerContext _context;

        public ProviderRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<Provider> AddAsync(Provider entity, CancellationToken cancellationToken = default)
        {
            var ct = await _context.AddAsync(entity, cancellationToken);
            await _context.SaveAsync(cancellationToken);
            return ct.Entity;
        }

        public Task DeleteAsync(Provider entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Provider?> FindAsync(ProviderId id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Provider>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public Task<ICollection<Provider>> FindAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> FindPaginatedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Provider entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
