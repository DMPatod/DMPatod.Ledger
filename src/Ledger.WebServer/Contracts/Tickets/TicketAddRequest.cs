using Ledger.Domain.Tickets.Enums;
using Ledger.WebServer.Contracts.Orders;

namespace Ledger.WebServer.Contracts.Tickets
{
    public record TicketAddRequest(
        string Provider,
        string Date,
        ICollection<OrderCreateRequest> Orders,
        int Installments,
        Currency Currency,
        Direction Direction);
}
