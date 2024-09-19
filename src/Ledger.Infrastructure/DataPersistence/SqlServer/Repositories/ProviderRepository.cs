using Ledger.Domain.Providers;
using Ledger.Domain.Providers.Interfaces;
using Ledger.Domain.Providers.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger.Infrastructure.DataPersistence.SqlServer.Repositories
{
    internal class ProviderRepository : IProviderRepository
    {
        public Task<Provider> CreateAsync(Provider entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Provider entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Provider?> FindAsync(ProviderId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Provider>> FindAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Provider entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
