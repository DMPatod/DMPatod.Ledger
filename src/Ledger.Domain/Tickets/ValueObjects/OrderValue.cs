using Ledger.Domain.Products;

namespace Ledger.Domain.Tickets.ValueObjects
{
    public record OrderValue(Product Product, double Value, double Amount = 1);
}
