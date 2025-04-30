using DDD.Core.DomainObjects;

namespace Ledger.Domain.Bills.ValueObjects;

public class BillId : ValueObject
{
    public Guid Value { get; set; }

    private BillId(Guid value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public static BillId Create()
    {
        return new BillId(Guid.NewGuid());
    }

    public static BillId Create(Guid value)
    {
        return new BillId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
