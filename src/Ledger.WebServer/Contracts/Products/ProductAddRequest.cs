using Ledger.Domain.Products.Enums;

namespace Ledger.WebServer.Contracts.Products
{
    public record ProductAddRequest(string Name, MesureUnit MesureUnit = MesureUnit.Unit);
}
