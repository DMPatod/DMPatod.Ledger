using Ledger.Infrastructure.DataPersistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ledger.Infrastructure
{
    public static class BuildHandler
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataPersistence(configuration);

            return services;
        }
    }
}
