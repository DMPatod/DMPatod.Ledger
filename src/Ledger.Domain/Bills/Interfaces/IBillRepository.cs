using DDD.Core.Repositories;
using Ledger.Domain.Bills.ValueObjects;

namespace Ledger.Domain.Bills.Interfaces;

public interface IBillRepository : IBaseRepository<Bill, BillId>
{
}
