using DDD.Core.DomainObjects;
using Ledger.Domain.Products;
using Ledger.Domain.Products.ValueObjects;
using Ledger.Domain.Tickets.ValueObjects;

namespace Ledger.Domain.Tickets.Entity
{
    public class Order : Entity<OrderId>
    {
        public ProductId ProductId { get; protected set; }

        public Product Product { get; protected set; }

        public TicketId TicketId { get; protected set; }

        //public Ticket Ticket { get; protected set; }

        public double Value { get; protected set; }

        public double Amount { get; protected set; }

        public double Total { get => Value * Amount; }

        private Order()
        {
            // For EF Only.
        }

        internal Order(
            OrderId id,
            Product product,
            Ticket ticket)
         : base(id)
        {
            Product = product;
            //Ticket = ticket;
            Value = id.Value;
            Amount = id.Amount;
        }

        public static Order Create(Product product, Ticket ticket, double value, double amount = 1)
        {
            return new Order(
                OrderId.Create(product, ticket, value, amount),
                product,
                ticket);
        }
    }
}
