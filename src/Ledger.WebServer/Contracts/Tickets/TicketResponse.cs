using Ledger.Domain.Tickets.Enums;
using Ledger.WebServer.Contracts.Orders;
using Ledger.WebServer.Contracts.Providers;

namespace Ledger.WebServer.Contracts.Tickets
{
    public record TicketResponse(
        string Id,
        ProviderResponse Provider,
        string Date,
        IEnumerable<OrderResponse> Orders,
        int Installments,
        Currency Currency,
        Direction Direction);
}
