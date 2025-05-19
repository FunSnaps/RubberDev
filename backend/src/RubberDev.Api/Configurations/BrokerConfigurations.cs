using RubberDev.Application.Interfaces;
using RubberDev.Infrastructure.Brokers;

namespace RubberDev.Api.Configurations;

public static class BrokerConfigurations
{
    public static void AddBrokers(this IServiceCollection services)
    {
        services.AddScoped<IStorageBroker, StorageBroker>();
    }
}