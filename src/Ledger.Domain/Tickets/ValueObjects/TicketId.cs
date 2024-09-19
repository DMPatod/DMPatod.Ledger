using DDD.Core.DomainObjects;

namespace Ledger.Domain.Tickets.ValueObjects
{
    public class TicketId : ValueObject
    {
        public Guid Value { get; set; }

        private TicketId(Guid value)
        {
            Value = value;
        }

        public static TicketId Create()
        {
            return new TicketId(Guid.NewGuid());
        }

        public static TicketId Create(Guid value)
        {
            return new TicketId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
