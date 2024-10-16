using DDD.Core.DomainObjects;
using Ledger.Domain.Products;
using Ledger.Domain.Providers.ValueObjects;

namespace Ledger.Domain.Providers
{
    public class Provider : AggregateRoot<ProviderId>
    {
        public string Name { get; set; }

        //private readonly IList<Product> _products = [];
        //public IReadOnlyList<Product> Products => _products.AsReadOnly();

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
