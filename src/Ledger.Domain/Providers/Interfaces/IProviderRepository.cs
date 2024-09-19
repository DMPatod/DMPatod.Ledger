using DDD.Core.Repositories;
using Ledger.Domain.Providers.ValueObjects;

namespace Ledger.Domain.Providers.Interfaces
{
    public interface IProviderRepository : IBaseRepository<Provider, ProviderId>
    {
    }
}
