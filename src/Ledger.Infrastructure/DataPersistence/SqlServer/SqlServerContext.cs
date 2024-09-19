using DDD.Core.DataPersistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ledger.Infrastructure.DataPersistence.SqlServer
{
    internal class SqlServerContext : DbContext, IDomainContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
