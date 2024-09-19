using Ledger.Domain.Tickets;
using Ledger.Domain.Tickets.Interfaces;
using Ledger.Domain.Tickets.ValueObjects;

namespace Ledger.Infrastructure.DataPersistence.SqlServer.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        public Task<Ticket> CreateAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> FindAsync(TicketId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Ticket>> FindAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
