using DDD.Core.DomainObjects;

namespace Ledger.Domain.Providers.ValueObjects
{
    public class ProviderId : ValueObject
    {
        public Guid Value { get; set; }

        private ProviderId(Guid value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static ProviderId Create()
        {
            return new ProviderId(Guid.NewGuid());
        }

        public static ProviderId Create(Guid value)
        {
            return new ProviderId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
