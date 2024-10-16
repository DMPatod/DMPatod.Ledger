using DDD.Core.Handlers;
using Ledger.Application.Products;
using Ledger.Domain;
using Ledger.Domain.Products.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ledger.Application
{
    public static class BuilderHandler
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddDefaultMessageHandler(typeof(BuilderHandler).Assembly);
            services.AddScoped<UnitOfWork>();

            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
