using DDD.Core.DomainObjects;
using Ledger.Domain.Products;
using Ledger.Domain.Tickets.Enums;
using Ledger.Domain.Tickets.ValueObjects;

namespace Ledger.Domain.Tickets.Entity
{
    public class Order : Entity<OrderId>
    {
        public Product Product { get; set; }

        public double Value { get; set; }

        public double Amount { get; set; }

        public Ticket Ticket { get; } = null!;

        private Order()
        {
            // For EF Only.
        }

        internal Order(OrderId id, Product product, double value, double amount)
            : base(id)
        {
            Product = product;
            Value = value;
            Amount = amount;
        }

        public static Order Create(Product product, double value, double amount = 1)
        {
            return new Order(
                OrderId.Create(),
                product,
                value,
                amount);
        }
    }
}
