using DDD.Core.Handlers;
using Ledger.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Ledger.Application
{
    public static class BuilderHandler
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddDefaultMessageHandler(typeof(BuilderHandler).Assembly);
            services.AddScoped<UnitOfWork>();

            return services;
        }
    }
}
