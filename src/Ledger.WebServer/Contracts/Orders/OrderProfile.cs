using AutoMapper;
using Ledger.Domain.Tickets.Entity;

namespace Ledger.WebServer.Contracts.Orders
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResponse>();
        }
    }
}
