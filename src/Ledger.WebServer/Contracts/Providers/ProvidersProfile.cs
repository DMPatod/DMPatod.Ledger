using AutoMapper;
using Ledger.Domain.Providers;

namespace Ledger.WebServer.Contracts.Providers
{
    public class ProvidersProfile : Profile
    {
        public ProvidersProfile()
        {
            CreateMap<Provider, ProviderResponse>();
        }
    }
}
