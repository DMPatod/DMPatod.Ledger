using DDD.Core.DomainObjects;
using Ledger.Domain.Products.Enums;
using Ledger.Domain.Products.ValueObjects;

namespace Ledger.Domain.Products
{
    public class Product : AggregateRoot<ProductId>
    {
        public string Name { get; set; }

        public MesureUnit MesureUnit { get; set; }

        public double AverageValue { get; private set; }

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
