namespace Ledger.WebServer.Contracts.Orders
{
    public record OrderCreateRequest(string Product, double Value, double Amount);
}
