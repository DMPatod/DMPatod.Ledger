using DDD.Core.DomainObjects;
using Ledger.Domain.Products.ValueObjects;
using Ledger.Domain.Tickets.Entity;
using Ledger.Domain.Tickets.Enums;

namespace Ledger.Domain.Products
{
    public class Product : AggregateRoot<ProductId>
    {
        public string Name { get; set; }

        public ICollection<Order> Orders { get; } = [];

        public MesureUnit MesureUnit { get; set; }

        public double AveragePrice { get => Orders.Average(o => o.Value); }

        private Product()
        {
            // For EF Only.
        }

        internal Product(ProductId id, string name, MesureUnit mesureUnit)
            : base(id)
        {
            Name = name;
            MesureUnit = mesureUnit;
        }

        public static Product Create(string name, MesureUnit mesureUnit = MesureUnit.Unit)
        {
            return new Product(
                ProductId.Create(),
                name,
                mesureUnit);
        }
    }
}
