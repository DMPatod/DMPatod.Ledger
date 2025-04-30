using DDD.Core.DomainObjects;
using Ledger.Domain.Bills.ValueObjects;
using Ledger.Domain.Providers;
using Ledger.Domain.Tickets.Enums;

namespace Ledger.Domain.Bills;

public class Bill : AggregateRoot<BillId>
{
    public Provider Provider { get; protected set; }
    public DateOnly Date { get; protected set; }
    public DateOnly DueDate { get; protected set; }
    public Currency Currency { get; protected set; }
    public double Value { get; protected set; }

    private Bill()
    {
        // For EF Only.
    }

    internal Bill(
        BillId id,
        Provider provider,
        DateOnly date,
        DateOnly dueDate,
        double value,
        Currency currency)
        : base(id)
    {
        Provider = provider;
        Date = date;
        DueDate = dueDate;
        Value = value;
        Currency = currency;
    }

    public static Bill Create(
        Provider provider,
        DateOnly date,
        DateOnly dueDate,
        double value,
        Currency currency = Currency.BRL)
    {
        return new Bill(
            BillId.Create(),
            provider,
            date,
            dueDate,
            value,
            currency);
    }
}
