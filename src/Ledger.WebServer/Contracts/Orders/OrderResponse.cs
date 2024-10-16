using Ledger.WebServer.Contracts.Products;

namespace Ledger.WebServer.Contracts.Orders
{
    public record OrderResponse(
        string Id,
        ProductResponse Product,
        double Value,
        double Amount);
}
