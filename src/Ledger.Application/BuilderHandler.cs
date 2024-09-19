using DDD.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ledger.Application
{
    public static class BuilderHandler
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddDefaultMessageHandler(typeof(BuilderHandler).Assembly);

            return services;
        }
    }
}
