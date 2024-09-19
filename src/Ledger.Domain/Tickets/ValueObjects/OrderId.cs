using DDD.Core.DomainObjects;

namespace Ledger.Domain.Tickets.ValueObjects
{
    public class OrderId : ValueObject
    {
        public Guid Value { get; set; }

        private OrderId(Guid value)
        {
            Value = value;
        }

        public static OrderId Create()
        {
            return new OrderId(Guid.NewGuid());
        }

        public static OrderId Create(Guid value)
        {
            return new OrderId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
