using DDD.Core.DomainObjects;
using Ledger.Domain.Providers;
using Ledger.Domain.Tickets.Entity;
using Ledger.Domain.Tickets.Enums;
using Ledger.Domain.Tickets.ValueObjects;

namespace Ledger.Domain.Tickets
{
    public class Ticket : AggregateRoot<TicketId>
    {
        public Provider Provider { get; set; }

        public DateOnly Date { get; set; }

        public ICollection<Order> Orders { get; set; } = [];

        public double Value { get => Orders.Sum(o => o.Value * o.Amount); }

        public int Installments { get; set; }

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
            ICollection<Order> orders,
            int installments,
            Currency currency,
            Direction direction)
            : base(id)
        {
            Provider = provider;
            Date = date;
            Orders = orders;
            Installments = installments;
            Currency = currency;
            Direction = direction;
        }

        public static Ticket Create(
            Provider provider,
            DateOnly date,
            ICollection<Order> orders,
            int installments = 0,
            Currency currency = Currency.BRL,
            Direction direction = Direction.Outcome)
        {
            if (orders.Count < 1)
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
