using Confluent.Kafka;
using Ledger.Domain.Tickets.Messages;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ledger.Infrastructure.Messaging
{
    public static class BuildHandler
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("KafkaConfiguration").Get<KafkaConfiguration>() ??
                         throw new Exception("KafkaConfiguration is missing");
            services.AddMassTransit(b =>
            {
                b.UsingInMemory((ctx, cfg) => { cfg.ConfigureEndpoints(ctx); });

                b.AddRider(r =>
                {
                    r.AddProducer<ExMessage>("topicName");

                    r.AddConsumer<ExConsumer>();

                    r.UsingKafka((ctx, cfg) =>
                    {
                        cfg.Host(config.Host);

                        cfg.TopicEndpoint<ExMessage>("topicName", config.GroupId, e =>
                        {
                            e.ConfigureConsumer<ExConsumer>(ctx);
                            e.CreateIfMissing();
                        });
                    });
                });
            });

            return services;
        }
    }
}