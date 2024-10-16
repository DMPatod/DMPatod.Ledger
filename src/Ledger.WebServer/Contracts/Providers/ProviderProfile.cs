using AutoMapper;
using Ledger.Domain.Providers;

namespace Ledger.WebServer.Contracts.Providers
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<Provider, ProviderResponse>();
        }
    }
}
