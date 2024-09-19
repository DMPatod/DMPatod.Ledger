using DDD.Core.Repositories;
using Ledger.Domain.Tickets.ValueObjects;

namespace Ledger.Domain.Tickets.Interfaces
{
    public interface ITicketRepository : IBaseRepository<Ticket, TicketId>
    {
    }
}
