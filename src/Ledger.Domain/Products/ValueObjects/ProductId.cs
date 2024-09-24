using DDD.Core.DomainObjects;

namespace Ledger.Domain.Products.ValueObjects
{
    public class ProductId : ValueObject
    {
        public Guid Value { get; set; }

        private ProductId(Guid value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static ProductId Create()
        {
            return new ProductId(Guid.NewGuid());
        }

        public static ProductId Create(Guid value)
        {
            return new ProductId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
