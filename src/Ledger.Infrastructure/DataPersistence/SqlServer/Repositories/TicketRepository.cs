using Ledger.Domain.Tickets;
using Ledger.Domain.Tickets.Interfaces;
using Ledger.Domain.Tickets.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Ledger.Infrastructure.DataPersistence.SqlServer.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        private readonly SqlServerContext _context;

        public TicketRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<Ticket> AddAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            var ct = await _context.AddAsync(entity, cancellationToken);
            await _context.SaveAsync(cancellationToken);
            return ct.Entity;
        }

        public Task DeleteAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket?> FindAsync(TicketId id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Ticket>().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public async Task<ICollection<Ticket>> FindAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Ticket>().Include(t => t.Orders).ToListAsync(cancellationToken);
        }

        public Task<int> FindPaginatedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
