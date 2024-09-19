using DDD.Core.Repositories;
using Ledger.Domain.Tickets.Entity;
using Ledger.Domain.Tickets.ValueObjects;

namespace Ledger.Domain.Tickets.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order, OrderId>
    {
    }
}
