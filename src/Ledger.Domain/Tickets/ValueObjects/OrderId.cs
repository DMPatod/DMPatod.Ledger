using DDD.Core.DomainObjects;
using Ledger.Domain.Products;
using Ledger.Domain.Products.ValueObjects;

namespace Ledger.Domain.Tickets.ValueObjects
{
    public class OrderId : ValueObject
    {
        public ProductId Product { get; set; }

        public TicketId Ticket { get; set; }

        public double Value { get; set; }

        public double Amount { get; set; }

        public override string ToString()
        {
            return $"{Product} - {Ticket} - {Value} - {Amount}";
        }

        private OrderId(
            Product product,
            Ticket ticket,
            double value,
            double amount)
        {
            Product = product.Id;
            Ticket = ticket.Id;
            Value = value;
            Amount = amount;
        }

        public static OrderId Create(
            Product product,
            Ticket ticket,
            double value,
            double amount)
        {
            return new OrderId(
                product,
                ticket,
                value,
                amount);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Amount;
            yield return Product;
            yield return Ticket;
        }
    }
}
