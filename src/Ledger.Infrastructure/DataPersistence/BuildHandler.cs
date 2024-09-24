using Ledger.Domain.Products.Interfaces;
using Ledger.Domain.Providers.Interfaces;
using Ledger.Domain.Tickets.Interfaces;
using Ledger.Infrastructure.DataPersistence.SqlServer;
using Ledger.Infrastructure.DataPersistence.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ledger.Infrastructure.DataPersistence
{
    public static class BuildHandler
    {
        public static IServiceCollection AddDataPersistence(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<SqlServerContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            service.AddTransient<ITicketRepository, TicketRepository>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProviderRepository, ProviderRepository>();

            return service;
        }
    }
}
