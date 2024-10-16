using DDD.Core.DomainObjects;
using Ledger.Domain.Providers;
using Ledger.Domain.Tickets.Entity;
using Ledger.Domain.Tickets.Enums;
using Ledger.Domain.Tickets.ValueObjects;

namespace Ledger.Domain.Tickets
{
    public class Ticket : AggregateRoot<TicketId>
    {
        public Provider Provider { get; protected set; }

        public DateOnly Date { get; protected set; }

        private IList<Order> _orders = [];

        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        public double Value { get => _orders.Sum(o => o.Value * o.Amount); }

        public int Installments { get; protected set; }

        public DateOnly? FinishPayment
        {
            get
            {
                if (Installments > 1)
                {
                    return Date.AddMonths(Installments);
                }
                return null;
            }
        }

        public Currency Currency { get; set; }

        public Direction Direction { get; set; }

        private Ticket()
        {
            // For EF Only.
        }

        internal Ticket(
            TicketId id,
            Provider provider,
            DateOnly date,
            IEnumerable<OrderValue> orders,
            int installments,
            Currency currency,
            Direction direction)
            : base(id)
        {
            Provider = provider;
            Date = date;
            _orders = orders.Select(o => Order.Create(o.Product, this, o.Value, o.Amount)).ToList();
            Installments = installments;
            Currency = currency;
            Direction = direction;
        }

        public static Ticket Create(
            Provider provider,
            DateOnly date,
            IEnumerable<OrderValue> orders,
            int installments = 0,
            Currency currency = Currency.BRL,
            Direction direction = Direction.Outcome)
        {
            if (!orders.Any())
            {
                throw new Exception("Ticket must have at least one order");
            }

            return new Ticket(
                TicketId.Create(),
                provider,
                date,
                orders,
                installments,
                currency,
                direction);
        }
    }
}
