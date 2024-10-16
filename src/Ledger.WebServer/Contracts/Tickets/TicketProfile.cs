using AutoMapper;
using Ledger.Domain.Tickets;

namespace Ledger.WebServer.Contracts.Tickets
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketResponse>();
        }
    }
}
