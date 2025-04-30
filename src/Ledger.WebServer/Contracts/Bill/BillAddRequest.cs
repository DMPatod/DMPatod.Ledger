using Ledger.Domain.Tickets.Enums;

namespace Ledger.WebServer.Contracts.Bill
{

    public record BillAddRequest(
        string Provider,
        string Date,
        string DueDate,
        double Value,
        Currency Currency);
}
