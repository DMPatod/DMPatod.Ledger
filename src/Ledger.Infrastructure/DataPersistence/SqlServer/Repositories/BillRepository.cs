using Ledger.Domain.Bills;
using Ledger.Domain.Bills.Interfaces;
using Ledger.Domain.Bills.ValueObjects;

namespace Ledger.Infrastructure.DataPersistence.SqlServer.Repositories;

internal class BillRepository(SqlServerContext context) : IBillRepository
{
    public async Task<Bill> AddAsync(Bill entity, CancellationToken cancellationToken = default)
    {
        var ct = await context.AddAsync(entity, cancellationToken);
        await context.SaveAsync(cancellationToken);
        return ct.Entity;
    }

    public Task DeleteAsync(Bill entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Bill?> FindAsync(BillId id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Bill>> FindAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> FindPaginatedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Bill entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
