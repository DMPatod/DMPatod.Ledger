using DDD.Core.DomainObjects;
using Ledger.Domain.Providers.ValueObjects;
using Ledger.Domain.Tickets;

namespace Ledger.Domain.Providers
{
    public class Provider : AggregateRoot<ProviderId>
    {
        public string Name { get; set; }

        private Provider()
        {
            // For EF Only.
        }

        internal Provider(ProviderId id, string name)
            : base(id)
        {
            Name = name;
        }

        public static Provider Create(string name)
        {
            return new Provider(
                ProviderId.Create(),
                name);
        }
    }
}
