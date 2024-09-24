using DDD.Core.DataPersistence;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using DDD.Core.Holders;
using DDD.Core.Messages;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ledger.Infrastructure.DataPersistence.SqlServer
{
    internal class SqlServerContext : DbContext, IDomainContext
    {
        private readonly IMessageHandler _messageHandler;

        public SqlServerContext(DbContextOptions<SqlServerContext> options, IMessageHandler messageHandler)
            : base(options)
        {
            _messageHandler = messageHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await DispatchDomainEvents(cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }

        private async Task DispatchDomainEvents(CancellationToken cancellationToken = default)
        {
            var eventHolders = ChangeTracker.Entries()
                .Where(ee => ee.Entity is DomainEventHolder)
                .Select(ee => (DomainEventHolder)ee.Entity)
                .ToList();

            foreach (var eventHolder in eventHolders)
            {
                while (eventHolder.TryRemoveDomainEvent(out IEvent domainEvent))
                {
                    await _messageHandler.PublishAsync(domainEvent, cancellationToken);
                }
            }
        }
    }
}
