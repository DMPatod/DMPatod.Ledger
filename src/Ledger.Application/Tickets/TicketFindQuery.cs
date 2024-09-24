using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Ledger.Domain;
using Ledger.Domain.Tickets;

namespace Ledger.Application.Tickets
{
    public record TicketFindQuery() : IResultCommand<ICollection<Ticket>>;

    public class TicketFindQueryHandler : IResultComandHandler<TicketFindQuery, ICollection<Ticket>>
    {
        private readonly UnitOfWork _unitOfWork;

        public TicketFindQueryHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ICollection<Ticket>>> Handle(TicketFindQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _unitOfWork.TicketRepository.FindAsync(cancellationToken);
            return tickets.ToList();
        }
    }
}
