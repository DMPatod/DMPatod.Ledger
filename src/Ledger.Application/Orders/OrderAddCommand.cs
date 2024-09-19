using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain.Tickets;
using Ledger.Domain.Tickets.Entity;
using Ledger.Domain.Tickets.Enums;

namespace Ledger.Application.Orders
{
    public record OrderAddCommand(Ticket Ticket,
        string Product,
        double Value,
        double Amount = 1,
        MesureUnit MesureUnit = MesureUnit.Unit) : ICommand<Result<Order>>;

    public class OrderAddCommandHandler : ICommandHandler<OrderAddCommand, Result<Order>>
    {
        public Task<Result<Order>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
